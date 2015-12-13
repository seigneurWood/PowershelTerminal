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
        //private PowershellTerminal terminal = new PowershellTerminal();
        List<string> commandInTerminal = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            commandInTerminal.Add("get-process");
            ////TextBox t = new TextBox();
            ////t.Undo();
            //TextScript.Text = "get-process"; // | sort-object | force-recurce";
            //TextScript.Text = "get-childitem * -include *.csv -recurse | remove-item";

            FlowDocument doc = new FlowDocument();
            Paragraph par = new Paragraph();
            par.Inlines.Add(new Run("get-process -name chrome"));
           // par.Inlines.Add(new Run("get-process"));
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
            paragraph.Inlines.Add(new Run("get-process -name chrome"));
           // Paragraph p = new Paragraph();
           // p.Inlines.Add("gfd");
            //paragraph.Inlines.Add(new Run("\ngess"));
            //paragraph.Inlines.Add(new Run("\ngerocess"));
            //paragraph.Inlines.Add(new Run("hello -hello \n"));
            document.Blocks.Add(paragraph);
            paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run("get-command"));
            document.Blocks.Add(paragraph);
           // document.Blocks.Add(p);
            tbOut.Document = document;

            string[] str = GetDocumentText(tbOut.Document).Split('\n');
            for(int i=0;i<str.Length-1;i++)
            {
                Lexer lexer = new Lexer(str[i]);
                ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
                test.CreateSyntaxTree();
                CommandCollection collection = new CommandCollection(test);
                string o = "";
                string obj = collection.Excute(null, o);
                tb.AppendText(obj);
                //int numberOfParag = obj.Split('\n').Length;
                //for(int j=0; j< numberOfParag;j++)
                //{
                    //Paragraph paragr = new Paragraph();
                    //paragr.Inlines.Add(obj);
                    //tbOut.Document.Blocks.Add(paragr);
               // }
                //MessageBox.Show(obj);
            }

            //Lexer lexer = new Lexer(text.ToString());
            //ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
            //test.CreateSyntaxTree();
            //CommandCollection collection = new CommandCollection(test);
            //string o = "";
            //string obj = collection.Excute(null, o);
            //parag.Inlines.Add();

            //PowershellTerminal powershell = new PowershellTerminal();
            //powershell.CreateSyntaxHighlight(tbOut);
            //tbOut = powershell.CreateSyntaxHighlight(tbOut).PaintOver();
            //PowershellSyntaxHighlight power = new PowershellSyntaxHighlight(document,document.ContentStart,document.ContentEnd);
            //CmdSyntaxHighlight cmd = new CmdSyntaxHighlight(document);
            //tbOut.Document = cmd.Document;
            //CmdSyntaxHighlight cmd2 = new CmdSyntaxHighlight(doc);
            //TextScript.Document = doc;

            // TextScript.TextChanged += TextChanged;

            //tbOut.SelectAll();
            //tbOut.SelectionBrush = new SolidColorBrush(Colors.Bisque);
            //string str = tbOut.Selection.Text;



            // TextRange tr = new TextRange(tbOut.Document.ContentStart)
            // MatchCollection allIp = Regex.Matches(tbOut., @"Slovo");

            var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
            allText.ClearAllProperties();
            MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\s");
            //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
            //string res1 = regex_results[0].Groups[0].Value;
            string res2 = regex_results[0].Groups[0].Value;

            //// string pattern = @"hello";
            Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

            //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
            //// allText.ClearAllProperties();
            //tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
            var start = tbOut.Document.ContentStart;
            while (start != null && start.CompareTo(tbOut.Document.ContentEnd) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                    // string[] matchMass = match.ToString().Split(@'(\s+)');
                    //if (match.Value != "get-process\n" || match.Value != "get-process ")
                    //Match m = Regex.Match(match.ToString(), @".*?$");
                    ////string s = m.ToString().Split(' ')[0];
                    //string[] s = match.ToString().Split(' ');
                    if (match.ToString() == "get-process")
                    {
                        var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                            start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                        textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue));
                        if (textrange.Text == "")
                        {
                            int b = 0;
                        }

                        start = textrange.End;
                    }
                    //else
                    {

                    }
                }
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }

            f = 11;
        }

        private void TextScript_KeyUp(object sender, KeyEventArgs e)
        {
            //Paragraph p = new Paragraph();
            //p.Inlines.Add("1\n");
            //TextScript.Document.Blocks.Add(p);

            if (e.IsUp)
            {
                UpdateRTB();


                //var allText = new TextRange(TextScript.Document.ContentStart, TextScript.Document.ContentEnd);
                //allText.ClearAllProperties();
                //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\s");
                //if(regex_results.Count != 0)
                //{
                //    SpacePowerCmdltHighlight(TextScript.Document);
                //}
                //regex_results = Regex.Matches(allText.Text, @"\s-(.*?)\s");
                //if(regex_results.Count != 0)
                //{
                //    SpaceParameterPowerCmdltHighlight(TextScript.Document);
                //}
                /////???????????????????????????????????? work with get-process ??????????????????????????????????????????
                //var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                //allText.ClearAllProperties();
                //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\s");
                ////MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
                ////string res1 = regex_results[0].Groups[0].Value;
                //string res2 = regex_results[0].Groups[0].Value;

                ////// string pattern = @"hello";
                //Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

                ////// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                ////// allText.ClearAllProperties();
                ////TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                //var start = TextScript.Document.ContentStart;
                //while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
                //{
                //    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                //    {
                //        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                //        // string[] matchMass = match.ToString().Split(@'(\s+)');
                //        //if (match.Value != "get-process\n" || match.Value != "get-process ")
                //        //Match m = Regex.Match(match.ToString(), @".*?$");
                //        ////string s = m.ToString().Split(' ')[0];
                //        //string[] s = match.ToString().Split(' ');
                //        if (match.ToString() == "get-process")
                //        {
                //            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                //                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                //            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
                //            if (textrange.Text == "")
                //            {
                //                int b = 0;
                //            }

                //            start = textrange.End;
                //        }
                //        //else
                //        {

                //        }
                //    }
                //    start = start.GetNextContextPosition(LogicalDirection.Forward);
                //}
            }
            if(e.Key == Key.Enter)
            {

            }
            //if(e.Key == Key.Enter)
            //{
            //    var allText = new TextRange(TextScript.Document.ContentStart, TextScript.Document.ContentEnd);
            //    allText.ClearAllProperties();
            //    var regex_results = Regex.Matches(allText.Text, @"-(.*?)\n");
            //    if (regex_results.Count != 0)
            //    {
            //        EnterParameterPowerCmdltHighlight(TextScript.Document);
            //    }
            //}
            //if (e.Key == Key.Space)
            //{
                ///////?????????????????????????????????????? work with -name ??????????????????????????????????????????????
                //var allText = new TextRange(TextScript.Document.ContentStart, TextScript.Document.ContentEnd);
                //allText.ClearAllProperties();
                //MatchCollection regex_results = Regex.Matches(allText.Text, @"\s-(.*?)\s");
                ////MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
                ////string res1 = regex_results[0].Groups[0].Value;
                //if (regex_results.Count != 0)
                //{
                //    string res2 = regex_results[0].Groups[0].Value;

                //    //// string pattern = @"hello";
                //    Regex regex = new Regex(res2.Split(' ')[1], RegexOptions.IgnoreCase);

                //    //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                //    //// allText.ClearAllProperties();
                //    //TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                //    var start = TextScript.Document.ContentStart;
                //    while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
                //    {
                //        if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                //        {
                //            var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                //            // string[] matchMass = match.ToString().Split(@'(\s+)');
                //            //if (match.Value != "get-process\n" || match.Value != "get-process ")
                //            //Match m = Regex.Match(match.ToString(), @".*?$");
                //            ////string s = m.ToString().Split(' ')[0];
                //            //string[] s = match.ToString().Split(' ');
                //            if (match.ToString() == "-name")
                //            {
                //                var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                //                    start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                //                textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.HotPink));
                //                if (textrange.Text == "")
                //                {
                //                    int b = 0;
                //                }

                //                start = textrange.End;
                //            }
                //            //else
                //            {

                //            }
                //        }
                //        start = start.GetNextContextPosition(LogicalDirection.Forward);
                //    }
                //}
           // }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
           // UpdateRTB();
            //MessageBox.Show(sender.ToString());


            //if (currentText[currentText.Length - 1] == "")
            //{
            //    // method
            //    text.ClearAllProperties();
            //    MatchCollection regex_results = Regex.Matches(text.Text, @"(.*?)-(.*?)\s");
            //    if (regex_results.Count != 0)
            //    {
            //        string res2 = regex_results[0].Groups[0].Value;

            //        //// string pattern = @"hello";
            //        Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

            //        //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
            //        //// allText.ClearAllProperties();
            //        // tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
            //        if (regex.ToString() == "get-process")
            //        {
            //            var start = TextScript.Document.ContentStart;
            //            while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
            //            {
            //                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            //                {
            //                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
            //                    // string[] matchMass = match.ToString().Split(@'(\s+)');
            //                    //if (match.Value != "get-process\n" || match.Value != "get-process ")
            //                    //Match m = Regex.Match(match.ToString(), @".*?$");
            //                    ////string s = m.ToString().Split(' ')[0];
            //                    //string[] s = match.ToString().Split(' ');
            //                    if (match.ToString() == "get-process")
            //                    {
            //                        var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
            //                            start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
            //                        textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
            //                        if (textrange.Text == "")
            //                        {
            //                            int b = 0;
            //                        }

            //                        start = textrange.End;
            //                    }
            //                    //else
            //                    {

            //                    }
            //                }
            //                start = start.GetNextContextPosition(LogicalDirection.Forward);
            //            }
            //        }
            //    }
            //}



            ///////////////////


            /////////////////////////////



            //TextPointer pointer = TextScript.Document.ContentEnd;
            // MessageBox.Show(pointer.IsAtLineStartPosition.ToString());
            // MessageBox.Show(text.Text.ToString());

            //MessageBox.Show(s.Length.ToString());
            //string change = "";
            //if(e.Changes.Any())
            //{
            //    for(int i=0;i<e.Changes.Count;i++)
            //    {
            //        change += ((TextChange)e.Changes.ElementAt(i)).ToString();
            //    }
            //}
            //int b = 0;


            //tbOut.Document.Blocks.Add(new Paragraph(new Run(e.Changes.Any().ToString())));
            //if (e.Changes.Any() && e.Changes.ToString()[e.Changes.ToString().Length-1] ==' ')
            //{
            //    PowershellTerminal power = new PowershellTerminal(TextScript.Document);
            //    TextScript.Document = power.PowershellHighlight.RichBox;
            //}

            //tbOut.Document.Blocks.Add(new Paragraph(new Run(e.Changes.ToString())));
            //if (e.Key == Key.Enter)
            //{
            //    //Paragraph p = new Paragraph();
            //    CmdTerminal cmd = new CmdTerminal(TextScript.Document);
            //    TextScript.Document = cmd.CmdHighlight.Document;
            //    //Paragraph p = new Paragraph();
            //    //p.Inlines.Add("3\n");
            //    //TextScript.Document.Blocks.Add(p);
            //}


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateRTB();
        }

        private void Azaza()
        {
            TextRange text = new TextRange(TextScript.Document.ContentStart, TextScript.Document.ContentEnd);
            string currentSplitText = text.Text.Split('\r')[0];
            string[] currentText = currentSplitText.Split(' ');

            for (int i = 0; i < commandInTerminal.Count; i++)
            {
                if (currentText[currentText.Length - 1] == "")
                {
                    // method
                    text.ClearAllProperties();
                    MatchCollection regex_results = Regex.Matches(text.Text, @"(.*?)-(.*?)\s");
                    if (regex_results.Count != 0)
                    {
                        string res2 = regex_results[0].Groups[0].Value;

                        //// string pattern = @"hello";
                        Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

                        //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                        //// allText.ClearAllProperties();
                        // tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                        if (regex.ToString() == "get-process")
                        {
                            var start = TextScript.Document.ContentStart;
                            while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
                            {
                                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                                {
                                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                                    // string[] matchMass = match.ToString().Split(@'(\s+)');
                                    //if (match.Value != "get-process\n" || match.Value != "get-process ")
                                    //Match m = Regex.Match(match.ToString(), @".*?$");
                                    ////string s = m.ToString().Split(' ')[0];
                                    //string[] s = match.ToString().Split(' ');

                                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));

                                    start = textrange.End;

                                    //else



                                }
                                start = start.GetNextContextPosition(LogicalDirection.Forward);
                            }
                        }
                    }
                }
            }
            if (!Char.IsWhiteSpace(text.Text[text.Text.Length - 1]))
            {
                //var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                text.ClearAllProperties();
                MatchCollection regex_results = Regex.Matches(text.Text, @"(.*?)-(.*?)\s");
                //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
                //string res1 = regex_results[0].Groups[0].Value;
                if (regex_results.Count != 0)
                {
                    string res2 = regex_results[0].Groups[0].Value;

                    //// string pattern = @"hello";
                    Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

                    //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                    //// allText.ClearAllProperties();
                    // tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                    if (regex.ToString() == "get-process")
                    {
                        var start = TextScript.Document.ContentStart;
                        while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
                        {
                            if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                            {
                                var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                                // string[] matchMass = match.ToString().Split(@'(\s+)');
                                //if (match.Value != "get-process\n" || match.Value != "get-process ")
                                //Match m = Regex.Match(match.ToString(), @".*?$");
                                ////string s = m.ToString().Split(' ')[0];
                                //string[] s = match.ToString().Split(' ');
                                if (match.ToString() == "get-process")
                                {
                                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
                                    if (textrange.Text == "")
                                    {
                                        int b = 0;
                                    }

                                    start = textrange.End;
                                }
                                //else
                                {

                                }
                            }
                            start = start.GetNextContextPosition(LogicalDirection.Forward);
                        }
                    }
                }
            }
        }

        private void SpacePowerCmdltHighlight(FlowDocument document)
        {
            var allText = new TextRange(document.ContentStart, document.ContentEnd);
            allText.ClearAllProperties();
            MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\s");

            if (regex_results.Count != 0)
            {
                string res2 = regex_results[0].Groups[0].Value;

                //// string pattern = @"hello";
                Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

                var start = document.ContentStart;
                while (start != null && start.CompareTo(document.ContentEnd) < 0)
                {
                    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    {
                        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                        // string[] matchMass = match.ToString().Split(@'(\s+)');
                        //if (match.Value != "get-process\n" || match.Value != "get-process ")
                        //Match m = Regex.Match(match.ToString(), @".*?$");
                        ////string s = m.ToString().Split(' ')[0];
                        //string[] s = match.ToString().Split(' ');
                        if (match.ToString() == "get-process")
                        {
                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
                            if (textrange.Text == "")
                            {
                                int b = 0;
                            }

                            start = textrange.End;
                        }
                        //else
                        {

                        }
                    }
                    start = start.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
        }

        private void EnterPowerCmdltHighlight(FlowDocument document)
        {
            var allText = new TextRange(document.ContentStart, document.ContentEnd);
            allText.ClearAllProperties();
            MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\n");

            if (regex_results.Count != 0)
            {
                string res2 = regex_results[0].Groups[0].Value;

                //// string pattern = @"hello";
                Regex regex = new Regex(res2, RegexOptions.IgnoreCase); ////???????????????????????????????????????????????????????????????????????????

                var start = document.ContentStart;
                while (start != null && start.CompareTo(document.ContentEnd) < 0)
                {
                    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    {
                        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                        // string[] matchMass = match.ToString().Split(@'(\s+)');
                        //if (match.Value != "get-process\n" || match.Value != "get-process ")
                        //Match m = Regex.Match(match.ToString(), @".*?$");
                        ////string s = m.ToString().Split(' ')[0];
                        //string[] s = match.ToString().Split(' ');
                        if (match.ToString() == "get-process")
                        {
                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
                            if (textrange.Text == "")
                            {
                                int b = 0;
                            }

                            start = textrange.End;
                        }
                        //else
                        {

                        }
                    }
                    start = start.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
        }

        private void SpaceParameterPowerCmdltHighlight(FlowDocument document)
        {
            var allText = new TextRange(document.ContentStart, document.ContentEnd);
            allText.ClearAllProperties();
            MatchCollection regex_results = Regex.Matches(allText.Text, @"\s-(.*?)\s");
            //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
            //string res1 = regex_results[0].Groups[0].Value;
            if (regex_results.Count != 0)
            {
                string res2 = regex_results[0].Groups[0].Value;

                //// string pattern = @"hello";
                Regex regex = new Regex(res2.Split(' ')[1], RegexOptions.IgnoreCase);

                //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                //// allText.ClearAllProperties();
                //TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                var start = document.ContentStart;
                while (start != null && start.CompareTo(document.ContentEnd) < 0)
                {
                    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    {
                        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                        // string[] matchMass = match.ToString().Split(@'(\s+)');
                        //if (match.Value != "get-process\n" || match.Value != "get-process ")
                        //Match m = Regex.Match(match.ToString(), @".*?$");
                        ////string s = m.ToString().Split(' ')[0];
                        //string[] s = match.ToString().Split(' ');
                        if (match.ToString() == "-name")
                        {
                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.HotPink));
                            if (textrange.Text == "")
                            {
                                int b = 0;
                            }

                            start = textrange.End;
                        }
                        //else
                        {

                        }
                    }
                    start = start.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
        }

        private void EnterParameterPowerCmdltHighlight(FlowDocument document)
        {
            var allText = new TextRange(document.ContentStart, document.ContentEnd);
            allText.ClearAllProperties();
            MatchCollection regex_results = Regex.Matches(allText.Text, @"-(.*?)\n");
            //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
            //string res1 = regex_results[0].Groups[0].Value;
            if (regex_results.Count != 0)
            {
                string res2 = regex_results[0].Groups[0].Value;

                //// string pattern = @"hello";
                Regex regex = new Regex(res2.Split('\r')[0], RegexOptions.IgnoreCase);/////////?????????????????????????????????????????????????????????????????????

                //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
                //// allText.ClearAllProperties();
                //TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
                var start = document.ContentStart;
                while (start != null && start.CompareTo(document.ContentEnd) < 0)
                {
                    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    {
                        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
                        // string[] matchMass = match.ToString().Split(@'(\s+)');
                        //if (match.Value != "get-process\n" || match.Value != "get-process ")
                        //Match m = Regex.Match(match.ToString(), @".*?$");
                        ////string s = m.ToString().Split(' ')[0];
                        //string[] s = match.ToString().Split(' ');
                        if (match.ToString() == "-name")
                        {
                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.HotPink));
                            if (textrange.Text == "")
                            {
                                int b = 0;
                            }

                            start = textrange.End;
                        }
                        //else
                        {

                        }
                    }
                    start = start.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
        }

        #region Отслеживание Run LinerBreak
        IEnumerable<RawText> ExtractText(IEnumerable<Inline> inlines)
        {
            return inlines.SelectMany(ExtractText);
        }

        IEnumerable<RawText> ExtractText(Inline inline)
        {
            return ExtractTextImpl((dynamic)inline);
        }

        IEnumerable<RawText> ExtractTextImpl(Run run)
        {
            return new[] { new RawText() { Text = run.Text, Start = run.ContentStart } };
        }

        IEnumerable<RawText> ExtractTextImpl(LineBreak br)
        {
            return new[] { new RawText() { Text = "\n", Start = br.ContentStart } };
        }

        IEnumerable<RawText> ExtractTextImpl(Span span)
        {
            return ExtractText(span.Inlines);
        }

        IEnumerable<RawText> ExtractTextImpl(Inline inline)
        {
            return Enumerable.Empty<RawText>();
        }
        #endregion

        #region Update Line

        async Task UpdateParagraph(Paragraph par)
        {
            var completeTextRange = new TextRange(par.ContentStart, par.ContentEnd);
            completeTextRange.ClearAllProperties();
            await UpdateInlines(par.Inlines);
        }

        async Task UpdateAllParagraphs(IEnumerable<Paragraph> paragraphs)
        {
            var materialParagraphs = paragraphs.ToList();
            if (materialParagraphs.Count == 0)
                return;
            var completeTextRange = new TextRange(materialParagraphs.First().ContentStart,
                                                  materialParagraphs.Last().ContentEnd);
            completeTextRange.ClearAllProperties();
            await UpdateInlines(materialParagraphs.SelectMany(par => par.Inlines));
        }

        async Task UpdateInlines(IEnumerable<Inline> inlines)
        {
            var texts = ExtractText(inlines);
            //string s = texts.ToString();
            var positionsAndBrushes =
                (from qualifiedToken in await HighlightLexer.Parse(texts)
                 let brush = GetBrushForTokenType(qualifiedToken.Type)
                 where brush != null
                 let start = qualifiedToken.StartPosition.GetPositionAtOffset(qualifiedToken.StartOffset)
                 let end = qualifiedToken.EndPosition.GetPositionAtOffset(qualifiedToken.EndOffset)
                 let position = new TextRange(start, end)
                 select new { position, brush }).ToList();

            foreach (var pb in positionsAndBrushes)
                pb.position.ApplyPropertyValue(TextElement.ForegroundProperty, pb.brush);
        }

        #endregion

        Brush GetBrushForTokenType(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Command: return Brushes.Aquamarine;
                case TokenType.Parameter: return Brushes.HotPink;
                //case TokenType.Ident: return Brushes.LimeGreen;
                //case TokenType.Number: return Brushes.Cyan;
                //case TokenType.Punct: return Brushes.Gray;
                //case TokenType.String: return Brushes.DarkRed;
            }
            return null;
        }

        IEnumerable<Paragraph> GetParagraphs(BlockCollection blockCollection)
        {
            foreach (var block in blockCollection)
            {
                var para = block as Paragraph;
                if (para != null)
                {
                    yield return para;
                }
                else
                {
                    foreach (var innerPara in GetParagraphs(block.SiblingBlocks))
                        yield return innerPara;
                }
            }
        }

        async void UpdateRTB()
        {
            TextScript.IsEnabled = false;
            var doc = TextScript.Document;
            foreach (var par in GetParagraphs(doc.Blocks).ToList())
                await UpdateParagraph(par);
            TextScript.IsEnabled = true;
        }

        private string GetDocumentText(FlowDocument document)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach(var par in GetParagraphs(document.Blocks).ToList())
            {
                var completeTextRange = new TextRange(par.ContentStart, par.ContentEnd);
                completeTextRange.ClearAllProperties();
                strBuilder.AppendLine(completeTextRange.Text);
            }
            return strBuilder.ToString();
        }
    }
}
