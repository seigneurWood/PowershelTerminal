using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class SupportingComTerminalExpression : IAbstractExpression
    {
        private Parser _supportCommand;

        public SupportingComTerminalExpression(Parser parser)
        {
            this.SupportCommand = parser;
        }

        public Parser SupportCommand
        {
            get { return this._supportCommand; }
            set { this._supportCommand = value; }
        }

        public void Interpret()
        { 
        }
    }
}
