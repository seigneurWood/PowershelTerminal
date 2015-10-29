using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class BreadthFirstIterator : ParserIterator
    {
        private Queue<IAbstractExpression> _queue;

        public BreadthFirstIterator(ScriptComNonterminalExpression scriptCommand)
        {
            if (scriptCommand == null)
                return;
            this.Queue = new Queue<IAbstractExpression>();
            //Type type = typeof(ScriptComNonterminalExpression);

            while (this.Queue.Count > -1)
            {
                if (scriptCommand.ExpressionLeft.GetType() != typeof(MainComTerminalExpression))
                {
                    this.Queue.Enqueue((MainComTerminalExpression)scriptCommand.ExpressionRight);
                    scriptCommand = (ScriptComNonterminalExpression)scriptCommand.ExpressionLeft;
                }
                if (scriptCommand.ExpressionLeft.GetType() == typeof(MainComTerminalExpression))
                {
                    this.Queue.Enqueue((MainComTerminalExpression)scriptCommand.ExpressionRight);
                    this.Queue.Enqueue((MainComTerminalExpression)scriptCommand.ExpressionLeft);
                    break;
                }
            }

            //for (; ; )
            //{
            //    if (scriptCommand.ExpressionRight != null && scriptCommand.ExpressionLeft.GetType() != typeof(ScriptComNonterminalExpression)
            //        && scriptCommand.ExpressionRight.GetType() != typeof(SupportingComTerminalExpression))
            //    {
            //        this.Queue.Enqueue(scriptCommand.ExpressionRight);
            //        if (scriptCommand.ExpressionLeft.GetType() != typeof(ScriptComNonterminalExpression))
            //        {
            //            scriptCommand = (ScriptComNonterminalExpression)scriptCommand.ExpressionLeft;
            //        }
            //        else
            //        {
            //            this.Queue.Enqueue(scriptCommand.ExpressionRight);
            //            this.Queue.Enqueue(scriptCommand.ExpressionLeft);
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        this.Queue.Enqueue(scriptCommand.ExpressionRight);
            //        this.Queue.Enqueue(scriptCommand.ExpressionLeft);
            //        break;
            //    }
            //}
        }

        public Queue<IAbstractExpression> Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }


        //private Queue<Parser> _queue;
        //private bool _nullParser;

        //public BreadthFirstIterator(Parser parser)
        //{
        //    this.CurrentParser = parser;

        //    if (this.CurrentParser == null)
        //    {
        //        return;
        //    }

        //    this.NullParser = false;
        //    this.Queue = new Queue<Parser>();
        //    this.Index = 0;
        //    this.Queue.Enqueue(CurrentParser);
        //    while (this.Queue.Count > 0)
        //    {
        //        if (this.CurrentParser.Left != null)
        //        {
        //            this.Queue.Enqueue(CurrentParser.Left);
        //            this.Index++;
        //        }

        //        if (this.CurrentParser.Right != null)
        //        {
        //            this.Queue.Enqueue(CurrentParser.Right);
        //            this.Index++;
        //        }

        //        if (this.CurrentParser.Left == null && CurrentParser.Right == null)
        //        {
        //            this.NullParser = true;
        //        }

        //        if (this.NullParser == true)
        //        {
        //            break;
        //        }

        //        if (this.CurrentParser.Left != null)
        //        {
        //            this.CurrentParser = this.CurrentParser.Left;
        //        }
        //    }
        //}

        //public Queue<Parser> Queue
        //{
        //    get { return this._queue; }
        //    set { this._queue = value; }
        //}

        //public bool NullParser
        //{
        //    get { return this._nullParser; }
        //    set { this._nullParser = value; }
        //}
    }
}
