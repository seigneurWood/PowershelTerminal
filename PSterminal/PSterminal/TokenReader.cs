using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class TokenReader
    {
        public void CheckVerbExpression(List<string> tokenList)
        {
        }

        public IAbstractExpression ReadToken(List<string> tokenList)
        {
            return ReadNextToken(tokenList);
        }

        private IAbstractExpression ReadNextToken(List<string> tokenList)
        {
            return new VerbScriptCommandExpression("get");
        }

    }
}
