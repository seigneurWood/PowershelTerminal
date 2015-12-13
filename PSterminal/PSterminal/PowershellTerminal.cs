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

        public PowershellSyntaxHighlight PowershellHighlight
        {
            get
            {
                return _powershellHighlight;
            }

            set
            {
                _powershellHighlight = value;
            }
        }

        private PowershellSyntaxHighlight _powershellHighlight;

        public PowershellTerminal(FlowDocument richBox)
        {
            PowershellHighlight = new PowershellSyntaxHighlight(richBox);
        }

        //private PowershellSyntaxHighlight CreateSyntaxHighlight(FlowDocument richBox)
        //{
        //    return new PowershellSyntaxHighlight(richBox);
        //}
    }
}
