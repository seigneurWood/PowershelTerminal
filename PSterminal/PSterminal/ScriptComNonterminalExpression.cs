using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ScriptComNonterminalExpression : IAbstractExpression // Parser
    {
        private IAbstractExpression _expressionLeft;
        private IAbstractExpression _expressionRight;
        private DelimiterTerminalExpression _delimeter;
        private List<TokenReader> _tokenList;

        public ScriptComNonterminalExpression(List<TokenReader> tokenList)
        {
            this.TokenList = tokenList;
        }

        public IAbstractExpression ExpressionLeft
        {
            get { return this._expressionLeft; }
            set { this._expressionLeft = value; }
        }

        public IAbstractExpression ExpressionRight
        {
            get { return this._expressionRight; }
            set { this._expressionRight = value; }
        }

        public DelimiterTerminalExpression Delimeter
        {
            get { return this._delimeter; }
            set { this._delimeter = value; }
        }

        public List<TokenReader> TokenList
        {
            get { return _tokenList;}
            set { _tokenList = value;}
        }

        public void Interpret()
        {  
        }

        public void CreateSyntaxTree()
        {
            this.CreateNextSyntaxTree(this.TokenList);
        }

        private void CreateNextSyntaxTree(List<TokenReader> currentTokenList)
        {
            List<TokenReader> currentListRight = new List<TokenReader>();
            for (int i = currentTokenList.Count - 1; i >= 0; i--)
            {
                if (currentTokenList.ElementAt(i).Token == "|")
                {
                    this.Delimeter = new DelimiterTerminalExpression();
                    this.ExpressionLeft = new ScriptComNonterminalExpression(currentTokenList.Take(i - 1).ToList<TokenReader>()); //new Parser(currentTokenList.Take(i - 1).ToList<TokenReader>());
                    Type type = typeof(ScriptComNonterminalExpression);
                    if (this.ExpressionLeft.GetType() == type)
                    {
                        //ExpressionLeft.CreateNextTree(this.ExpressionLeft.TokenList);
                        ((ScriptComNonterminalExpression)this.ExpressionLeft).CreateNextSyntaxTree(((ScriptComNonterminalExpression)this.ExpressionLeft).TokenList);
                    }
                    //this.ExpressionLeft.
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
                this.ExpressionRight = new SupportingComTerminalExpression(currentListRight);
            }

            #region //
            //int index = 0;
            //BreadthFirstIterator parserIterator = new BreadthFirstIterator(currentParser);
            //parserIterator.Queue.Dequeue();

            //ScriptComNonterminalExpression currentCommand = this;
            //while (currentParser.Left != null)
            //{
            //    Parser tempParser = parserIterator.Queue.Dequeue();
            //    if (parserIterator.Queue.Count != 1)
            //    {
            //        currentCommand.ExpressionLeft = new ScriptComNonterminalExpression(tempParser);
            //        currentCommand.Delimeter = new DelimiterTerminalExpression();
            //        currentCommand.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
            //    }
            //    else
            //    {
            //        currentCommand.ExpressionLeft = new MainComTerminalExpression(tempParser);
            //        currentCommand.Delimeter = null;
            //        currentCommand.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
            //    }

            //    if (currentParser.Left == tempParser)
            //    {
            //        currentParser = currentParser.Left;
            //        if (currentParser.Left != null)
            //        {
            //            currentCommand = (ScriptComNonterminalExpression)currentCommand.ExpressionLeft;
            //            currentCommand.CreateNextSyntaxTree(currentParser);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //this.ExpressionRight = new SupportingComTerminalExpression();
            //this.Delimeter = new DelimiterTerminalExpression();
            //this.ExpressionLeft = new ScriptComNonterminalExpression();
            //}
            #endregion
        }
    }
}
