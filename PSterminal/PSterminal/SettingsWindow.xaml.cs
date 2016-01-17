using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class SettingsWindow : Window 
    {
        MainWindow main;
        AbstractTerminal terminal;
        public SettingsWindow(AbstractTerminal terminalIn)
        {
            InitializeComponent();
            main = this.Owner as MainWindow;
            terminal = terminalIn;
            //terminal = new PowerShellTerminal();//new SolidColorBrush(Colors.Beige), new SolidColorBrush(Colors.Blue));
            //terminal.HighLight = new PowershellHighlight();
            //terminal.Style = new LightSideStyle();
            this.DataContext = this.settingWin;
            CommandHighlight = terminal.HighLight.CommandBrush();
            parameterHighlight = terminal.HighLight.ParameterBrush();
            MainColor = terminal.Style.MainColor as SolidColorBrush;
            dtpCommnadHighlight.SelectedColor = CommandHighlight.Color;
        }

        private SolidColorBrush mainColor = new SolidColorBrush();
        public SolidColorBrush MainColor
        {
            get
            {
                return mainColor;
            }
            set
            {
                mainColor = value;
            }
        }

        private SolidColorBrush commandHighlight = new SolidColorBrush();


        private SolidColorBrush parameterHighlight = new SolidColorBrush();
        public SolidColorBrush ParameterHighlight
        {
            get
            {
                return parameterHighlight;
            }
        }

        public SolidColorBrush CommandHighlight
        {
            get
            {
                return commandHighlight;
            }

            set
            {
                commandHighlight = value;
            }
        }

        private void UpdateCommandTextbox()
        {
            TextRange textrange = new TextRange(tbCommnad.Document.ContentStart, tbCommnad.Document.ContentEnd);
        }

        private void rbLightStyle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbDarkSide_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void dtpCommnadHighlight_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string br = dtpCommnadHighlight.SelectedColorText;
            // MessageBox.Show(br);
            Color col = (Color)ColorConverter.ConvertFromString(br);
            tbCommnad.Background = new SolidColorBrush(col);
            (terminal.HighLight as PowershellHighlight).CommandHighlight = tbCommnad.Background as SolidColorBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
