using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Directives
    {
        private class Directive
        {
            public string Mnemonic { get; set; }
            public int Take { get; set; }
            public Directive(string mne, int tak)
            {
                Mnemonic = mne;
                Take = tak;
            }
        }

        private static Directive[] _Directives = new Directive[7]{
            new Directive("START",0),
            new Directive("END",0),
            new Directive("BYTE",1),
            new Directive("WORD",3),
            new Directive("RESB",1),
            new Directive("RESW",3),
            new Directive("BASE",0)
        };

        public static bool IsDirective(string mnemonic)
        {
            bool b = false;
            for (int i = 0; i < _Directives.Length; i++)
            {
                if (_Directives[i].Mnemonic == mnemonic)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public static int Take(string mnemonic, string operand)
        {
            for (int i = 0; i < _Directives.Length; i++)
            {
                if (_Directives[i].Mnemonic == mnemonic)
                {
                    if (_Directives[i].Take == 0)
                    {
                        return 0;
                    }
                    else if (_Directives[i].Mnemonic == "WORD")
                    {
                        return 3;
                    }
                    else if (_Directives[i].Mnemonic == "RESB")
                    {
                        try
                        {
                            return int.Parse(operand);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Operand is not a number!");
                        }
                    }
                    else if (_Directives[i].Mnemonic == "RESW")
                    {
                        try
                        {
                            return int.Parse(operand) * 3;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Operand is not a number!");
                        }
                    }
                    else if (_Directives[i].Mnemonic == "BYTE")
                    {
                        string[] strs = operand.Trim().Split('\'');
                        if (strs[0] == "C")
                        {
                            return strs[1].Length;
                        }
                        else if (strs[0] == "X")
                        {
                            int j = strs[1].Length / 2;
                            if (strs[1].Length != j * 2)
                            {
                                j++;
                            }
                            return j;
                        }
                        else
                        {
                            throw new Exception("Operand error!");
                        }
                    }
                    break;
                }
            }
            throw new Exception("Directive does not exist!");
        }
    }
}
