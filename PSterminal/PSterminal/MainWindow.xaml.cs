using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSterminal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Terminal terminal = new Terminal();

        public MainWindow()
        {
            InitializeComponent();
            ////TextBox t = new TextBox();
            ////t.Undo();
            TextScript.Text = "get-process"; // | sort-object | force-recurce";
            //TextScript.Text = "get-childitem * -include *.csv -recurse | remove-item";

            ////TextScript.Text += Convert.ToString((int)('9'));
            ////TextScript.Text += TextScript.Text.Length.ToString();
            terminal.Script = this.TextScript.Text;

            Lexer lexer = new Lexer(TextScript.Text);

            TextScript.Text += "\n";
            ////TextScript.Text += TextScript.Text.Substring(4, 10);
            for (int i = 0; i < TokenReader.TokenReaderList.Count; i++)
            {
                TextScript.Text += TokenReader.TokenReaderList.ElementAt(i).ToString() + "\n";
            }

            TextScript.Text += "\n";
            TextScript.Text += "\n";

            //Parser parser = new Parser(TokenReader.TokenReaderList);
            //parser.CreateTree();
            ////parser.CheckError();

            ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
            test.CreateSyntaxTree();
            CommandCollection collection = new CommandCollection(test);
            object[] o = null;
            object[] obj = collection.Excute(null,o);
            foreach(var ob in obj)
            {
                if(ob!=null)
                    tbOut.Text += ob.ToString()+'\n';
            }
            int f = 10;
           // BreadthFirstIterator b = new BreadthFirstIterator(test);
            //test.Interpret();

            f = 11;
        }

        private void TextScript_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
