using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class Lexer
    {
        #region constant
        private const int LENGTH = 5; // length automaton massive
        private const int SPACE = -32; // space
        private const int SEMICOLON = -18; // ;
        private const int CHAR = -10; // char element
        private const int INT = -5; // int element
        private const int DASH = -110; // -
        private const int PIPE = -124; // |

        #endregion

        private string _inputString;
        private List<string> _outputList;

        public Lexer(string inputString)
        {
            this.InputString = inputString;
            ParseString(inputString);
        }

        public string InputString
        {
            get { return this._inputString; }
            set { this._inputString = value; }
        }

        public List<string> OutputList
        {
            get { return this._outputList; }
            set { this._outputList = value; }
        }

        private int[] InitState() // создать атомат с начальными состояниями (нач состояние = 1)
        {
            int[] arr = new int[LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                arr[i] = 1;
            }

            return arr;
        }

        private void ParseString(string code)
        {
            int[] states = this.InitState();

            int lastFinalState = 0; // последнее состояние автомата
            int lastPositionWithFinalState = 0; // позиция последнего успешнего автомата
            int startingPosition = 0; // начало новой лексемы

            for (int i = 0; i < code.Length; i++)
            {
                this.Identify(code.ElementAt(i), states);

                if (this.AllBroken(states))
                {
                    // если lastFinalState == 0 - нет такой лексемы
                    if (lastFinalState == 0)
                    {
                        TokenReader token = new TokenReader(startingPosition, startingPosition, code.Substring(startingPosition, 1), 0);
                        token.AddToList(token);

                        states = this.InitState();
                        startingPosition = i + 1;
                    }
                    else
                    {
                        TokenReader token = new TokenReader(startingPosition, lastPositionWithFinalState, code.Substring(startingPosition, lastPositionWithFinalState + 1 - startingPosition), lastFinalState);
                        token.AddToList(token);

                        lastFinalState = 0;
                        i = lastPositionWithFinalState;
                        startingPosition = i + 1;
                        states = this.InitState();
                    }
                }
                else
                {
                    if (this.GetFinalState(states) != 0)
                    {
                        if (states[1] == -110)
                        {
                            lastFinalState = this.GetFinalState(states);
                            lastPositionWithFinalState = i;

                            TokenReader token = new TokenReader(i, i, code[i].ToString(), lastFinalState);
                            token.AddToList(token);

                            lastFinalState = 0;
                            i = lastPositionWithFinalState;
                            startingPosition = i + 1;
                            states = this.InitState();                            
                        }
                        else
                        {
                            lastFinalState = this.GetFinalState(states);
                            lastPositionWithFinalState = i;
                        }
                        ////states = initState();
                    }
                }
            }

            if (lastFinalState != 0)
            {
                TokenReader token = new TokenReader(startingPosition, lastPositionWithFinalState + 1, code.Substring(startingPosition, lastPositionWithFinalState + 1 - startingPosition), lastFinalState);
                token.AddToList(token);
            }
        }

        private int GetFinalState(int[] states) // вернуть состояния всех автоматов
        {
            if (states[0] < 0)
            {
                return states[0];
            }

            if (states[1] < 0)
            {
                return states[1];
            }

            if (states[2] < 0)
            {
                return states[2];
            }

            if (states[3] < 0)
            {
                return states[3];
            }

            if (states[4] < 0)
            {
                return states[4];
            }

            return 0;
        }

        private bool AllBroken(int[] states) // проверка, все ли автоматы сломаны
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void Identify(char c, int[] states) // проверка 
        {
            states[0] = this.IdentifyChar(c, states[0]);
            states[1] = this.IdentifyDash(c, states[1]);
            states[2] = this.IdentifySpace(c, states[2]);
            states[3] = this.IdentifyPipe(c, states[3]);
            states[4] = this.IdentifyInt(c, states[4]);
        }

        private int IdentifyChar(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if (((int)c <= 122 && (int)c >= 97) || ((int)c <= 90 && (int)c >= 65))
                    {
                        return -10;
                    }

                    return 0;
                case -10:
                    if (((int)c <= 122 && (int)c >= 97) || ((int)c <= 90 && (int)c >= 65))
                    {
                        return -10;
                    }

                    return 0;
            }

            return 0;
        }

        private int IdentifyDash(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 45)
                    {
                        return -110;
                    }

                    return 0;
                case -110:
                    if ((int)c == 45)
                    {
                        return -110;
                    }

                    return 0;
            }

            return 0;
        }

        private int IdentifySpace(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 32)
                    {
                        return -32;
                    }

                    return 0;
                case -32:
                    if ((int)c == 32)
                    {
                        return -32;
                    }

                    return 0;
            }

            return 0;
        }

        private int IdentifyPipe(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 124)
                    {
                        return -124;
                    }

                    return 0;
                case -124:
                    if ((int)c == 124)
                    {
                        return -124;
                    }

                    return 0;
            }

            return 0;
        }

        private int IdentifyInt(char c, int state)
        {
            switch (state)
            {
                case 1:
                    {
                        if ((int)c <= 57 && (int)c >= 48)
                        {
                            return -5;
                        }

                        return 0;
                    }

                case -5:
                    {
                        if ((int)c <= 57 && (int)c >= 48)
                        {
                            return -5;
                        }

                        return 0;
                    }
            }

            return 0;
        }
    }
}
