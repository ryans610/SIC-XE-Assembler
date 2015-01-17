using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Registers
    {
        private class Register
        {
            public string Mnemonic { get; set; }
            public int Number { get; set; }
            public Register(string mn, int nu)
            {
                Mnemonic = mn;
                Number = nu;
            }
        }

        private static Register[] _Registers = new Register[9]{
            new Register("A",0),
            new Register("X",1),
            new Register("L",2),
            new Register("PC",8),
            new Register("SW",9),
            new Register("B",3),
            new Register("S",4),
            new Register("T",5),
            new Register("F",6)
        };

        public static int RegisterNumber(string mnemonic)
        {
            for (int i = 0; i < _Registers.Length; i++)
            {
                if (_Registers[i].Mnemonic == mnemonic)
                {
                    return _Registers[i].Number;
                }
            }
            throw new Exception("Register does not exist!");
        }
    }
}
