using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PSterminal
{
    public abstract class AbstractTerminal
    {
        private HighlightBase _highLight;

        public HighlightBase HighLight
        {
            get
            {
                return _highLight;
            }

            set
            {
                _highLight = value;
            }
        }

        public virtual Brush CommandHighlight()
        {
            return new SolidColorBrush(Colors.Black);
        }

        public virtual Brush ParameterHighlight()
        {
            return new SolidColorBrush(Colors.Black);
        }

        //public virtual Brush MenuBackgroundBrush()
        //{
        //    return new SolidColorBrush(Colors.LightGray);
        //}

        //public virtual Brush MenuBorderBrush()  
        //{
        //    return new SolidColorBrush(Colors.Gray);
        //}

        //public virtual Brush MenuFontBrush()
        //{
        //    return new SolidColorBrush(Colors.Black);
        //}
        
        //public virtual Brush InputTextBoxBackgroundBrush()
        //{
        //    return new SolidColorBrush(Colors.White);
        //}

        //public virtual Brush OutputTextBoxBackgroundBrush()
        //{
        //    return new SolidColorBrush(Colors.White);
        //}
    }
}
