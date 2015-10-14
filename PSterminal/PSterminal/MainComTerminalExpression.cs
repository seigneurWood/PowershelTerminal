using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class MainComTerminalExpression: IAbstractExpression
    {
        private NounScriptTerminalExpression _noun;

        public NounScriptTerminalExpression Noun
        {
            get { return _noun; }
            set { _noun = value; }
        }

        private VerbScriptCommandExpression _verb;

        public VerbScriptCommandExpression Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }

        private Parser _mainParser;

        public Parser MainParser
        {
            get { return _mainParser; }
            set { _mainParser = value; }
        }

        public MainComTerminalExpression(Parser parser)
        {
            MainParser = parser;
        }

        public void Interpret()
        { }
    }
}
