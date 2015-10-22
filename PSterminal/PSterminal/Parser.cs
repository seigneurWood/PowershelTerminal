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
        private Parser _left;
        private Parser _right;

        public Parser(List<TokenReader> token)
        {
            this.TokenList = token;
        }

        public List<TokenReader> TokenList
        {
            get { return this._tokenList; }
            set { this._tokenList = value; }
        }

        public Parser Right
        {
            get { return this._right; }
            set { this._right = value; }
        }

        public Parser Left
        {
            get { return this._left; }
            set { this._left = value; }
        }

        public void CreateTree()
        {
            this.CreateNextTree(this.TokenList);
        }

        public void CheckError()
        {
            BreadthFirstIterator iterator = new BreadthFirstIterator(this);

            //var queue = new Queue<Parser>();
            //queue.Enqueue(this);
            //Parser currentParser = this;
            //int current_level = 0;
            //while (true)
            //{
            //    if (currentParser.Right != null)
            //    {
            //        //if (detailed) s += "    заносим в очередь значение " + queue.Peek().Right.Value.ToString() + " из правого поддерева" + Environment.NewLine;
            //        queue.Enqueue(currentParser.Right);
            //    }
            //    if (currentParser.Left != null)
            //    {
            //        //if (detailed) s += "    заносим в очередь значение " + queue.Peek().Left.Value.ToString() + " из левого поддерева" + Environment.NewLine;
            //        queue.Enqueue(currentParser.Left);

            //        current_level++;
            //    }
            //    if (currentParser.Left == null && currentParser.Right == null) { break; }
            //    currentParser = currentParser.Left;
            //}

           // IAbstractExpression scriptCommand = new ScriptComNonterminalExpression();
           // scriptCommand.Interpret();
        }

        private void CreateNextTree(List<TokenReader> currentTokenList)
        {
            List<TokenReader> currentListRight = new List<TokenReader>();
            for (int i = currentTokenList.Count - 1; i >= 0; i--)
            {
                if (currentTokenList.ElementAt(i).Token == "|")
                {
                    this.Left = new Parser(currentTokenList.Take(i - 1).ToList<TokenReader>());
                    this.Left.CreateNextTree(this.Left.TokenList);
                    break;
                }
                else
                {
                    currentListRight.Add(this.TokenList.ElementAt(i));
                }
            }

            currentListRight.Reverse();
            if (currentListRight.Count != this.TokenList.Count)
            {
                this.Right = new Parser(currentListRight);
            }
        }

        private bool IsCopy(List<TokenReader> tokenList1, List<TokenReader> tokenList2)
        {
            for (int i = 0; i < tokenList2.Count; i++)
            {
                if (tokenList1.ElementAt(i) != tokenList2.ElementAt(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
