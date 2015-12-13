using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public abstract class Command
    {
        //public abstract void Excute();
        public abstract string Excute(MainComTerminalExpression command,string massObject);
    }
}
