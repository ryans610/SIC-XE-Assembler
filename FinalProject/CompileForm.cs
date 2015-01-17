using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalProject
{
    public partial class CompileForm : Form
    {
        private string InputName;
        private bool InputOP;
        private string OPName;
        private bool InputASC;
        private string ASCName;
        private string OutputName;
        private bool OutputST;
        private string STName;
        private MainForm ParentForm;
        private Operators ops;
        private ASCII asc;
        private int LOCCTR = 0;
        private int startAdd = 0;
        private string ProgramName;
        private string tempTextRecord = "";
        private int tempTextRecordStart = 0;
        private int PC;
        private int B = -1;
        private StreamWriter sw;

        public CompileForm()
        {
            InitializeComponent();
        }
        public CompileForm(MainForm parent, string input, string output, string programName, bool iop = false, string op = "Operators.dat", bool iasc = false, string asc = "ASCII.dat", bool ost = false, string st = "")
        {
            ParentForm = parent;
            InputName = input;
            InputOP = iop;
            OPName = op;
            if (string.IsNullOrEmpty(op))
            {
                OPName = "Operators.dat";
            }
            InputASC = iasc;
            ASCName = asc;
            if (string.IsNullOrEmpty(asc))
            {
                ASCName = "ASCII.dat";
            }
            OutputName = output;
            OutputST = ost;
            STName = st;
            ProgramName = programName;
            InitializeComponent();
        }

        private void Detail(string str)
        {
            CompileDetails.Text = string.Format("{0}{1}\n", CompileDetails.Text, str);
            CompileDetails.Select(CompileDetails.TextLength - 1, 0);
            CompileDetails.ScrollToCaret();
        }

        private Statement AnalyzeStatement(string str)
        {
            string[] splitStr = str.Trim().Split(new char[2] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (ops.IsExist(splitStr[0]))   //Operator
            {
                Operator op = ops.Search(splitStr[0]);
                Statement newStatement;
                if (op.Operand != 0)
                {
                    newStatement = new Statement(op.Format, op.Mnemonic, op.Format, splitStr[1], op.Operand, op.Opcode, LOCCTR);
                }
                else
                {
                    newStatement = new Statement(op.Format, op.Mnemonic, op.Format, "", op.Operand, op.Opcode, LOCCTR);
                }
                return newStatement;
            }
            else if (Directives.IsDirective(splitStr[0]))   //Directive
            {
                Statement newStatement = new Statement(splitStr[0], splitStr[1], LOCCTR);
                return newStatement;
            }
            else
            {
                //has label
                if (ops.IsExist(splitStr[1]))   //Operator
                {
                    Operator op = ops.Search(splitStr[1]);
                    Statement newStatement;
                    if (op.Operand != 0)
                    {
                        newStatement = new Statement(op.Format, op.Mnemonic, op.Format, splitStr[2], op.Operand, op.Opcode, LOCCTR, splitStr[0]);
                    }
                    else
                    {
                        newStatement = new Statement(op.Format, op.Mnemonic, op.Format, "", op.Operand, op.Opcode, LOCCTR, splitStr[0]);
                    }
                    return newStatement;
                }
                else if (Directives.IsDirective(splitStr[1]))   //Directive
                {
                    Statement newStatement = new Statement(splitStr[1], splitStr[2], LOCCTR, splitStr[0]);
                    return newStatement;
                }
                else
                {
                    throw new Exception(splitStr[1] + " is not a Operator or a Directive");
                }
            }
        }

        private void EndTRecord()
        {
            if (!string.IsNullOrEmpty(tempTextRecord))
            {
                sw.WriteLine("T{0}{1}{2}", Convert.ToString(tempTextRecordStart, 16).PadLeft(6, '0').ToUpper(), Convert.ToString(tempTextRecord.Length / 2, 16).PadLeft(2, '0').ToUpper(), tempTextRecord.ToUpper());
                tempTextRecordStart = PC;
                tempTextRecord = "";
            }
        }

        private void TRecord(string str)
        {
            if (tempTextRecord.Length + str.Length > 60)
            {
                EndTRecord();
                tempTextRecord = str;
            }
            else
            {
                tempTextRecord += str;
            }
        }

        /// <summary>
        /// Format2
        /// </summary>
        private string Combine(int op, int r1)
        {
            return string.Format("{0}{1}0", Convert.ToString(op, 16).PadLeft(2, '0'), Convert.ToString(r1, 16));
        }
        /// <summary>
        /// Format2
        /// </summary>
        private string Combine(int op, int r1, int r2)
        {
            return string.Format("{0}{1}{2}", Convert.ToString(op, 16).PadLeft(2, '0'), Convert.ToString(r1, 16), Convert.ToString(r2, 16));
        }
        /// <summary>
        /// Format3
        /// </summary>
        private string Combine(int op, int n, int i, int x, int b, int p, int disp)
        {
            string binaryStr = string.Format("{0}{1}{2}{3}{4}{5}0{6}", Convert.ToString(op, 2).PadLeft(8, '0').Substring(0, 6), n, i, x, b, p, Convert.ToString(disp, 2).PadLeft(12, '0'));
            return Convert.ToString(Convert.ToInt32(binaryStr, 2), 16).PadLeft(6, '0');
        }
        /// <summary>
        /// Format4
        /// </summary>
        private string Combine(int op, int n, int i, int x, int add)
        {
            string binaryStr = string.Format("{0}{1}{2}{3}001{4}", Convert.ToString(op, 2).PadLeft(8, '0').Substring(0, 6), n, i, x, Convert.ToString(add, 2).PadLeft(20, '0'));
            return Convert.ToString(Convert.ToInt32(binaryStr, 2), 16).PadLeft(8, '0');
        }

        private void Compile()
        {
            Detail("Begin Compile...");
            List<string> statements = new List<string>();
            try
            {
                Detail("Loading Input File...");
                //讀入Input
                using (StreamReader sr = new StreamReader(InputName))
                {
                    //讀入檔案
                    string program = sr.ReadToEnd();
                    CompileBar.Value = 1;
                    Detail("Input File '" + InputName + "' Loaded.");
                    //切割與過濾
                    Detail("Processing Input File...");
                    List<string> originStatements = program.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    int i = originStatements.Count;
                    int j = 0;
                    foreach (string s in originStatements)
                    {
                        if (s.Trim().StartsWith(".") || string.IsNullOrEmpty(s.Trim()))
                        {
                            continue;
                        }
                        else
                        {
                            statements.Add(s.Trim());
                        }
                        j++;
                        CompileBar.Value = 2 + j * 5 / i;
                    }
                    CompileBar.Value = 6;
                    Detail("Input File Processed.");
                }
                //讀入Operators
                Detail("Loading Operators Data...");
                using (StreamReader sr = new StreamReader(OPName))
                {
                    ops = new Operators(sr);
                }
                CompileBar.Value = 8;
                Detail("Operators Data '" + OPName + "' Loaded.");
                //讀入ASCII
                Detail("Loading ASCII Data...");
                using (StreamReader sr = new StreamReader(ASCName))
                {
                    asc = new ASCII(sr);
                }
                CompileBar.Value = 10;
                Detail("ASCII Data '" + ASCName + "' Loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The input file could not be read!" + ex.Message, "Error");
                this.Close();
            }
            Detail("Pass1 Start...");
            //建立Symbol Table
            Detail("Analyzing Statements and Create Symbol Table...");
            SymbolTable SYMTAB = new SymbolTable();
            string[] statementStrings = statements.ToArray();
            int statementCount = statementStrings.Length;
            List<Statement> allStatement = new List<Statement>();
            try
            {
                Statement temp = AnalyzeStatement(statementStrings[0]);
                if (temp.Mnemonic == "START")   //has START
                {
                    LOCCTR = int.Parse(temp.Operand);
                    startAdd = LOCCTR;
                    if (temp.hasLabel)  //START has Label
                    {
                        allStatement.Add(new Statement(temp.Mnemonic, temp.Operand, LOCCTR, temp.LabelName));
                        SYMTAB.Add(new Symbol(LOCCTR, temp.LabelName));
                    }
                    else
                    {
                        allStatement.Add(new Statement(temp.Mnemonic, temp.Operand, LOCCTR));
                    }
                }
                else
                {
                    allStatement.Add(temp);
                    if (temp.hasLabel)
                    {
                        SYMTAB.Add(new Symbol(LOCCTR, temp.LabelName));
                    }
                    LOCCTR += temp.Take;
                }
                CompileBar.Value = 10 + 38 / statementCount;
                for (int i = 1; i < statementStrings.Length; i++)
                {
                    temp = AnalyzeStatement(statementStrings[i]);
                    allStatement.Add(temp);
                    if (temp.hasLabel)
                    {
                        SYMTAB.Add(new Symbol(LOCCTR, temp.LabelName));
                    }
                    LOCCTR += temp.Take;
                    CompileBar.Value = 10 + i * 38 / statementCount;
                }
                CompileBar.Value = 48;
                if (OutputST)   //輸出SYMTAB
                {
                    Detail("Writing Symbol Table to File...");
                    using (StreamWriter sw = new StreamWriter(STName))
                    {
                        SYMTAB.Write(sw);
                    }
                    Detail("Symbol Table Writed to File '" + STName + "'.");
                }
                CompileBar.Value = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Statement Error : " + ex.Message, "Error");
                this.Close();
            }
            Detail("End of Pass1.");
            Detail("Pass2 Start...");
            try
            {
                using (sw = new StreamWriter(OutputName))
                {
                    Detail("Writing Header Record...");
                    sw.WriteLine(string.Format("H{0}{1}{2}", ProgramName.PadRight(6), Convert.ToString(startAdd, 16).PadLeft(6, '0'), Convert.ToString(LOCCTR - startAdd, 16).PadLeft(6, '0')));
                    CompileBar.Value = 55;
                    Detail("Header Record Writed.");
                    Detail("Creating Object Code and Writing Text Record...");
                    LOCCTR = startAdd;
                    PC = startAdd + allStatement[0].Take;
                    tempTextRecordStart = PC;
                    List<int> mrecords = new List<int>();
                    for (int i = 0; i < statementCount; i++)
                    {
                        PC += allStatement[i].Take;
                        switch (allStatement[i].Format)
                        {
                            case 0:     //Directive
                                if (allStatement[i].Mnemonic == "BYTE")
                                {
                                    string[] operand = allStatement[i].Operand.Trim().Split(new char[1] { '\'' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (operand[0].Trim() == "X")
                                    {
                                        TRecord(operand[1]);
                                    }
                                    else if (operand[0].Trim() == "C")
                                    {
                                        TRecord(asc.Hex(operand[1]));
                                    }
                                }
                                else if (allStatement[i].Mnemonic == "WORD")
                                {
                                    TRecord(Convert.ToString(int.Parse(allStatement[i].Operand), 16).PadLeft(6, '0'));
                                }
                                else if (allStatement[i].Mnemonic == "BASE")
                                {
                                    B = SYMTAB.Loc(allStatement[i].Operand);
                                }
                                else
                                {
                                    EndTRecord();
                                }
                                break;
                            case 1:
                                TRecord(Convert.ToString(allStatement[i].OperatorCode, 16).PadLeft(2, '0'));
                                break;
                            case 2:
                                if (allStatement[i].OperandCount == 1)
                                {
                                    if (!allStatement[i].Operand.StartsWith("#"))
                                    {
                                        TRecord(Combine(allStatement[i].OperatorCode, Registers.RegisterNumber(allStatement[i].Operand)));
                                    }
                                    else    //Immediate
                                    {
                                        TRecord(Combine(allStatement[i].OperatorCode, int.Parse(Convert.ToString(int.Parse(allStatement[i].Operand.TrimStart('#')), 16))));
                                    }
                                }
                                else if (allStatement[i].OperandCount == 2)
                                {
                                    string[] operand = allStatement[i].Operand.Trim().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (operand[j].StartsWith("#"))     //Immediate
                                        {
                                            operand[j] = Convert.ToString(int.Parse(operand[j].TrimStart('#')), 16);
                                        }
                                    }
                                    TRecord(Combine(allStatement[i].OperatorCode, Registers.RegisterNumber(operand[0]), Registers.RegisterNumber(operand[1])));
                                }
                                else
                                {
                                    throw new Exception("Operand Error");
                                }
                                break;
                            case 3:
                                if (allStatement[i].OperandCount == 0)
                                {
                                    TRecord(Combine(allStatement[i].OperatorCode, 1, 1, 0, 0, 0, 0));
                                    break;
                                }
                                string[] ope = allStatement[i].Operand.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                int[] ar = new int[3] { 1, 1, 0 };
                                if (ope[0].StartsWith("#"))
                                {
                                    ar[0] = 0;
                                }
                                else if (ope[0].StartsWith("@"))
                                {
                                    ar[1] = 0;
                                }
                                if (ope.Length == 2 && ope[1] == "X")
                                {
                                    ar[2] = 1;
                                }
                                int b = SYMTAB.Loc(ope[0].TrimStart('#', '@'));
                                if (b != -1)    //Label
                                {
                                    int pl = b - PC, bl = b - B;
                                    if (B == -1 || bl < 0 || bl > 4095)     //PC
                                    {
                                        if (pl < -2048 || pl > 2047)
                                        {
                                            throw new Exception("Relative Address Out Range");
                                        }
                                        if (pl < 0)
                                        {
                                            pl += 4096;
                                        }
                                        TRecord(Combine(allStatement[i].OperatorCode, ar[0], ar[1], ar[2], 0, 1, pl));
                                    }
                                    else     //BASE
                                    {
                                        TRecord(Combine(allStatement[i].OperatorCode, ar[0], ar[1], ar[2], 1, 0, bl));
                                    }
                                }
                                else
                                {
                                    TRecord(Combine(allStatement[i].OperatorCode, ar[0], ar[1], ar[2], 0, 0, int.Parse(ope[0].TrimStart('#', '@'))));
                                }
                                break;
                            case 4:
                                if (allStatement[i].OperandCount == 0)
                                {
                                    TRecord(Combine(allStatement[i].OperatorCode, 1, 1, 0, 0));
                                }
                                string[] oper = allStatement[i].Operand.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                int[] arr = new int[3] { 1, 1, 0 };
                                if (oper[0].StartsWith("#"))
                                {
                                    arr[0] = 0;
                                }
                                else if (oper[0].StartsWith("@"))
                                {
                                    arr[1] = 0;
                                }
                                if (oper.Length == 2 && oper[1] == "X")
                                {
                                    arr[2] = 1;
                                }
                                int a = SYMTAB.Loc(oper[0].TrimStart('#', '@'));
                                if (a != -1)    //Label
                                {
                                    TRecord(Combine(allStatement[i].OperatorCode, arr[0], arr[1], arr[2], a));
                                    mrecords.Add(allStatement[i].Location + 1);
                                }
                                else
                                {
                                    TRecord(Combine(allStatement[i].OperatorCode, arr[0], arr[1], arr[2], int.Parse(allStatement[i].Operand.TrimStart('#'))));
                                }
                                break;
                            default:
                                throw new Exception("Format Error");
                        }
                        LOCCTR += allStatement[i].Take;
                        CompileBar.Value = 55 + i * 30 / statementCount;
                    }
                    CompileBar.Value = 85;
                    Detail("Text Record Writed.");
                    Detail("Writing Modification Record...");
                    int q = 0, k = mrecords.Count;
                    foreach (int i in mrecords)
                    {
                        sw.WriteLine(string.Format("M{0}05", Convert.ToString(i, 16).PadLeft(6, '0').ToUpper()));
                        q++;
                        CompileBar.Value = 85 + q * 10 / k;
                    }
                    CompileBar.Value = 95;
                    Detail("Modification Record Writed.");
                    Detail("Writing End Record...");
                    sw.WriteLine(string.Format("E{0}", Convert.ToString(startAdd, 16).PadLeft(6, '0').ToUpper()));
                    Detail("End Record Writed.");
                    CompileBar.Value = 98;
                    Detail("Object Program Writed to File '" + OutputName + "'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pass2 Error : " + ex.Message, "Error");
                this.Close();
            }
            Detail("End of Pass2.");
            CompileBar.Value = 99;
            Detail("Compile Finished.");
            CompileBar.Value = 100;
            MessageBox.Show("Compile Finished!", "Finished");
            button1.Text = "Close";
        }

        private void CompileForm_Load(object sender, EventArgs e)
        {

        }

        private void CompileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm.Enabled = true;
        }

        private void CompileForm_Shown(object sender, EventArgs e)
        {
            Compile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
