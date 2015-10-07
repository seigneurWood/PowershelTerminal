using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ScriptComNonterminalExpression: IAbstractExpression
    {
        private IAbstractExpression _exp1;

        public IAbstractExpression Exp1
        {
            get { return _exp1; }
            set { _exp1 = value; }
        }
        private IAbstractExpression _exp2;

        public IAbstractExpression Exp2
        {
            get { return _exp2; }
            set { _exp2 = value; }
        }
        public ScriptComNonterminalExpression(IAbstractExpression exp1, IAbstractExpression exp2)
        {
            Exp1 = exp1;
            Exp2 = exp2;
        }
        public void Interpret()
        {
            string str = Exp1.ToString() + Exp2.ToString();
            
        }
    }
}
