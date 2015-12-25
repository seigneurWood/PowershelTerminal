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
        private StyleBase _style;

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

        public StyleBase Style
        {
            get
            {
                return _style;
            }

            set
            {
                _style = value;
            }
        }

        public virtual SolidColorBrush CommandHighlight()
        {
            return new SolidColorBrush(Colors.Black);
        }

        public virtual SolidColorBrush ParameterHighlight()
        {
            return new SolidColorBrush(Colors.Black);
        }

    }
}
