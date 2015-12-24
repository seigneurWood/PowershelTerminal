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
    public class PowerShellTerminal : AbstractTerminal, INotifyPropertyChanged
    {
        public PowerShellTerminal(Brush commandBrush, Brush parameterBrush)
        {
            this.HighLight = new PowershellHighlight(commandBrush, parameterBrush);
            this.Style = new LightSideStyle();
        }

        public override Brush CommandHighlight()
        {
            return this.HighLight.CommandBrush();
        }

        public override Brush ParameterHighlight()
        {
            return this.HighLight.ParameterBrush();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
