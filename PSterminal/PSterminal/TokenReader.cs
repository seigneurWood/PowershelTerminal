using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class TokenReader
    {
        static public List<TokenReader> TokenReaderList = new List<TokenReader>();
        private int _startingPosistion;

        public int StartingPosistion
        {
            get { return _startingPosistion; }
            set { _startingPosistion = value; }
        }
        private int _endingPosition;

        public int EndingPosition
        {
            get { return _endingPosition; }
            set { _endingPosition = value; }
        }
        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        private int _state;

        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        public TokenReader(int startingPos, int endingPos, string token, int state)
        {
            StartingPosistion = startingPos;
            EndingPosition = endingPos;
            Token = token;
            State = state;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("Lexeme ");
            str.Append(this.Token);
            str.Append(" Position ");
            str.Append(this.StartingPosistion.ToString());
            str.Append('-');
            str.Append(this.EndingPosition.ToString());
            str.Append(" State ");
            str.Append(this.State.ToString());
            return str.ToString();
        }

        public void AddToList(TokenReader token)
        {
            TokenReaderList.Add(token);
        }
        //public void CheckVerbExpression(List<string> tokenList)
        //{
        //}

        //public IAbstractExpression ReadToken(List<string> tokenList)
        //{
        //    return ReadNextToken(tokenList);
        //}

        //private IAbstractExpression ReadNextToken(List<string> tokenList)
        //{
        //    return new VerbScriptCommandExpression("get");
        //}

    }
}
