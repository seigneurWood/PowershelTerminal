using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public abstract class StyleBase
    {
        private Brush _inputTextBoxBrush;
        private Brush _outputTextBoxBrush;
        private int _fontSize;
        private Brush _fontForeground;
        private Brush _mainColor;
        private Brush _markingColor;
        private Brush _borderColor;
        private Brush _borderTabItemColor;
        private Brush _markingTabItemColor;
        private Brush _backgroundTabItemColor;
        

        public Brush InputTextBoxBrush
        {
            get
            {
                return _inputTextBoxBrush;
            }

            set
            {
                _inputTextBoxBrush = value;
            }
        }

        public Brush OutputTextBoxBrush
        {
            get
            {
                return _outputTextBoxBrush;
            }

            set
            {
                _outputTextBoxBrush = value;
            }
        }

        public int FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                _fontSize = value;
            }
        }

        public Brush FontForeground
        {
            get
            {
                return _fontForeground;
            }

            set
            {
                _fontForeground = value;
            }
        }

        public Brush MainColor
        {
            get
            {
                return _mainColor;
            }

            set
            {
                _mainColor = value;
            }
        }

        public Brush MarkingColor
        {
            get
            {
                return _markingColor;
            }

            set
            {
                _markingColor = value;
            }
        }

        public Brush BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
            }
        }

        public Brush BorderTabItemColor
        {
            get
            {
                return _borderTabItemColor;
            }

            set
            {
                _borderTabItemColor = value;
            }
        }

        public Brush MarkingTabItemColor
        {
            get
            {
                return _markingTabItemColor;
            }

            set
            {
                _markingTabItemColor = value;
            }
        }

        public Brush BackgroundTabItemColor
        {
            get
            {
                return _backgroundTabItemColor;
            }

            set
            {
                _backgroundTabItemColor = value;
            }
        }

        public abstract void ChangeBackgroundTextBox(Brush InputTextboxBrush, Brush OutputTextboxBrush);
        public abstract void ChangeFont(int FontSize, Brush FontForeground);

    }
}
