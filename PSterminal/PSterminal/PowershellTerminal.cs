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
    public class PowerShellTerminal : AbstractTerminal
    {
        public PowerShellTerminal(Brush commandBrush, Brush parameterBrush)
        {
            this.HighLight = new PowershellHighlight(commandBrush, parameterBrush);
        }

        public override Brush CommandHighlight()
        {
            return this.HighLight.CommandBrush();
        }

        public override Brush ParameterHighlight()
        {
            return this.HighLight.ParameterBrush();
        }
    }
}
