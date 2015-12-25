using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public PowerShellTerminal()
        {
            this.HighLight = new PowershellHighlight();
            this.Style = new LightSideStyle();
        }

        public override SolidColorBrush CommandHighlight()
        {
            return this.HighLight.CommandBrush();
        }

        public override SolidColorBrush ParameterHighlight()
        {
            return this.HighLight.ParameterBrush();
        }
    }
}
