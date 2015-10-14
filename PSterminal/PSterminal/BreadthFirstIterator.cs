using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class BreadthFirstIterator: ParserIterator
    {
        private Queue<Parser> _queue;

        public Queue<Parser> Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        private bool _NullParser;

        public bool NullParser
        {
            get { return _NullParser; }
            set { _NullParser = value; }
        }

        public BreadthFirstIterator(Parser parser)
        {
            CurrentParser = parser;

            if (CurrentParser == null)
                return;

            NullParser = false;
            Queue = new Queue<Parser>();
            Index = 0;
            Queue.Enqueue(CurrentParser);
            while (Queue.Count > 0)
            {
                if (CurrentParser.Left != null)
                {
                    Queue.Enqueue(CurrentParser.Left);
                    Index++;
                }
                if (CurrentParser.Right != null)
                {
                    Queue.Enqueue(CurrentParser.Right);
                    Index++;
                }
                if (CurrentParser.Left == null && CurrentParser.Right == null)
                {
                    NullParser = true;
                }
                if (NullParser == true)
                    break;
            }
        }

        private void Next()
        {
            Index++;
        }
    }
}
