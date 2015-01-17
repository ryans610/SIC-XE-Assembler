using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Statement
    {
        private int _Take;
        private string _Mnemonic;
        private int _Format;    //0 for directive
        private string _Operand;
        private int _OperandCount;
        private int _OperatorCode;
        private int _Location;
        private bool _hasLabel;
        private string _LabelName;

        public int Take { get { return _Take; } }
        public string Mnemonic { get { return _Mnemonic; } }
        public int Format { get { return _Format; } }
        public string Operand { get { return _Operand; } }
        public int OperandCount { get { return _OperandCount; } set { _OperandCount = value; } }
        public int OperatorCode { get { return _OperatorCode; } }
        public int Location { get { return _Location; } }
        public bool hasLabel { get { return _hasLabel; } }
        public string LabelName { get { return _LabelName; } }

        public Statement() { }
        /// <summary>
        /// Operator without Label
        /// </summary>
        public Statement(int take, string mnemonic, int format, string operand, int operandCount, int operatorCode, int location)
        {
            _Take = take;
            _Mnemonic = mnemonic;
            _Format = format;
            _Operand = operand;
            _OperandCount = operandCount;
            _OperatorCode = operatorCode;
            _Location = location;
            _hasLabel = false;
        }
        /// <summary>
        /// Operator with Label
        /// </summary>
        public Statement(int take, string mnemonic, int format, string operand, int operandCount, int operatorCode, int location, string labelName)
        {
            _Take = take;
            _Mnemonic = mnemonic;
            _Format = format;
            _Operand = operand;
            _OperandCount = operandCount;
            _OperatorCode = operatorCode;
            _Location = location;
            _hasLabel = true;
            _LabelName = labelName;
        }
        /// <summary>
        /// Directive without Label
        /// </summary>
        public Statement(string mnemonic, string operand, int location)
        {
            _Take = Directives.Take(mnemonic, operand);
            _Mnemonic = mnemonic;
            _Format = 0;
            _Operand = operand;
            _OperandCount = 1;
            _Location = location;
            _hasLabel = false;
        }
        /// <summary>
        /// Directive with Label
        /// </summary>
        public Statement(string mnemonic, string operand, int location, string labelName)
        {
            _Take = Directives.Take(mnemonic, operand);
            _Mnemonic = mnemonic;
            _Format = 0;
            _Operand = operand;
            _OperandCount = 1;
            _Location = location;
            _hasLabel = true;
            _LabelName = labelName;
        }
    }
}
