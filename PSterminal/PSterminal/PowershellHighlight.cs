using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public class PowershellHighlight: HighlightBase
    {
        private SolidColorBrush _commandHighlight;
        private SolidColorBrush _parameterHighlight;

        public SolidColorBrush CommandHighlight
        {
            get
            {
                return _commandHighlight;
            }

            set
            {
                _commandHighlight = value;
            }
        }

        public SolidColorBrush ParameterHighlight
        {
            get
            {
                return _parameterHighlight;
            }

            set
            {
                _parameterHighlight = value;
            }
        }

        public PowershellHighlight()
        {
            CommandHighlight = new SolidColorBrush(Colors.DarkOliveGreen);
            ParameterHighlight = new SolidColorBrush(Colors.BlueViolet);
        }

        public override SolidColorBrush CommandBrush()
        {
            return CommandHighlight;
        }

        public override SolidColorBrush ParameterBrush()
        {
            return ParameterHighlight;
        }
    }
}
