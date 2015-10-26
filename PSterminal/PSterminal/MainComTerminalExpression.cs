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
        private List<TokenReader> _tokenList;
        private List<ParamTerminalExpression> _parameterList;
        private object _state;

        private static List<string> nounList = new List<string>();
        private static List<string> verbList = new List<string>();

        public MainComTerminalExpression(List<TokenReader> tokenList)
        {
            FillNounList();
            this.State = null;
            this.TokenList = tokenList;
            this.ParameterList = new List<ParamTerminalExpression>();
            for (int i = 0; i < tokenList.Count; i++)
            {
                for(int j = 0; j < nounList.Count; j++)
                {
                    if(tokenList.ElementAt(i).Token==nounList.ElementAt(j))
                    {
                        Noun = new NounScriptTerminalExpression(nounList.ElementAt(j));
                        State = Noun.Name;
                        break;
                    }
                }
                for (int k = 0; k < verbList.Count; k++)
                {
                    if (tokenList.ElementAt(i).Token == verbList.ElementAt(k))
                    {
                        Verb = new VerbScriptCommandExpression(verbList.ElementAt(k));
                        State = Verb.Name;
                        break;
                    }
                }
            }
            for (int i = 0; i < tokenList.Count; i++)
            {
                if(tokenList.ElementAt(i).Token=="-" && tokenList.ElementAt(i-1).Token==" ")
                {
                    ParamTerminalExpression parameter = new ParamTerminalExpression(tokenList.ElementAt(i + 1).Token, tokenList.ElementAt(i + 3).Token);
                    ParameterList.Add(parameter);
                }
            }
            //this.MainParser = parser;
            //for (int i = 0; i < parser.TokenList.Count; i++)
            //{
            //    if (parser.TokenList.ElementAt(i).Token == "get" || parser.TokenList.ElementAt(i).Token == "set")
            //    {
            //        this.Verb = new VerbScriptCommandExpression(parser.TokenList.ElementAt(i).Token);
            //    }

            //    if (parser.TokenList.ElementAt(i).Token == "process" || parser.TokenList.ElementAt(i).Token == "volume")
            //    {
            //        this.Noun = new NounScriptTerminalExpression(parser.TokenList.ElementAt(i).Token);
            //    }
            //}
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

        public List<TokenReader> TokenList
        {
            get { return this._tokenList; }
            set { this._tokenList = value; }
        }

        public List<ParamTerminalExpression> ParameterList
        {
            get { return this._parameterList; }
            set { this._parameterList = value; }
        }

        public object State
        {
            get { return _state; }
            protected set { _state = value; }
        }

        public void Interpret()
        {
        }

        private void FillNounList()
        {
            nounList.Add("add");
            nounList.Add("clear");
            nounList.Add("connect");
            nounList.Add("copy");
            nounList.Add("disable");
            nounList.Add("disconnect");
            nounList.Add("enable");
            nounList.Add("export");
            nounList.Add("get");
            nounList.Add("import");
            nounList.Add("invoke");
            nounList.Add("new");
            nounList.Add("remove");
            nounList.Add("reset");
            nounList.Add("set");
            nounList.Add("start");
            nounList.Add("stop");
            nounList.Add("update");
            nounList.Add("write");
        }
        private void FillVerbList()
        {
            verbList.Add("process");
            verbList.Add("command");
            verbList.Add("object");
        }
    }
}
