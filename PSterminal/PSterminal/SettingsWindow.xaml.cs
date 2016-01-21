using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSterminal
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window, INotifyPropertyChanged 
    {
        MainWindow main;
        //AbstractTerminal terminal;
        public SettingsWindow(MainWindow mainWin)
        {
            InitializeComponent();
            //main = this.Owner as MainWindow;
            // (Application.Current.MainWindow as MainWindow).terminal = "KPi";
            //main.Title = "Kpi";
            MainWindow.Terminal.ToString();
            main = mainWin;
            //rbLightStyle.IsChecked = true;
            //terminal = terminalIn;
            //terminal = new PowerShellTerminal();//new SolidColorBrush(Colors.Beige), new SolidColorBrush(Colors.Blue));
            //MainWindow.Terminal.HighLight = new PowershellHighlight();
            //MainWindow.Terminal.Style = new LightSideStyle();
            this.DataContext = this.settingWin;
            //MainColor = MainWindow.Terminal.Style.MainColor as SolidColorBrush;
            //dtpCommnadHighlight.SelectedColor = CommandHighlight.Color;
            //dtpParameterHighlight.SelectedColor = ParameterHighlight.Color;

            //if(rbLightStyle.IsChecked == true)
            //{
            //    MainColor = new LightSideStyle().MainColor as SolidColorBrush;
            //    InputTextBoxBrush = new LightSideStyle().InputTextBoxBrush;
            //}
            if (MainWindow.Terminal.Style is LightSideStyle)
                rbLightStyle.IsChecked = true;
            else
                rbDarkSide.IsChecked = true;
        }

        //private SolidColorBrush mainColor = new SolidColorBrush();

        public Color ParameterHighlight
        {
            get
            {
                return main.ParameterHighlight.Color;
            }
            set
            {
                main.ParameterHighlight.Color = value;
                this.NotifyPropertyChanged("ParameterHighlight");
            }
        }

        public Color CommandHighlight
        {
            get
            {
                return main.CommandHighlight.Color;
            }

            set
            {
                main.CommandHighlight.Color = value;
                this.NotifyPropertyChanged("CommandHighlight");
            }
        }

        // i dont now
        public SolidColorBrush MarkingColor
        {
            get
            {
                return main.MarkingColor as SolidColorBrush;
            }

            set
            {
                main.MarkingColor = value;
                this.NotifyPropertyChanged("MarkingColor");
            }
        }

        public SolidColorBrush BorderColor
        {
            get
            {
                return main.BorderColor as SolidColorBrush;
            }

            set
            {
                main.BorderColor = value;
                this.NotifyPropertyChanged("BorderColor");
            }
        }

        public SolidColorBrush BorderTabItemColor
        {
            get
            {
                return main.BorderTabItemColor as SolidColorBrush;
            }

            set
            {
                main.BorderTabItemColor = value;
                this.NotifyPropertyChanged("BorderTabItemColor");
            }
        }

        public SolidColorBrush MainColor
        {
            get
            {
                return main.MainColor;//MainWindow.Terminal.Style.MainColor as SolidColorBrush;
            }
            set
            {
                main.MainColor = value;
                this.NotifyPropertyChanged("MainColor");
            }
        }

        public SolidColorBrush MarkingTabItemColor
        {
            get
            {
                return main.MarkingTabItemColor as SolidColorBrush;
            }

            set
            {
                main.MarkingTabItemColor = value;
                this.NotifyPropertyChanged("MarkingTabItemColor");
            }
        }

        public SolidColorBrush BackgroundTabItemColor
        {
            get
            {
                return main.BackgroundTabItemColor as SolidColorBrush;
            }

            set
            {
                main.BackgroundTabItemColor = value;
                this.NotifyPropertyChanged("BackgroundTabItemColor");
            }
        }

        public SolidColorBrush InputTextBoxBrush
        {
            get
            {
                return main.InputTextBoxBrush as SolidColorBrush;
            }

            set
            {
                main.InputTextBoxBrush = value;
                this.NotifyPropertyChanged("InputTextBoxBrush");
            }
        }

        public SolidColorBrush OutputTextBoxBrush
        {
            get
            {
                return main.OutputTextBoxBrush as SolidColorBrush;
            }

            set
            {
                main.OutputTextBoxBrush = value;
                this.NotifyPropertyChanged("OutputTextBoxBrush");
            }
        }

        public int SizeOfFont
        {
            get
            {
                return main.SizeOfFont;
            }

            set
            {
                main.SizeOfFont = value;
                this.NotifyPropertyChanged("SizeOfFont");
            }
        }

        public SolidColorBrush UserFontForeground
        {
            get
            {
                return main.UserFontForeground as SolidColorBrush;
            }

            set
            {
                main.UserFontForeground = value;
                this.NotifyPropertyChanged("FontForeground");
            }
        }

        public SolidColorBrush FontForeground
        {
            get
            {
                return main.FontForeground;
            }

            set
            {
                main.FontForeground = value;
                this.NotifyPropertyChanged("FontForeground");
            }
        }

        public SolidColorBrush SeparatorColor
        {
            get
            {
                return main.SeparatorColor;
            }

            set
            {
                main.SeparatorColor = value;
                this.NotifyPropertyChanged("SeparatorColor");
            }
        }

        // method from window
        private void UpdateCommandTextbox()
        {
            TextRange textrange = new TextRange(tbCommnad.Document.ContentStart, tbCommnad.Document.ContentEnd);
        }

        private void rbLightStyle_Checked(object sender, RoutedEventArgs e)
        {
            LightSideStyle style = new LightSideStyle();
            MainColor = style.MainColor as SolidColorBrush;
            BackgroundTabItemColor = style.BackgroundTabItemColor as SolidColorBrush;
            MarkingColor = style.MarkingColor as SolidColorBrush;
            MarkingTabItemColor = style.MarkingTabItemColor as SolidColorBrush;
            BorderColor = style.BorderColor as SolidColorBrush;
            BorderTabItemColor = style.BorderTabItemColor as SolidColorBrush;
            FontForeground = style.FontForeground as SolidColorBrush;
            SeparatorColor = style.SeparatorColor as SolidColorBrush;
            style.FontSize = Convert.ToInt32(SizeOfFont);
            style.InputTextBoxBrush = InputTextBoxBrush;
            style.OutputTextBoxBrush = OutputTextBoxBrush;
            MainWindow.Terminal.Style = style;
        }

        private void rbDarkSide_Checked(object sender, RoutedEventArgs e)
        {
            DarkSideStyle style = new DarkSideStyle();
            MainColor = style.MainColor as SolidColorBrush;
            BackgroundTabItemColor = style.BackgroundTabItemColor as SolidColorBrush;
            MarkingColor = style.MarkingColor as SolidColorBrush;
            MarkingTabItemColor = style.MarkingTabItemColor as SolidColorBrush;
            BorderColor = style.BorderColor as SolidColorBrush;
            BorderTabItemColor = style.BorderTabItemColor as SolidColorBrush;
            FontForeground = style.FontForeground as SolidColorBrush;
            SeparatorColor = style.SeparatorColor as SolidColorBrush;
            style.FontSize = Convert.ToInt32(SizeOfFont);
            style.InputTextBoxBrush = InputTextBoxBrush;
            style.OutputTextBoxBrush = OutputTextBoxBrush;
            MainWindow.Terminal.Style = style;
        }

        private void dtpCommnadHighlight_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //string br = dtpCommnadHighlight.SelectedColorText;
            // MessageBox.Show(br);
            //  Color col = (Color)ColorConverter.ConvertFromString(br);
            // tbCommnad.Background = new SolidColorBrush(col);
            // MessageBox.Show(MainColor.Color.ToString());
            // MessageBox.Show("MainWindow.Terminal.Style.MainColor = " + MainWindow.Terminal.Style.MainColor.ToString());

            //BindingExpression.UpdateSource();

            TextRange textRange = new TextRange(tbCommnad.Document.ContentStart, tbCommnad.Document.ContentEnd);
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)dtpCommnadHighlight.SelectedColor));
        }

        private void dtpParameterHighlight_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
           // string br = dtpParameterHighlight.SelectedColorText;
            // MessageBox.Show(br);
           // Color col = (Color)ColorConverter.ConvertFromString(br);
           // tbParameter.Background = new SolidColorBrush(col);

            TextRange textRange = new TextRange(tbParameter.Document.ContentStart, tbParameter.Document.ContentEnd);
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)dtpParameterHighlight.SelectedColor));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string style = "";
            string inputTexboxColor1 = "";
            string outputTexboxColor1 = "";
            string fontColor1 = "";
            string fontSize1 = "";
            string userFontForeground1 = "";
            string commandHightLight1 = "";
            string parameterHightLight1 = "";
            if (rbLightStyle.IsChecked == true)
                style = "LightSide";
            else
                style = "DarkSide";
            inputTexboxColor1 = InputTextBoxBrush.Color.A + "," + InputTextBoxBrush.Color.R + "," + InputTextBoxBrush.Color.G + "," + InputTextBoxBrush.Color.B;
            outputTexboxColor1 = OutputTextBoxBrush.Color.A + "," + OutputTextBoxBrush.Color.R + "," + OutputTextBoxBrush.Color.G + "," + OutputTextBoxBrush.Color.B;
            fontColor1 = FontForeground.Color.A + "," + FontForeground.Color.R + "," + FontForeground.Color.G + "," + FontForeground.Color.B;
            fontSize1 = SizeOfFont.ToString();
            userFontForeground1 = UserFontForeground.Color.A + "," + UserFontForeground.Color.R + "," + UserFontForeground.Color.G + "," + UserFontForeground.Color.B;
            commandHightLight1 = CommandHighlight.A + "," + CommandHighlight.R + "," + CommandHighlight.G + "," + CommandHighlight.B;
            parameterHightLight1 = ParameterHighlight.A + "," + ParameterHighlight.R + "," + ParameterHighlight.G + "," + ParameterHighlight.B;
            WriteChangeToSettingsDocument(style, inputTexboxColor1, outputTexboxColor1, fontColor1, fontSize1, userFontForeground1, commandHightLight1, parameterHightLight1);
            this.Close();
        }

        private void WriteChangeToSettingsDocument(string style, string inputTexboxColor, string outputTexboxColor, string fontColor, string fontSize, string userFontForeground,
            string commandHightLight, string parameterHightLight)
        {
            FileStream file = new FileStream("settings.ini", FileMode.Open);
            using (StreamWriter writer = new StreamWriter(file))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Style: ");
                sb.AppendLine(style);
                sb.Append("InputTexboxColor: ");
                sb.AppendLine(inputTexboxColor);
                sb.Append("OutputTexboxColor: ");
                sb.AppendLine(outputTexboxColor);
                sb.Append("FontColor: ");
                sb.AppendLine(fontColor);
                sb.Append("FontSize: ");
                sb.AppendLine(fontSize);
                sb.Append("UserFontForeground: ");
                sb.AppendLine(userFontForeground);
                sb.Append("CommandHightLight: ");
                sb.AppendLine(commandHightLight);
                sb.Append("ParameterHightLight: ");
                sb.AppendLine(parameterHightLight);
                writer.Write(sb.ToString());
                writer.Close();
            }
        }

        /////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void FontColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //TextRange textRange = new TextRange(main.Document.ContentStart, tbParameter.Document.ContentEnd);
            //textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)dtpParameterHighlight.SelectedColor));
        }
    }
}
