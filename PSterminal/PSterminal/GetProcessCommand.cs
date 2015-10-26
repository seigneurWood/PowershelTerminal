using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class GetProcessCommand:Command
    {
        public override object[] Excute(ScriptComNonterminalExpression script)
        {
            BreadthFirstIterator iterator = new BreadthFirstIterator(script);
            for (int i = 0; i < iterator.Queue.Count; i++)
            {
                
            }
            return new object[1];
        }
    }
}
