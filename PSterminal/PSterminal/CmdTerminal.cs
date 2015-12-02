using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PSterminal
{
    public class CmdTerminal //: Terminal
    {
        private string _script;

        public string Script
        {
            get { return this._script; }
            set { this._script = value; }
        }

        public CmdSyntaxHighlight CreateSyntaxHighlight(FlowDocument document)
        {
             return new CmdSyntaxHighlight(document);
        }
    }
}
