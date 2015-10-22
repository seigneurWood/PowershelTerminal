using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class MainComTerminalExpression : IAbstractExpression
    {
        private NounScriptTerminalExpression _noun;
        private VerbScriptCommandExpression _verb;
        private Parser _mainParser;

        public MainComTerminalExpression(Parser parser)
        {
            this.MainParser = parser;
            for (int i = 0; i < parser.TokenList.Count; i++)
            {
                if (parser.TokenList.ElementAt(i).Token == "get" || parser.TokenList.ElementAt(i).Token == "set")
                {
                    this.Verb = new VerbScriptCommandExpression(parser.TokenList.ElementAt(i).Token);
                }

                if (parser.TokenList.ElementAt(i).Token == "process" || parser.TokenList.ElementAt(i).Token == "volume")
                {
                    this.Noun = new NounScriptTerminalExpression(parser.TokenList.ElementAt(i).Token);
                }
            }
        }

        public NounScriptTerminalExpression Noun
        {
            get { return this._noun; }
            set { this._noun = value; }
        }

        public VerbScriptCommandExpression Verb
        {
            get { return this._verb; }
            set { this._verb = value; }
        }

        public Parser MainParser
        {
            get { return this._mainParser; }
            set { this._mainParser = value; }
        }

        public void Interpret()
        { 
        }
    }
}
