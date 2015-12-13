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
        private CmdSyntaxHighlight _cmdHighlight;

        public string Script
        {
            get { return this._script; }
            set { this._script = value; }
        }

        public CmdSyntaxHighlight CmdHighlight
        {
            get
            {
                return _cmdHighlight;
            }

            set
            {
                _cmdHighlight = value;
            }
        }

        public CmdTerminal(FlowDocument document)
        {
            CmdHighlight = new CmdSyntaxHighlight(document);
        }

        //public CmdSyntaxHighlight CreateSyntaxHighlight(FlowDocument document)
        //{
        //     return new CmdSyntaxHighlight(document);
        //}
    }
}
