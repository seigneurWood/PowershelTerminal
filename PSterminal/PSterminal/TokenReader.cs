using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class TokenReader
    {
        private static List<TokenReader> tokenReaderList = new List<TokenReader>();
        private int _startingPosistion;
        private int _endingPosition;
        private string _token;
        private int _state;

        public TokenReader(int startingPos, int endingPos, string token, int state)
        {
            this.StartingPosistion = startingPos;
            this.EndingPosition = endingPos;
            this.Token = token;
            this.State = state;
        }

        public static List<TokenReader> TokenReaderList
        {
            get { return TokenReader.tokenReaderList; }
            set { TokenReader.tokenReaderList = value; }
        }

        public int StartingPosistion
        {
            get { return this._startingPosistion; }
            set { this._startingPosistion = value; }
        }
        
        public int EndingPosition
        {
            get { return this._endingPosition; }
            set { this._endingPosition = value; }
        }

        public string Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        public int State
        {
            get { return this._state; }
            set { this._state = value; }
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
            tokenReaderList.Add(token);
        }

        ////public void CheckVerbExpression(List<string> tokenList)
        ////{
        ////}

        ////public IAbstractExpression ReadToken(List<string> tokenList)
        ////{
        ////    return ReadNextToken(tokenList);
        ////}

        ////private IAbstractExpression ReadNextToken(List<string> tokenList)
        ////{
        ////    return new VerbScriptCommandExpression("get");
        ////}
    }
}
