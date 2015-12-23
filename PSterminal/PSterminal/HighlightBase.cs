using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public abstract class HighlightBase
    {
        public abstract Brush CommandBrush();

        public abstract Brush ParameterBrush();
    }
}
