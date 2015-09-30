using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class UndoRedoCommand
    {
        static public Stack<Command> _Undocommands;
        static public Stack<Command> _Redocommands;

        public void Redo(int levels)
        {
            for (int i = 1; i <= levels; i++)
            {
                if (_Redocommands.Count != 0)
                {
                    Command command = _Redocommands.Pop();
                    command.Execute();
                    _Undocommands.Push(command);
                }

            }
        }

        public void Undo(int levels)
        {
            for (int i = 1; i <= levels; i++)
            {
                if (_Undocommands.Count != 0)
                {
                    Command command = _Undocommands.Pop();
                    command.UnExecute();
                    _Redocommands.Push(command);
                }

            }
        }
    }
}
