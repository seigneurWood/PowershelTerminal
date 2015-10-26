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
        private int _state;

        private static List<string> supportComList = new List<string>();

        public SupportingComTerminalExpression(List<TokenReader> tokenList)
        {
            FillSupportComList();
            this.TokenList = tokenList;
            for (int i = 0; i < tokenList.Count; i++)
            {
                for(int j = 0; j < supportComList.Count; j++)
                {
                    if(tokenList.ElementAt(i).Token==supportComList.ElementAt(j))
                    {
                        State = 1;
                    }
                    else
                    {
                        State = 0;
                    }
                }
        }

        public List<TokenReader> TokenList
        {
            get { return this._tokenList; }
            set { this._tokenList = value; }
        }

        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Interpret()
        { 
        }

        private void FillSupportComList()
        {
            SupportComList.Add("sort-object");
        }
    }
}
