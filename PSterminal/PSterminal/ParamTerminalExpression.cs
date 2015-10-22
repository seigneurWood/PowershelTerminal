using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ParamTerminalExpression : IAbstractExpression
    {
        private string _nameParam;
        private string _paramValue;

        public ParamTerminalExpression(string paramName, string paramValue)
        {
            this.NameParam = paramName;
            this.ParamValue = paramValue;
        }

        public string NameParam
        {
            get { return this._nameParam; }
            set { this._nameParam = value; }
        }

        public string ParamValue
        {
            get { return this._paramValue; }
            set { this._paramValue = value; }
        }

        public void Interpret()
        {
        }
    }
}
