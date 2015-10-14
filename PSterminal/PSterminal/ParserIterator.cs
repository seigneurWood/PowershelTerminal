using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public abstract class ParserIterator
    {
        private Parser _currentParser;

        public Parser CurrentParser { get; protected set; }

        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private bool _isDone;

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
