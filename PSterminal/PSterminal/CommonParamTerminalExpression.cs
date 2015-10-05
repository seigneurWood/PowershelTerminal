using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class CommonParamTerminalExpression: IAbstractExpression
    {
        private string _nameCommonParameter;

        public string NameCommonParameter
        {
            get { return _nameCommonParameter; }
            set { _nameCommonParameter = value; }
        }
        private string _commonParameterValue;

        public string CommonParameterValue
        {
            get { return _commonParameterValue; }
            set { _commonParameterValue = value; }
        }
        public CommonParamTerminalExpression(string nameCommonParameter, string value)
        {
            NameCommonParameter = nameCommonParameter;
            CommonParameterValue = value;
        }

        public void Interpret()
        {
        }
    }
}
