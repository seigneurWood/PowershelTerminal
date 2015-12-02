using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PSterminal
{
    public class PowershellTerminal //: Terminal
    {
        private string _script;

        public string Script
        {
            get { return this._script; }
            set { this._script = value; }
        }

        public PowershellSyntaxHighlight CreateSyntaxHighlight(FlowDocument richBox)
        {
            return new PowershellSyntaxHighlight(richBox);
        }
    }
}
