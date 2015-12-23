using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public class DarkSideStyle: StyleBase
    {
        public DarkSideStyle()
        {
            this.MainColor = new SolidColorBrush(Color.FromArgb(0xFF,0x2B,0x2B,0x2B));
            this.InputTextBoxBrush = new SolidColorBrush(Color.FromArgb(0xFF,0x38,0x38,0x38));
            this.OutputTextBoxBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x38, 0x38, 0x38));
            this.MarkingColor = new SolidColorBrush(Color.FromArgb(0xFF,0xC3,0x00,0x00));
            this.FontForeground = new SolidColorBrush(Colors.White);
            this.FontSize = 10;
            this.BorderColor = new SolidColorBrush(Colors.DarkRed);
            this.BorderTabItemColor = new SolidColorBrush(Colors.DarkRed);
            this.BackgroundTabItemColor = new SolidColorBrush(Color.FromArgb(0xFF,0xFF,0x5F,0x5F));
            this.MarkingTabItemColor = new SolidColorBrush(Colors.White);
        }

        public override void ChangeBackgroundTextBox(Brush InputTextboxBrush, Brush OutputTextboxBrush)
        {
            if (InputTextBoxBrush != null)
            {
                this.InputTextBoxBrush = InputTextboxBrush;
            }
            if (OutputTextboxBrush != null)
            {
                this.OutputTextBoxBrush = OutputTextboxBrush;
            }
        }

        public override void ChangeFont(int FontSize, Brush FontForeground)
        {
            if (FontSize != null && FontSize != 0)
            {
                this.FontSize = FontSize;
            }
            if (FontForeground != null)
            {
                this.FontForeground = FontForeground;
            }
        }
    }
}
