using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PSterminal
{
    public class MainOperationCommand: Command
    {
        static public Dictionary<MainComTerminalExpression, object> dictionary = new Dictionary<MainComTerminalExpression, object>();
        static public List<MainComTerminalExpression> listExp = new List<MainComTerminalExpression>();

        private MainComTerminalExpression _terminalCommand;

        public MainComTerminalExpression TerminalCommand
        {
            get { return _terminalCommand; }
            set { _terminalCommand = value; }
        }

        public MainOperationCommand(MainComTerminalExpression mainCom)
        {
            //TerminalCommand = mainCom;
            FillList();
            for (int i = 0; i < listExp.Count; i++)
            {
                if(listExp.ElementAt(i).Noun == mainCom.Noun && listExp.ElementAt(i).Verb == mainCom.Verb)
                    TerminalCommand = mainCom;
                else
                    TerminalCommand = null;
            }
        }

        public override void Excute()
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                if (this.TerminalCommand == dictionary.ElementAt(i).Key)
                {
                    object[] exucute = ExcuteCommand(dictionary[dictionary.ElementAt(i).Key]);
                }
            }
        }

        public bool IsCorrect()
        {
            return true;
        }

        static public void FillList()
        {
            TokenReader t = new TokenReader(0, 0, "get", -10);
            TokenReader t2 = new TokenReader(0, 0, "process", -10);
            List<TokenReader> tList = new List<TokenReader>();
            tList.Add(t);
            tList.Add(t2);
            Parser parser = new Parser(tList);
            MainComTerminalExpression mainCom = new MainComTerminalExpression(parser);
            listExp.Add(mainCom);
        }

        static public void FillDict()
        {
            dictionary.Add(listExp.ElementAt(0), Process.GetProcesses());
        }

        private object[] ExcuteCommand(object objectForExcute)
        {
            if (objectForExcute == Process.GetProcesses())
                return Process.GetProcesses();
            return null;
        }
    }
}
