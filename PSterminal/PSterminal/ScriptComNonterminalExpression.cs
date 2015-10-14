using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class ScriptComNonterminalExpression: IAbstractExpression
    {
        private IAbstractExpression _expressionLeft;

        public IAbstractExpression ExpressionLeft
        {
            get { return _expressionLeft; }
            set { _expressionLeft = value; }
        }

        private IAbstractExpression _expressionRight;

        public IAbstractExpression ExpressionRight
        {
            get { return _expressionRight; }
            set { _expressionRight = value; }
        }

        private DelimiterTerminalExpression _delimeter;

        public DelimiterTerminalExpression Delimeter
        {
            get { return _delimeter; }
            set { _delimeter = value; }
        }

        private Parser _parser;

        public Parser Parser
        {
            get { return _parser; }
            set { _parser = value; }
        }


        public void Interpret()
        {  
        }

        public ScriptComNonterminalExpression(Parser parser)
        {
            Parser = parser;
        }

        public void CreateSyntaxTree()
        {
            CreateNextSyntaxTree(this.Parser);
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
                        break;
                }

                //this.ExpressionRight = new SupportingComTerminalExpression();
                //this.Delimeter = new DelimiterTerminalExpression();
                //this.ExpressionLeft = new ScriptComNonterminalExpression();
            }
        }
    }
}
