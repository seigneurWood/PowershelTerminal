﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PSterminal
{
    public class LightSideStyle: StyleBase
    {
        public LightSideStyle()
        {
            this.MainColor = new SolidColorBrush(Colors.LightGray);
            this.InputTextBoxBrush = new SolidColorBrush(Colors.White);
            this.OutputTextBoxBrush = new SolidColorBrush(Colors.White);
            this.MarkingColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xAA, 0xAA, 0xAA));
            this.FontForeground = new SolidColorBrush(Colors.Black);
            this.FontSize = 10;
            this.BorderColor = new SolidColorBrush(Colors.Gray);
            this.BorderTabItemColor = new SolidColorBrush(Color.FromArgb(0xFF,0xC5,0xC5,0xC5));
            this.BackgroundTabItemColor = new SolidColorBrush(Color.FromArgb(0xFF,0xAE,0xAE,0xAE));
            this.MarkingTabItemColor = new SolidColorBrush(Colors.White);
        }

        public override void ChangeBackgroundTextBox(Brush InputTextboxBrush, Brush OutputTextboxBrush)
        {
            if(InputTextBoxBrush != null)
            {
                this.InputTextBoxBrush = InputTextboxBrush;
            }
            if(OutputTextboxBrush != null)
            {
                this.OutputTextBoxBrush = OutputTextboxBrush;
            }
        }

        public override void ChangeFont(int FontSize, Brush FontForeground)
        {
            if(FontSize != null && FontSize != 0)
            {
                this.FontSize = FontSize;
            }
            if(FontForeground != null)
            {
                this.FontForeground = FontForeground;
            }
        }
    }
}
