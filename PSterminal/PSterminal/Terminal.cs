using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PSterminal
{
    public class Terminal
    {
        private string _script;

        public string Script
        {
            get { return this._script; }
            set { this._script = value; }
        }
    }
}
