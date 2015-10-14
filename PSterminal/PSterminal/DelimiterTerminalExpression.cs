using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class DelimiterTerminalExpression: IAbstractExpression
    {
        private string _delimiter;

        public string Delimiter
        {
            get { return _delimiter; }
            set { _delimiter = value; }
        }

        public DelimiterTerminalExpression()
        {
            Delimiter = "|";
        }

        public void Interpret()
        {
        }
    }
}
