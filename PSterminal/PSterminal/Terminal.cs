using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PSterminal
{
    public class Terminal
    {
        private string _script;

        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }

        public void TypeScript(char curChar)
        {
            Command command = new CommandType(Script, curChar);
            command.Execute();
            UndoRedoCommand._Undocommands.Push(command);
        }
    }
}
