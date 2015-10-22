using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class CommonParamTerminalExpression : IAbstractExpression
    {
        private string _nameCommonParameter;
        private string _commonParameterValue;

        public CommonParamTerminalExpression(string nameCommonParameter, string value)
        {
            this.NameCommonParameter = nameCommonParameter;
            this.CommonParameterValue = value;
        }

        public string NameCommonParameter
        {
            get { return this._nameCommonParameter; }
            set { this._nameCommonParameter = value; }
        }

        public string CommonParameterValue
        {
            get { return this._commonParameterValue; }
            set { this._commonParameterValue = value; }
        }

        public void Interpret()
        {
        }
    }
}
