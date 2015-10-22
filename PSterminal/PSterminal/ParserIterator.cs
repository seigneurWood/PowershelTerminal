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
        private int _index;
        private bool _isDone;

        public Parser CurrentParser
        {
            get { return this._currentParser; }
            protected set { this._currentParser = value; }
        }

        public int Index
        {
            get { return this._index; }
            set { this._index = value; }
        }

        public bool IsDone
        {
            get { return this._isDone; }
            set { this._isDone = value; }
        }
    }
}
