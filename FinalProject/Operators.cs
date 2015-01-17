using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class Operator
    {
        private string _Mnemonic;
        private int _Format;
        private int _Opcode;
        private int _Operand;

        public string Mnemonic { get { return _Mnemonic; } }
        public int Format { get { return _Format; } }
        public int Opcode { get { return _Opcode; } }
        public int Operand { get { return _Operand; } }

        public Operator(string mnemonic, int format, int opcode) : this(mnemonic, format, opcode, -1) { }
        public Operator(string mnemonic, int format, int opcode, int operand)
        {
            _Mnemonic = mnemonic;
            _Opcode = opcode;
            if (format == 1 || format == 2)
            {
                _Format = format;
            }
            else if (format == 3 || format == 4)
            {
                _Format = 3;
            }
            else
            {
                throw new Exception("Operators format error!");
            }
            if (operand == 0 || operand == 1 || operand == 2)
            {
                _Operand = operand;
            }
            else if (operand == -1)
            {
                if (format == 1 || format == 2)
                {
                    _Operand = 0;
                }
                else
                {
                    _Operand = 1;
                }
            }
            else
            {
                throw new Exception("Operators operand error!");
            }
        }

        public void isFormat4()
        {
            _Format = 4;
        }
    }

    public class Operators
    {
        private List<Operator> _AllOperators;

        public Operators() : this(new StreamReader("Operators.dat")) { }
        public Operators(StreamReader sr)
        {
            string file = sr.ReadToEnd();
            string[] originOperators = file.Trim().Split(new char[2] { '|', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> allOperators = new List<string>();
            foreach (string s in originOperators)
            {
                if (s.Trim().StartsWith(".") || string.IsNullOrEmpty(s.Trim()))
                {
                    continue;
                }
                else
                {
                    allOperators.Add(s.Trim());
                }
            }
            _AllOperators = new List<Operator>();
            foreach (string s in allOperators)
            {
                string[] op = s.Split(',');
                for (int i = 1; i < op.Length; i++)
                {
                    if (string.IsNullOrEmpty(op[i]))
                    {
                        op[i] = "0";
                    }
                }
                op[2] = Convert.ToInt32(op[2], 16).ToString();
                try
                {
                    if (op.Length == 3)
                    {
                        _AllOperators.Add(new Operator(op[0], int.Parse(op[1]), int.Parse(op[2])));
                    }
                    else
                    {
                        _AllOperators.Add(new Operator(op[0], int.Parse(op[1]), int.Parse(op[2]), int.Parse(op[3])));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Operator file format error!");
                }
            }
        }

        public bool IsExist(string mnemonic)
        {
            string s = mnemonic.TrimStart('+');
            foreach (Operator o in _AllOperators)
            {
                if (o.Mnemonic == s)
                {
                    return true;
                }
            }
            return false;
        }

        public Operator Search(string mnemonic)
        {
            string s = mnemonic.TrimStart('+');
            foreach (Operator o in _AllOperators)
            {
                if (o.Mnemonic == s)
                {
                    Operator outo = new Operator(o.Mnemonic, o.Format, o.Opcode, o.Operand);
                    if (s != mnemonic)  //Format 4
                    {
                        outo.isFormat4();
                    }
                    return outo;
                }
            }
            throw new Exception("Operator does not exist!");
        }
    }
}
