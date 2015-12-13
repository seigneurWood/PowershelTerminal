using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class CommandCollection: Command
    {
        private  ScriptComNonterminalExpression _scriptCommand;

        public CommandCollection(ScriptComNonterminalExpression script)
        {
            ScriptCommand = script;
        }

        public override string Excute(MainComTerminalExpression command, string outputMass)
        {
            BreadthFirstIterator iterator = new BreadthFirstIterator(this.ScriptCommand);
            StringBuilder sb = new StringBuilder(outputMass);
            //object[] outputMass = null;
            while (iterator.List.Count != 0)
            {
                if (!Char.IsUpper(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Noun.Name[0]) && !Char.IsUpper(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Verb.Name[0]))
                {
                    char.ToUpper(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Noun.Name[0]);
                    char.ToUpper(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Verb.Name[0]);
                }
                StringBuilder str = new StringBuilder(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Noun.Name);
                str.Append(((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1)).Verb.Name);
                string nameCommand = str.ToString();
                Type T = Type.GetType("PSterminal." + nameCommand+"Command");
                object Obj = Activator.CreateInstance(T);
                outputMass = ((Command)Obj).Excute((MainComTerminalExpression)iterator.List.ElementAt(iterator.List.Count - 1),outputMass);
                iterator.List.RemoveAt(iterator.List.Count - 1);
                sb.Append("\n\n");
                sb.Append(outputMass);
            }
            return sb.ToString();
        }

        public ScriptComNonterminalExpression ScriptCommand
        {
            get
            {
                return _scriptCommand;
            }

            set
            {
                _scriptCommand = value;
            }
        }
    }
}
