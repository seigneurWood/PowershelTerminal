using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class VerbScriptCommandExpression: IAbstractExpression
    {
        private static List<string> VerbList = new List<string>();
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public VerbScriptCommandExpression(string name)
        {
            //FillList();
            Name = name;
        }
        public void FillList()
        {
            VerbList.Add("add");
            VerbList.Add("get");
            VerbList.Add("set");
            VerbList.Add("enable");
            VerbList.Add("disable");
            VerbList.Add("clear");
        }
        public void Interpret()
        {
        }
    }
}
