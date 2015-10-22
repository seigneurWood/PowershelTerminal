using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class NounScriptTerminalExpression : IAbstractExpression
    {
        private static List<string> nounList = new List<string>();
        private string _name;

        public NounScriptTerminalExpression(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public void FillList()
        {
            nounList.Add("process");
            nounList.Add("history");
            nounList.Add("date");
            nounList.Add("childitem");
            nounList.Add("location");
        }

        public void Interpret()
        {
        }
    }
}
