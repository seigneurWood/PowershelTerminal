using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class Parser
    {
        private List<TokenReader> _tokenList;

        public List<TokenReader> TokenList
        {
            get { return _tokenList; }
            set { _tokenList = value; }
        }

        private Parser _right;

        public Parser Right
        {
            get { return _right; }
            set { _right = value; }
        }
        private Parser _left;

        public Parser Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Parser(List<TokenReader> token)
        {
            TokenList = token;
        }

        
    }
}
