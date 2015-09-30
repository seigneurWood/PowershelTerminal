using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class CommandType: Command
    {
        private string curString;
        private char inputChar;

        public CommandType(string currentString,char input)
        {
            curString = currentString;
            inputChar = input;
        }

        public override void Execute()
        {
            StringBuilder str = new StringBuilder(this.curString);
            str.Append(this.inputChar);
        }
        public override void UnExecute()
        {
            StringBuilder str = new StringBuilder(this.curString);
            str.Remove(this.curString.Length - 1, 1);
        }
    }
}
