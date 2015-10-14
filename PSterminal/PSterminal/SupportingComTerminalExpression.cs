using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class SupportingComTerminalExpression: IAbstractExpression
    {
        private Parser _supportCommand;

        public Parser SupportCommand
        {
            get { return _supportCommand; }
            set { _supportCommand = value; }
        }

        public SupportingComTerminalExpression(Parser parser)
        {
            SupportCommand = parser;
        }
        public void Interpret()
        { }
    }
}
