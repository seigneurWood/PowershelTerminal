using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class VerbScriptCommandExpression : IAbstractExpression
    {
        private static List<string> verbList = new List<string>();
        private string _name;

        public VerbScriptCommandExpression(string name)
        {
            //FillList();
            this.Name = name;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public void FillList()
        {
            verbList.Add("add");
            verbList.Add("get");
            verbList.Add("set");
            verbList.Add("enable");
            verbList.Add("disable");
            verbList.Add("clear");
        }

        public void Interpret()
        {
        }
    }
}
