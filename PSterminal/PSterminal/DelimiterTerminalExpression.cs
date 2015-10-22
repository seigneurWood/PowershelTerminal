using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class DelimiterTerminalExpression : IAbstractExpression
    {
        private string _delimiter;

        public DelimiterTerminalExpression()
        {
            this.Delimiter = "|";
        }

        public string Delimiter
        {
            get { return this._delimiter; }
            set { this._delimiter = value; }
        }

        public void Interpret()
        {
        }
    }
}
