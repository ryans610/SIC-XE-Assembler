using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class Symbol
    {
        private int _Loc;
        private string _Name;

        public int Loc { get { return _Loc; } }
        public string Name { get { return _Name; } }

        public Symbol() { }
        public Symbol(int loc, string name)
        {
            _Loc = loc;
            _Name = name;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", Name, Convert.ToString(Loc, 16).ToUpper().PadLeft(4, '0'));
        }
    }
    public class SymbolTable
    {
        private List<Symbol> SymTab;

        public SymbolTable()
        {
            SymTab = new List<Symbol>();
        }

        public void Add(Symbol s)
        {
            SymTab.Add(s);
        }

        public int Loc(string name)
        {
            foreach (Symbol s in SymTab)
            {
                if (s.Name == name)
                {
                    return s.Loc;
                }
            }
            return -1;
        }

        public void Write(StreamWriter sw)
        {
            sw.WriteLine("Symbol Table:");
            sw.WriteLine("Format:(SymbolName,SymbolLocation)");
            foreach (Symbol s in SymTab)
            {
                sw.WriteLine(s.ToString());
            }
            sw.WriteLine("End of Symbol Table.");
        }
    }
}
