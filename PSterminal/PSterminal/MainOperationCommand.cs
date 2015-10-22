using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class MainOperationCommand : Command
    {
        private static Dictionary<MainComTerminalExpression, object> dictionary = new Dictionary<MainComTerminalExpression, object>();
        private static List<MainComTerminalExpression> listExp = new List<MainComTerminalExpression>();

        private MainComTerminalExpression _terminalCommand;

        public MainOperationCommand(MainComTerminalExpression mainCom)
        {
            //TerminalCommand = mainCom;
            FillList();
            for (int i = 0; i < ListExp.Count; i++)
            {
                if (ListExp.ElementAt(i).Noun == mainCom.Noun && ListExp.ElementAt(i).Verb == mainCom.Verb)
                {
                    this.TerminalCommand = mainCom;
                }
                else
                {
                    this.TerminalCommand = null;
                }
            }
        }

        public static List<MainComTerminalExpression> ListExp
        {
            get { return MainOperationCommand.listExp; }
            set { MainOperationCommand.listExp = value; }
        }

        public static Dictionary<MainComTerminalExpression, object> Dictionary
        {
            get { return MainOperationCommand.dictionary; }
            set { MainOperationCommand.dictionary = value; }
        }

        public MainComTerminalExpression TerminalCommand
        {
            get { return this._terminalCommand; }
            set { this._terminalCommand = value; }
        }

        public static void FillList()
        {
            TokenReader t = new TokenReader(0, 0, "get", -10);
            TokenReader t2 = new TokenReader(0, 0, "process", -10);
            List<TokenReader> tokList = new List<TokenReader>();
            tokList.Add(t);
            tokList.Add(t2);
            Parser parser = new Parser(tokList);
            MainComTerminalExpression mainCom = new MainComTerminalExpression(parser);
            ListExp.Add(mainCom);
        }

        public static void FillDict()
        {
            Dictionary.Add(ListExp.ElementAt(0), Process.GetProcesses());
        }

        public override void Excute()
        {
            for (int i = 0; i < Dictionary.Count; i++)
            {
                if (this.TerminalCommand == Dictionary.ElementAt(i).Key)
                {
                    object[] exucute = ExcuteCommand(Dictionary[Dictionary.ElementAt(i).Key]);
                }
            }
        }

        public bool IsCorrect()
        {
            return true;
        }

        private object[] ExcuteCommand(object objectForExcute)
        {
            if (objectForExcute == Process.GetProcesses())
            {
                return Process.GetProcesses();
            }

            return null;
        }
    }
}
