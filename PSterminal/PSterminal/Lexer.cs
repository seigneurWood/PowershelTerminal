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
                        //TokenReader 
                        states = initState();
                        startingPosition = i + 1;
                    }
                    else
                    {
                        //TokenReader bla bla
                        lastFinalState = 0;
                        i = lastPositionWithFinalState;
                        startingPosition = i + 1;
                    }
                }
                else
                {
                    if (getFinalState(states) != 0)
                    {
                        lastFinalState = getFinalState(states);
                        lastPositionWithFinalState = i;
                    }
                }
            }

            if (lastFinalState != 0)
            {
                //TokenReader bla bla
            }
        }

        private int getFinalState(int[] states)// вернуть состояния всех автоматов
        {
            if (states[0] < 0)
                return states[0];
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
            states[2] = identifyDash(c, states[1]);
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
    }
}
