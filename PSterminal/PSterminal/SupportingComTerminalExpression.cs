using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class SupportingComTerminalExpression : IAbstractExpression
    {
        private List<TokenReader> _tokenList;
        private object _state;
        private NounScriptTerminalExpression _noun;

        private VerbScriptCommandExpression _verb;

        private static List<string> supportComNounList = new List<string>();
        private static List<string> supportComVerbList = new List<string>();

        public SupportingComTerminalExpression(List<TokenReader> tokenList)
        {
            FillSupportComNounList();
            FillSupportComVerbList();
            this.State = null;
            this.TokenList = tokenList;
            for (int i = 0; i < tokenList.Count; i++)
            {
                for (int j = 0; j < supportComNounList.Count; j++)
                {
                    if (tokenList.ElementAt(i).Token == supportComNounList.ElementAt(j))
                    {
                        Noun = new NounScriptTerminalExpression(supportComNounList.ElementAt(j));
                        //State = Noun.Name;
                        break;
                    }
                }
            }
            for (int i = 0; i < tokenList.Count; i++)
            {
                for (int j = 0; j < supportComVerbList.Count; j++)
                {
                    if (tokenList.ElementAt(i).Token == supportComVerbList.ElementAt(j))
                    {
                        Verb = new VerbScriptCommandExpression(supportComVerbList.ElementAt(j));
                        //State = Verb.Name;
                        break;
                    }
                }
            }
        }

        public List<TokenReader> TokenList
        {
            get { return this._tokenList; }
            set { this._tokenList = value; }
        }

        public object State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Interpret()
        { 
        }

        public NounScriptTerminalExpression Noun
        {
            get { return _noun; }
            set { _noun = value; }
        }

        public VerbScriptCommandExpression Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }

        private void FillSupportComNounList()
        {
            supportComNounList.Add("sort");
            supportComNounList.Add("force");
        }

        private void FillSupportComVerbList()
        {
            supportComVerbList.Add("object");
            supportComVerbList.Add("recurce");
        }
    }
}
