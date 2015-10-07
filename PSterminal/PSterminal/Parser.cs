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

        public void CreateTree()
        {
            CreateNextTree(this.TokenList);
        }

        private void CreateNextTree(List<TokenReader> currentTokenList)
        {
            List<TokenReader> currentListRight = new List<TokenReader>();
            for (int i = currentTokenList.Count-1; i >= 0; i--)
            {
                if (currentTokenList.ElementAt(i).Token == "|")
                {
                    //currentTokenList.Reverse();
                    this.Left = new Parser(currentTokenList.Take(i-1).ToList<TokenReader>());
                    this.Left.CreateNextTree(this.Left.TokenList);
                    //continue;
                    break;
                    //IEnumerable<TokenReader> t = currentTokenList.Take(i);
                    //return new Parser(t.ToList<TokenReader>());
                    //this.Right = new Parser(t.ToList<TokenReader>());

                    //currentListRight.AddRange(this.TokenList.Take(i));
                    //this.TokenList.RemoveRange(i, this.TokenList.Count - i);
                }
                else
                {
                    currentListRight.Add(this.TokenList.ElementAt(i));
                }
            }
            currentListRight.Reverse();
            if (currentListRight.Count != this.TokenList.Count)
            {
                //if /*(currentTokenList.Count != this.TokenList.Count &&*/ (IsCopy(currentTokenList,this.TokenList)== false)
                    this.Right = new Parser(currentListRight);
            }

            //List<TokenReader> currentListLeft = new List<TokenReader>();
            //List<TokenReader> currentListRight = new List<TokenReader>();
            //this.Left = new Parser(new List<TokenReader>());
            //this.Right = new Parser(new List<TokenReader>());
            //for (int i = this.TokenList.Count; i >= 0; i--)
            //{
            //    if (this.TokenList.ElementAt(i).Token == "|")
            //    {
            //        currentListRight.AddRange(this.TokenList.Take(i));
            //        //this.TokenList.RemoveRange(i, this.TokenList.Count - i);
            //    }
            //    else
            //    {
            //        currentListLeft.Add(this.TokenList.ElementAt(i));
            //    }
            //}
        }
        private bool IsCopy(List<TokenReader> tokenList1, List<TokenReader> tokenList2)
        {
            for (int i = 0; i < tokenList2.Count; i++)
            {
                if (tokenList1.ElementAt(i) != tokenList2.ElementAt(i))// && tokenList1.Count != tokenList2.Count)
                    return false;
            }
            return true;
        }
    }
}
