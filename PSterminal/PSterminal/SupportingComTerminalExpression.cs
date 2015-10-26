using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class SupportingComTerminalExpression : IAbstractExpression
    {
        private List<TokenReader> _tokenList;

        public SupportingComTerminalExpression(List<TokenReader> currentTokenList)
        {
            this.TokenList = currentTokenList;
        }

        public List<TokenReader> TokenList
        {
            get { return _tokenList;}
            set { _tokenList = value;}
        }

        public void Interpret()
        { 
        }
    }
}
