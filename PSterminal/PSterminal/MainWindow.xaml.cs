using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private PowershellTerminal terminal = new PowershellTerminal();

        public MainWindow()
        {
            InitializeComponent();
            ////TextBox t = new TextBox();
            ////t.Undo();
            //TextScript.Text = "get-process"; // | sort-object | force-recurce";
            //TextScript.Text = "get-childitem * -include *.csv -recurse | remove-item";

            FlowDocument doc = new FlowDocument();
            Paragraph par = new Paragraph();
            par.Inlines.Add("get-process");
            doc.Blocks.Add(par);
            TextScript.Document = doc;

            ////TextScript.Text += Convert.ToString((int)('9'));
            ////TextScript.Text += TextScript.Text.Length.ToString();
            //terminal.Script = this.TextScript.Text;

            //Lexer lexer = new Lexer(TextScript.Text);

            //TextScript.Text += "\n";
            ////TextScript.Text += TextScript.Text.Substring(4, 10);

            //TextRange t = new TextRange(doc.ContentStart, doc.ContentEnd);
            //for (int i = 0; i < TokenReader.TokenReaderList.Count; i++)
            //{
            //    t.Text += TokenReader.TokenReaderList.ElementAt(i).ToString() + "\n";
            //}

            //TextScript.Text += "\n";
            //TextScript.Text += "\n";

            //Parser parser = new Parser(TokenReader.TokenReaderList);
            //parser.CreateTree();
            ////parser.CheckError();

            //ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
            //test.CreateSyntaxTree();
            //CommandCollection collection = new CommandCollection(test);
            //object[] o = null;
            //object[] obj = collection.Excute(null,o);
            //foreach(var ob in obj)
            //{
                //if(ob!=null)
                    
                    //tbOut. += ob.ToString()+'\n';
           // }
            int f = 10;
            // BreadthFirstIterator b = new BreadthFirstIterator(test);
            //test.Interpret();


            FlowDocument document = new FlowDocument();
            Paragraph paragraph = new Paragraph();
           // paragraph.Inlines.Add((new Run("текст")));//\n работает" + "И прибавления тоже" + "Удачи")));
            //paragraph.Inlines.Add(new Run("hello-hello \n"));
            paragraph.Inlines.Add(new Run("cmd \n"));
            //paragraph.Inlines.Add(new Run("hello -hello \n"));
            document.Blocks.Add(paragraph);
            tbOut.Document = document;

            //PowershellTerminal powershell = new PowershellTerminal();
            //powershell.CreateSyntaxHighlight(tbOut);
            //tbOut = powershell.CreateSyntaxHighlight(tbOut).PaintOver();
            //PowershellSyntaxHighlight power = new PowershellSyntaxHighlight(document,document.ContentStart,document.ContentEnd);
            CmdSyntaxHighlight cmd = new CmdSyntaxHighlight(document);
            tbOut.Document = cmd.Document;

            //tbOut.SelectAll();
            //tbOut.SelectionBrush = new SolidColorBrush(Colors.Bisque);
            //string str = tbOut.Selection.Text;

            // TextRange tr = new TextRange(tbOut.Document.ContentStart)
            // MatchCollection allIp = Regex.Matches(tbOut., @"Slovo");

            //var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
            //allText.ClearAllProperties();
            //// MatchCollection regex_results = Regex.Matches(allText.Text, @"-(.*?)");
            //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
            //string res1 = regex_results[0].Groups[0].Value;
            //string res2 = regex_results[1].Groups[0].Value;

            //// string pattern = @"hello";
            //Regex regex = new Regex(res2, RegexOptions.IgnoreCase);

            //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
            //// allText.ClearAllProperties();

            //var start = tbOut.Document.ContentStart;
            //while (start != null && start.CompareTo(tbOut.Document.ContentEnd) < 0)
            //{
            //    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            //    {
            //        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));

            //        var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
            //            start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
            //        textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.LawnGreen));

            //        start = textrange.End;
            //    }
            //    start = start.GetNextContextPosition(LogicalDirection.Forward);
            //}

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
