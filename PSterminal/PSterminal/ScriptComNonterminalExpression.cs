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
            while (currentParser.Left != null)
            {
                Parser tempParser = parserIterator.Queue.Dequeue();
                if (parserIterator.Queue.Count != 1)
                {
                    this.ExpressionLeft = new ScriptComNonterminalExpression(tempParser);
                    this.Delimeter = new DelimiterTerminalExpression();
                    this.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
                }
                else
                {
                    this.ExpressionLeft = new MainComTerminalExpression(tempParser);
                    this.Delimeter = null;
                    this.ExpressionRight = new SupportingComTerminalExpression(parserIterator.Queue.Dequeue());
                }
                if (currentParser.Left == tempParser)
                    currentParser = currentParser.Left;
                //this.ExpressionRight = new SupportingComTerminalExpression();
                //this.Delimeter = new DelimiterTerminalExpression();
                //this.ExpressionLeft = new ScriptComNonterminalExpression();
            }
        }
    }
}
