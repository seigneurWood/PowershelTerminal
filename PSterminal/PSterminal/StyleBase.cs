using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public abstract class StyleBase: INotifyPropertyChanged
    {
        private Brush _inputTextBoxBrush;
        private Brush _outputTextBoxBrush;
        private int _fontSize;
        private Brush _userFontForeground;
        private Brush _mainColor;
        private Brush _markingColor;
        private Brush _borderColor;
        private Brush _borderTabItemColor;
        private Brush _markingTabItemColor;
        private Brush _backgroundTabItemColor;
        private Brush _fontForeground;
        private Brush _separatorColor;

        public Brush InputTextBoxBrush
        {
            get
            {
                return _inputTextBoxBrush;
            }

            set
            {
                _inputTextBoxBrush = value;
                this.OnPropertyChanged("InputTextBoxBrush");
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
                this.OnPropertyChanged("OutputTextBoxBrush");
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
                this.OnPropertyChanged("FontSize");
            }
        }

        public Brush UserFontForeground
        {
            get
            {
                return _userFontForeground;
            }

            set
            {
                _userFontForeground = value;
                this.OnPropertyChanged("FontForeground");
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
                this.OnPropertyChanged("MainColor");
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
                this.OnPropertyChanged("MarkingColor");
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
                this.OnPropertyChanged("BorderColor");
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
                this.OnPropertyChanged("BorderTabItemColor");
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
                this.OnPropertyChanged("MarkingTabItemColor");
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
                this.OnPropertyChanged("BackgroundTabItemColor");
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

        public Brush SeparatorColor
        {
            get
            {
                return _separatorColor;
            }

            set
            {
                _separatorColor = value;
            }
        }

        public abstract void ChangeBackgroundTextBox(Brush InputTextboxBrush, Brush OutputTextboxBrush);
        public abstract void ChangeFont(int FontSize, Brush FontForeground);

        public virtual Brush FontColor()
        {
            return new SolidColorBrush(Colors.Black);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
