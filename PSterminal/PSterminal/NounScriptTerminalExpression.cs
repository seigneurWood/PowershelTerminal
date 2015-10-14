using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class NounScriptTerminalExpression: IAbstractExpression
    {
        private static List<string> NounList = new List<string>();
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public void FillList()
        {
            NounList.Add("process");
            NounList.Add("history");
            NounList.Add("date");
            NounList.Add("childitem");
            NounList.Add("location");
        }

        public NounScriptTerminalExpression(string name)
        {
            Name = name;
        }

        public void Interpret()
        {
        }
    }
}
