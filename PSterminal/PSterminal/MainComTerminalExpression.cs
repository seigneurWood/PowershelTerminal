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
            for (int i = 0; i < parser.TokenList.Count; i++)
            {
                if (parser.TokenList.ElementAt(i).Token == "get" || parser.TokenList.ElementAt(i).Token == "set")
                    Verb = new VerbScriptCommandExpression(parser.TokenList.ElementAt(i).Token);
                if (parser.TokenList.ElementAt(i).Token == "process" || parser.TokenList.ElementAt(i).Token == "volume")
                    Noun = new NounScriptTerminalExpression(parser.TokenList.ElementAt(i).Token);
            }
        }

        public void Interpret()
        { }
    }
}
