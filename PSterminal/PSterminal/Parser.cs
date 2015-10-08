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
                    this.Left = new Parser(currentTokenList.Take(i-1).ToList<TokenReader>());
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
                    return false;
            }
            return true;
        }

        public void CheckError()
        {
            var queue = new Queue<Parser>();
            queue.Enqueue(this);
            Parser currentParser = new Parser(this.TokenList);
            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null)
                {
                    //if (detailed) s += "    заносим в очередь значение " + queue.Peek().Left.Value.ToString() + " из левого поддерева" + Environment.NewLine;
                    queue.Enqueue(queue.Peek().Left);
                    currentParser = queue.Peek().Left;
                }
                if (queue.Peek().Right != null)
                {
                    //if (detailed) s += "    заносим в очередь значение " + queue.Peek().Right.Value.ToString() + " из правого поддерева" + Environment.NewLine;
                    queue.Enqueue(queue.Peek().Right);
                }
            }
           // IAbstractExpression scriptCommand = new ScriptComNonterminalExpression();
           // scriptCommand.Interpret();
        }


    }
}
