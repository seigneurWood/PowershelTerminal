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
        private Brush _commandHighlight;
        private Brush _parameterHighlight;

        public Brush CommandHighlight
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

        public Brush ParameterHighlight
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

        public PowershellHighlight(Brush CommandBrush, Brush ParameterBrush)
        {
            CommandHighlight = CommandBrush;
            ParameterHighlight = ParameterBrush;
        }

        public override Brush CommandBrush()
        {
            return CommandHighlight;
        }

        public override Brush ParameterBrush()
        {
            return ParameterHighlight;
        }
    }
}
