using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class ASCII
    {
        private class ASCIICharacter
        {
            public string Hex { get; set; }
            public string Character { get; set; }

            public ASCIICharacter(string hex, string character)
            {
                Hex = hex;
                Character = character;
            }
        }

        private List<ASCIICharacter> _AllASCII;

        public ASCII() : this(new StreamReader("ASCII.dat")) { }
        public ASCII(StreamReader sr)
        {
            string file = sr.ReadToEnd();
            string[] originASCIIs = file.Trim().Split(new char[2] { '\n', '|' }, StringSplitOptions.RemoveEmptyEntries);
            _AllASCII = new List<ASCIICharacter>();
            List<ASCIICharacter> temp = new List<ASCIICharacter>();
            int max = 0;
            foreach (string s in originASCIIs)
            {
                string[] asc = s.Trim().Split(',');
                temp.Add(new ASCIICharacter(asc[1], asc[0]));
                if (asc[0].Length > max)
                {
                    max = asc[0].Length;
                }
            }
            for (; max >= 1; max--)
            {
                foreach (ASCIICharacter c in temp)
                {
                    if (c.Character.Length == max)
                    {
                        _AllASCII.Add(c);
                    }
                }
            }
        }

        public string Hex(string str)
        {
            string temp = "";
            int i = 0, max = str.Length;
            while (i < max)
            {
                foreach (ASCIICharacter c in _AllASCII)
                {
                    if (str.StartsWith(c.Character))
                    {
                        temp += c.Hex;
                        str = str.Substring(c.Character.Length);
                        i += c.Character.Length;
                        break;
                    }
                }
            }
            return temp;
        }
    }
}
