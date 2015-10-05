using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ParamTerminalExpression:IAbstractExpression
    {
        private string _nameParam;

        public string NameParam
        {
            get { return _nameParam; }
            set { _nameParam = value; }
        }
        private string _paramValue;

        public string ParamValue
        {
            get { return _paramValue; }
            set { _paramValue = value; }
        }
        public ParamTerminalExpression(string paramName, string paramValue)
        {
            NameParam = paramName;
            ParamValue = paramValue;
        }
        public void Interpret()
        {
        }
    }
}
