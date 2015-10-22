using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ScriptComNonterminalExpression : IAbstractExpression
    {
        private IAbstractExpression _expressionLeft;
        private IAbstractExpression _expressionRight;
        private DelimiterTerminalExpression _delimeter;
        private Parser _parser;

        public ScriptComNonterminalExpression(Parser parser)
        {
            this.Parser = parser;
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

        public Parser Parser
        {
            get { return this._parser; }
            set { this._parser = value; }
        }

        public void Interpret()
        {  
        }

        public void CreateSyntaxTree()
        {
            this.CreateNextSyntaxTree(this.Parser);
        }

        private void CreateNextSyntaxTree(Parser currentParser)
        {
            //int index = 0;
            BreadthFirstIterator parserIterator = new BreadthFirstIterator(currentParser);
            parserIterator.Queue.Dequeue();

            ScriptComNonterminalExpression currentCommand = this;
            while (currentParser.Left != null)
            {
                Parser tempParser = parserIterator.Queue.Dequeue();
                if (parserIterator.Queue.Count != 1)
                {
                    currentCommand.ExpressionLeft = new ScriptComNonterminalExpression(tempParser);
                    currentCommand.Delimeter = new DelimiterTerminalExpression();
                    currentCommand.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
                }
                else
                {
                    currentCommand.ExpressionLeft = new MainComTerminalExpression(tempParser);
                    currentCommand.Delimeter = null;
                    currentCommand.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
                }

                if (currentParser.Left == tempParser)
                {
                    currentParser = currentParser.Left;
                    if (currentParser.Left != null)
                    {
                        currentCommand = (ScriptComNonterminalExpression)currentCommand.ExpressionLeft;
                        currentCommand.CreateNextSyntaxTree(currentParser);
                    }
                    else
                    {
                        break;
                    }
                }

                //this.ExpressionRight = new SupportingComTerminalExpression();
                //this.Delimeter = new DelimiterTerminalExpression();
                //this.ExpressionLeft = new ScriptComNonterminalExpression();
            }
        }
    }
}
