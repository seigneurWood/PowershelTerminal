using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PSterminal
{
    public enum TokenType
    {
        Command,
        Parameter,
        Ident,
        CommandCmd,
        ParameterCmd
        //Ident,
        //Comment,
        //Keyword,
        //Punct,
        //String,
        //Number
    }

    class QualifiedToken
    {
        public TokenType Type;
        public TextPointer StartPosition;
        public int StartOffset;
        public TextPointer EndPosition;
        public int EndOffset;
    }

    class RawText
    {
        public string Text;
        public TextPointer Start;
    }
}
