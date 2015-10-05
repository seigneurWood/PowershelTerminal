using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class Lexer
    {
        #region
        const int LENGTH = 5;

        const int SPACE = -32; //fds df 
        const int SEMICOLON = -18; // ;
        const int CHAR = -10;
        const int INT = -5;
        const int DASH = -110;// -
        const int PIPE = -124;// |


        #endregion

        private string _inputString;

        public string InputString
        {
            get { return _inputString; }
            set { _inputString = value; }
        }

        private List<string> _outputList;

        public List<string> OutputList
        {
            get { return _outputList; }
            set { _outputList = value; }
        }

        public Lexer(string inputString)
        {
            InputString = inputString;
            ParseString(inputString);
        }

        private int[] initState() // создать атомат с начальными состояниями (нач состояние = 1)
        {
            int[] arr = new int[LENGTH];
            for (int i = 0; i < LENGTH; i++)
                arr[i] = 1;
            return arr;
        }

        private void ParseString(string code)
        {
            int[] states = initState();

            int lastFinalState = 0;// последнее состояние автомата
            int lastPositionWithFinalState = 0;// позиция последнего успешнего автомата
            int startingPosition = 0;// начало новой лексемы

            for (int i = 0; i < code.Length; i++)
            {
                identify(code.ElementAt(i),states);

                if (allBroken(states))
                {
                    if (lastFinalState == 0)// ошибка - нет такой лексемы
                    {
                        TokenReader token = new TokenReader(startingPosition, startingPosition, code.Substring(startingPosition, 1), 0);
                        token.AddToList(token);

                        states = initState();
                        startingPosition = i + 1;
                    }
                    else
                    {
                        TokenReader token = new TokenReader(startingPosition, lastPositionWithFinalState, code.Substring(startingPosition, lastPositionWithFinalState + 1 - startingPosition), lastFinalState);
                        token.AddToList(token);

                        lastFinalState = 0;
                        i = lastPositionWithFinalState;
                        startingPosition = i + 1;
                        states = initState();
                    }
                }
                else
                {
                    if (getFinalState(states) != 0)
                    {
                        if (states[1] == -110)
                        {
                            lastFinalState = getFinalState(states);
                            lastPositionWithFinalState = i;

                            TokenReader token = new TokenReader(i, i, code[i].ToString(), lastFinalState);
                            token.AddToList(token);

                            lastFinalState = 0;
                            i = lastPositionWithFinalState;
                            startingPosition = i + 1;
                            states = initState();                            
                        }
                        else
                        {
                            lastFinalState = getFinalState(states);
                            lastPositionWithFinalState = i;
                        }
                        //states = initState();
                    }
                }
            }

            if (lastFinalState != 0)
            {
                TokenReader token = new TokenReader(startingPosition, lastPositionWithFinalState+1, code.Substring(startingPosition, lastPositionWithFinalState + 1), lastFinalState);
                token.AddToList(token);
            }
        }

        private int getFinalState(int[] states)// вернуть состояния всех автоматов
        {
            if (states[0] < 0)
                return states[0];
            if (states[1] < 0)
                return states[1];
            if (states[2] < 0)
                return states[2];
            if (states[3] < 0)
                return states[3];
            if (states[4] < 0)
                return states[4];

            return 0;
        }

        private bool allBroken(int[] states)// проверка, все ли автоматы сломаны
        {
            for (int i = 0; i < states.Length; i++ )
            {
                if (states[i] != 0)
                    return false;
            }
            return true;
        }

        private void identify(char c, int[] states)// проверка 
        {
            states[0] = identifyChar(c, states[0]);
            states[1] = identifyDash(c, states[1]);
            states[2] = identifySpace(c, states[2]);
            states[3] = identifyPipe(c, states[3]);
            states[4] = identifyInt(c, states[4]);
        }

        private int identifyChar(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c <= 122 && (int)c >= 97 || (int)c <= 90 && (int)c >= 65)
                        return -10;
                    return 0;
                case -10:
                    if ((int)c <= 122 && (int)c >= 97 || (int)c <= 90 && (int)c >= 65)
                        return -10;
                    return 0;
            }
            return 0;
        }
        private int identifyDash(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 45)
                        return -110;
                    return 0;
                case -110:
                    if ((int)c == 45)
                        return -110;
                    return 0;
            }
            return 0;
        }
        private int identifySpace(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 32)
                        return -32;
                    return 0;
                case -32:
                    if ((int)c == 32)
                        return -32;
                    return 0;
            }
            return 0;
        }
        private int identifyPipe(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c == 124)
                        return -124;
                    return 0;
                case -124:
                    if ((int)c == 124)
                        return -124;
                    return 0;
            }
            return 0;
        }
        private int identifyInt(char c, int state)
        {
            switch (state)
            {
                case 1:
                    if ((int)c <= 57 && (int)c >= 48)
                        return -5;
                    return 0;
                case -5:
                    if ((int)c <= 57 && (int)c >= 48)
                        return -5;
                    return 0;
            }
            return 0;
        }
    }
}
