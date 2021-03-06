﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //private PowershellTerminal terminal = new PowershellTerminal();
        List<string> commandInTerminal = new List<string>();
        List<ScriptTab> scriptTabsList = new List<ScriptTab>();
        int prev = 0;
        RichTextBox TextScript;
        public static AbstractTerminal Terminal;
        Brush br = new SolidColorBrush(Colors.Aquamarine);
        public MainWindow()
        {
            InitializeComponent();
            commandInTerminal.Add("get-process");
            this.DataContext = this;

            
            ////TextBox t = new TextBox();
            ////t.Undo();
            //TextScript.Text = "get-process"; // | sort-object | force-recurce";
            //TextScript.Text = "get-childitem * -include *.csv -recurse | remove-item";

            //TextScript = new RichTextBox();

            TabItem tb = new TabItem();
            tb.Header = "untl1";
            TabControlScript.Items.Add(tb);
            ScriptTab scriptTab1 = new ScriptTab(new FlowDocument(), tb);
            scriptTabsList.Add(scriptTab1);

            TabItem tb2 = new TabItem();
            tb2.Header = "untl2";
            TabControlScript.Items.Add(tb2);
            ScriptTab scriptTab2 = new ScriptTab(new FlowDocument(), tb2);
            scriptTabsList.Add(scriptTab2);

            TabItem tb3 = new TabItem();
            tb3.Header = "untl3";
            TabControlScript.Items.Add(tb3);
            ScriptTab scriptTab3 = new ScriptTab(new FlowDocument(), tb3);
            scriptTabsList.Add(scriptTab3);

            // Создание привязки
            CommandBinding bind = new CommandBinding(ApplicationCommands.New);

            // Присоединение обработчика событий
            bind.Executed += NewScriptExecuted;

            // Регистрация привязки
            this.CommandBindings.Add(bind);

            CommandBinding bind2 = new CommandBinding(ApplicationCommands.Open);
            bind2.Executed += ShowOpenFileDialog;
            this.CommandBindings.Add(bind2);

            CommandBinding bind3 = new CommandBinding(ApplicationCommands.Save);
            bind3.Executed += SaveScript;
            this.CommandBindings.Add(bind3);

            CommandBinding bind4 = new CommandBinding(ApplicationCommands.Find);
            bind4.Executed += OpenSettings;
            this.CommandBindings.Add(bind4);

            CommandBinding bind5 = new CommandBinding(ApplicationCommands.Copy);
            bind5.Executed += CopyTextInRichbox;
            this.CommandBindings.Add(bind5);

            CommandBinding bind6 = new CommandBinding(ApplicationCommands.Paste);
            bind6.Executed += PasteTextInRichbox;
            this.CommandBindings.Add(bind6);

            CommandBinding bind7 = new CommandBinding(ApplicationCommands.Undo);
            bind7.Executed += UndoTextInRichbox;
            this.CommandBindings.Add(bind7);

            CommandBinding bind8 = new CommandBinding(ApplicationCommands.Undo);
            bind8.Executed += RedoTextInRichbox;
            this.CommandBindings.Add(bind8);

            CommandBinding bind9 = new CommandBinding(ApplicationCommands.NotACommand);
            bind9.Executed += CompileScript;
            this.CommandBindings.Add(bind9);

            CommandBinding bind10 = new CommandBinding(ApplicationCommands.Help);
            bind10.Executed += HelpPowerShell;
            this.CommandBindings.Add(bind10);


            MainWindow.Terminal = new PowerShellTerminal();//new SolidColorBrush(Colors.Aquamarine), new SolidColorBrush(Colors.HotPink));
            MainWindow.Terminal.Style = StyleFromSettingsDocument();
            SettingsForTerminal();
 
            //DataContext = terminal.Style.InputTextBoxBrush;
            // FlowDocument doc = new FlowDocument();
            // Paragraph par = new Paragraph();
            // par.Inlines.Add(new Run("get-process -name chrome"));
            //// par.Inlines.Add(new Run("get-process"));
            // doc.Blocks.Add(par);
            // TextScript.Document = doc;

            TabControlScript.SelectedIndex = 0;
            prev = TabControlScript.SelectedIndex;

            //  MessageBox.Show(MainWindow.Terminal.Style.MainColor.ToString());
            // MainColor = new SolidColorBrush(Colors.Aqua);//MainWindow.Terminal.Style.MainColor

            //MainColor = terminal.Style.MainColor;

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


            // FlowDocument document = new FlowDocument();
            // Paragraph paragraph = new Paragraph();
            // // paragraph.Inlines.Add((new Run("текст")));//\n работает" + "И прибавления тоже" + "Удачи")));
            // //paragraph.Inlines.Add(new Run("hello-hello \n"));
            // paragraph.Inlines.Add(new Run("get-process -name chrome"));
            //// Paragraph p = new Paragraph();
            //// p.Inlines.Add("gfd");
            // //paragraph.Inlines.Add(new Run("\ngess"));
            // //paragraph.Inlines.Add(new Run("\ngerocess"));
            // //paragraph.Inlines.Add(new Run("hello -hello \n"));
            // document.Blocks.Add(paragraph);
            // paragraph = new Paragraph();
            // paragraph.Inlines.Add(new Run("get-command"));
            // document.Blocks.Add(paragraph);
            //// document.Blocks.Add(p);
            // tbOut.Document = document;

            //string[] str = GetDocumentText(tbOut.Document).Split('\n');
            //for(int i=0;i<str.Length-1;i++)
            //{
            //    Lexer lexer = new Lexer(str[i]);
            //    ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
            //    test.CreateSyntaxTree();
            //    CommandCollection collection = new CommandCollection(test);
            //    string o = "";
            //    string obj = collection.Excute(null, o);
            //    tb.AppendText(obj);
            //    //int numberOfParag = obj.Split('\n').Length;
            //    //for(int j=0; j< numberOfParag;j++)
            //    //{
            //        //Paragraph paragr = new Paragraph();
            //        //paragr.Inlines.Add(obj);
            //        //tbOut.Document.Blocks.Add(paragr);
            //   // }
            //    //MessageBox.Show(obj);
            //}

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
            ////tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
            //var start = tbOut.Document.ContentStart;
            //while (start != null && start.CompareTo(tbOut.Document.ContentEnd) < 0)
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
            //            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue));
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

            //f = 11;

            //ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            //(TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Background = new SolidColorBrush(Colors.Black);
        }

        private void HelpPowerShell(object sender, ExecutedRoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("powershell.exe");
            Process.Start(startInfo);
        }

        private void CompileScript(object sender, ExecutedRoutedEventArgs e)
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            RunCommand((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox));
        }

        private void RedoTextInRichbox(object sender, ExecutedRoutedEventArgs e)
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Redo();
        }

        private void UndoTextInRichbox(object sender, ExecutedRoutedEventArgs e)
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Undo();
        }

        private void PasteTextInRichbox(object sender, ExecutedRoutedEventArgs e)
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            string paste = Clipboard.GetText();
           // (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition.InsertTextInRun(paste);
           // (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition.GetPositionAtOffset(0,LogicalDirection.Forward);
            //(TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).CaretPosition.GetInsertionPosition(LogicalDirection.Backward).InsertTextInRun(paste);
        }

        private void CopyTextInRichbox(object sender, ExecutedRoutedEventArgs e)
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            //MessageBox.Show(((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Selection).Text);
            Clipboard.SetText(((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Selection).Text);
        }
        private void NewScriptExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TabItem t = new TabItem();
            t.Header = "untl"+(scriptTabsList.Count+1).ToString();
            TabControlScript.Items.Add(t);
            ScriptTab newScriptTab = new ScriptTab(new FlowDocument(), t);
            scriptTabsList.Add(newScriptTab);
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

        private void RunCommand(RichTextBox rtb)
        {
            string[] str = GetDocumentText(rtb.Document).Split('\n'); // GetDocumentText(TextScript.Document).Split('\n');
            for (int i = 0; i < str.Length - 1; i++)
            {
                Lexer lexer = new Lexer(str[i]);
                ScriptComNonterminalExpression test = new ScriptComNonterminalExpression(TokenReader.TokenReaderList);
                test.CreateSyntaxTree();
                CommandCollection collection = new CommandCollection(test);
                string o = "";
                string obj = collection.Excute(null, o);
                tb.AppendText(obj);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //SettingsWindow w = new SettingsWindow();
            //w.Owner = this;
            //w.ShowDialog();
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            TextRange range = new TextRange((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentStart, (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentEnd);
            range.ApplyPropertyValue(TextElement.FontSizeProperty, SizeOfFont.ToString());
           // (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Undo();
            //StyleFromSettingsDocument();
            //RunCommand((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox));
            //UpdateRTB();
            //tb.Text = "";
            //WriteChagedToDocument((TabItem)TabControlScript.SelectedItem);

            //ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            //TextRange textCommand = new TextRange((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentStart,
            //    (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentEnd);
            //if (textCommand.Text != "\r\n")
            //{
            //    RunCommand((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox));
            //}
            //else
            //{
            //    tb.Text = "Empty";
            //}
            //SettingsWindow set = new SettingsWindow();
            //set.ShowDialog();
        }

        //private void Azaza()
        //{
        //    TextRange text = new TextRange(TextScript.Document.ContentStart, TextScript.Document.ContentEnd);
        //    string currentSplitText = text.Text.Split('\r')[0];
        //    string[] currentText = currentSplitText.Split(' ');

        //    for (int i = 0; i < commandInTerminal.Count; i++)
        //    {
        //        if (currentText[currentText.Length - 1] == "")
        //        {
        //            // method
        //            text.ClearAllProperties();
        //            MatchCollection regex_results = Regex.Matches(text.Text, @"(.*?)-(.*?)\s");
        //            if (regex_results.Count != 0)
        //            {
        //                string res2 = regex_results[0].Groups[0].Value;

        //                //// string pattern = @"hello";
        //                Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

        //                //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
        //                //// allText.ClearAllProperties();
        //                // tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
        //                if (regex.ToString() == "get-process")
        //                {
        //                    var start = TextScript.Document.ContentStart;
        //                    while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
        //                    {
        //                        if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //                        {
        //                            var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                            // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                            //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                            //Match m = Regex.Match(match.ToString(), @".*?$");
        //                            ////string s = m.ToString().Split(' ')[0];
        //                            //string[] s = match.ToString().Split(' ');

        //                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));

        //                            start = textrange.End;

        //                            //else



        //                        }
        //                        start = start.GetNextContextPosition(LogicalDirection.Forward);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (!Char.IsWhiteSpace(text.Text[text.Text.Length - 1]))
        //    {
        //        //var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
        //        text.ClearAllProperties();
        //        MatchCollection regex_results = Regex.Matches(text.Text, @"(.*?)-(.*?)\s");
        //        //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
        //        //string res1 = regex_results[0].Groups[0].Value;
        //        if (regex_results.Count != 0)
        //        {
        //            string res2 = regex_results[0].Groups[0].Value;

        //            //// string pattern = @"hello";
        //            Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

        //            //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
        //            //// allText.ClearAllProperties();
        //            // tbOut.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
        //            if (regex.ToString() == "get-process")
        //            {
        //                var start = TextScript.Document.ContentStart;
        //                while (start != null && start.CompareTo(TextScript.Document.ContentEnd) < 0)
        //                {
        //                    if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //                    {
        //                        var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                        // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                        //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                        //Match m = Regex.Match(match.ToString(), @".*?$");
        //                        ////string s = m.ToString().Split(' ')[0];
        //                        //string[] s = match.ToString().Split(' ');
        //                        if (match.ToString() == "get-process")
        //                        {
        //                            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                                start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
        //                            if (textrange.Text == "")
        //                            {
        //                                int b = 0;
        //                            }

        //                            start = textrange.End;
        //                        }
        //                        //else
        //                        {

        //                        }
        //                    }
        //                    start = start.GetNextContextPosition(LogicalDirection.Forward);
        //                }
        //            }
        //        }
        //    }
        //}

        //private void SpacePowerCmdltHighlight(FlowDocument document)
        //{
        //    var allText = new TextRange(document.ContentStart, document.ContentEnd);
        //    allText.ClearAllProperties();
        //    MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\s");

        //    if (regex_results.Count != 0)
        //    {
        //        string res2 = regex_results[0].Groups[0].Value;

        //        //// string pattern = @"hello";
        //        Regex regex = new Regex(res2.Split(' ')[0], RegexOptions.IgnoreCase);

        //        var start = document.ContentStart;
        //        while (start != null && start.CompareTo(document.ContentEnd) < 0)
        //        {
        //            if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //            {
        //                var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                //Match m = Regex.Match(match.ToString(), @".*?$");
        //                ////string s = m.ToString().Split(' ')[0];
        //                //string[] s = match.ToString().Split(' ');
        //                if (match.ToString() == "get-process")
        //                {
        //                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
        //                    if (textrange.Text == "")
        //                    {
        //                        int b = 0;
        //                    }

        //                    start = textrange.End;
        //                }
        //                //else
        //                {

        //                }
        //            }
        //            start = start.GetNextContextPosition(LogicalDirection.Forward);
        //        }
        //    }
        //}

        //private void EnterPowerCmdltHighlight(FlowDocument document)
        //{
        //    var allText = new TextRange(document.ContentStart, document.ContentEnd);
        //    allText.ClearAllProperties();
        //    MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)\n");

        //    if (regex_results.Count != 0)
        //    {
        //        string res2 = regex_results[0].Groups[0].Value;

        //        //// string pattern = @"hello";
        //        Regex regex = new Regex(res2, RegexOptions.IgnoreCase); ////???????????????????????????????????????????????????????????????????????????

        //        var start = document.ContentStart;
        //        while (start != null && start.CompareTo(document.ContentEnd) < 0)
        //        {
        //            if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //            {
        //                var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                //Match m = Regex.Match(match.ToString(), @".*?$");
        //                ////string s = m.ToString().Split(' ')[0];
        //                //string[] s = match.ToString().Split(' ');
        //                if (match.ToString() == "get-process")
        //                {
        //                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Aquamarine));
        //                    if (textrange.Text == "")
        //                    {
        //                        int b = 0;
        //                    }

        //                    start = textrange.End;
        //                }
        //                //else
        //                {

        //                }
        //            }
        //            start = start.GetNextContextPosition(LogicalDirection.Forward);
        //        }
        //    }
        //}

        //private void SpaceParameterPowerCmdltHighlight(FlowDocument document)
        //{
        //    var allText = new TextRange(document.ContentStart, document.ContentEnd);
        //    allText.ClearAllProperties();
        //    MatchCollection regex_results = Regex.Matches(allText.Text, @"\s-(.*?)\s");
        //    //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
        //    //string res1 = regex_results[0].Groups[0].Value;
        //    if (regex_results.Count != 0)
        //    {
        //        string res2 = regex_results[0].Groups[0].Value;

        //        //// string pattern = @"hello";
        //        Regex regex = new Regex(res2.Split(' ')[1], RegexOptions.IgnoreCase);

        //        //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
        //        //// allText.ClearAllProperties();
        //        //TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
        //        var start = document.ContentStart;
        //        while (start != null && start.CompareTo(document.ContentEnd) < 0)
        //        {
        //            if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //            {
        //                var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                //Match m = Regex.Match(match.ToString(), @".*?$");
        //                ////string s = m.ToString().Split(' ')[0];
        //                //string[] s = match.ToString().Split(' ');
        //                if (match.ToString() == "-name")
        //                {
        //                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.HotPink));
        //                    if (textrange.Text == "")
        //                    {
        //                        int b = 0;
        //                    }

        //                    start = textrange.End;
        //                }
        //                //else
        //                {

        //                }
        //            }
        //            start = start.GetNextContextPosition(LogicalDirection.Forward);
        //        }
        //    }
        //}

        //private void EnterParameterPowerCmdltHighlight(FlowDocument document)
        //{
        //    var allText = new TextRange(document.ContentStart, document.ContentEnd);
        //    allText.ClearAllProperties();
        //    MatchCollection regex_results = Regex.Matches(allText.Text, @"-(.*?)\n");
        //    //MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*?)");
        //    //string res1 = regex_results[0].Groups[0].Value;
        //    if (regex_results.Count != 0)
        //    {
        //        string res2 = regex_results[0].Groups[0].Value;

        //        //// string pattern = @"hello";
        //        Regex regex = new Regex(res2.Split('\r')[0], RegexOptions.IgnoreCase);/////////?????????????????????????????????????????????????????????????????????

        //        //// var allText = new TextRange(tbOut.Document.ContentStart, tbOut.Document.ContentEnd);
        //        //// allText.ClearAllProperties();
        //        //TextScript.Document.Blocks.Add(new Paragraph(new Run(regex.ToString())));
        //        var start = document.ContentStart;
        //        while (start != null && start.CompareTo(document.ContentEnd) < 0)
        //        {
        //            if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        //            {
        //                var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));
        //                // string[] matchMass = match.ToString().Split(@'(\s+)');
        //                //if (match.Value != "get-process\n" || match.Value != "get-process ")
        //                //Match m = Regex.Match(match.ToString(), @".*?$");
        //                ////string s = m.ToString().Split(' ')[0];
        //                //string[] s = match.ToString().Split(' ');
        //                if (match.ToString() == "-name")
        //                {
        //                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
        //                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
        //                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.HotPink));
        //                    if (textrange.Text == "")
        //                    {
        //                        int b = 0;
        //                    }

        //                    start = textrange.End;
        //                }
        //                //else
        //                {

        //                }
        //            }
        //            start = start.GetNextContextPosition(LogicalDirection.Forward);
        //        }
        //    }
        //}

        #region Norm
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
            {
                pb.position.ApplyPropertyValue(TextElement.ForegroundProperty, pb.brush);
                //pb.position.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }

        #endregion

        Brush GetBrushForTokenType(TokenType tokenType)
        {

            switch (tokenType)
            {
                case TokenType.Command: return MainWindow.Terminal.CommandHighlight();
                case TokenType.Parameter: return MainWindow.Terminal.ParameterHighlight();
                case TokenType.Punct: return MainWindow.Terminal.Style.FontColor();
            }
            return MainWindow.Terminal.Style.UserFontForeground;
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

        async Task UpdateRTB()
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            //object text = TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox;
            (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).IsEnabled = false;
            var doc = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document;
            foreach (var par in GetParagraphs(doc.Blocks).ToList())
                await UpdateParagraph(par);
            (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).IsEnabled = true;
            UpdateFontSize();
        }
        #endregion

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

        private void WriteChagedToDocument(TabItem tabitem)
        {
            for(int i=0;i<scriptTabsList.Count;i++)
            {
                if(scriptTabsList.ElementAt(i).TabItem.Equals(tabitem))
                {
                    MessageBox.Show(i.ToString());
                    ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
                    scriptTabsList.ElementAt(i).Document = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document;
                }
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //(sender as Border).BorderThickness = new Thickness(2);
            //(sender as Border).BorderBrush = new SolidColorBrush(Colors.Gray);
            //(sender as Border).Background = new SolidColorBrush(Colors.Transparent);
            //MessageBox.Show(e.Handled.ToString());
            MessageBox.Show((TabControlScript.SelectedItem as TabItem).Header.ToString());
        }

        private void TabControlScript_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                //TextRange text = new TextRange(scriptTabsList.ElementAt(prev).Document.ContentStart, scriptTabsList.ElementAt(prev).Document.ContentEnd);
                //MessageBox.Show(text.Text);

                ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
                scriptTabsList.ElementAt(prev).Document.Blocks.Clear();        
                CopyText((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document, scriptTabsList.ElementAt(prev).Document);
                //text = new TextRange(scriptTabsList.ElementAt(prev).Document.ContentStart, scriptTabsList.ElementAt(prev).Document.ContentEnd);
                //MessageBox.Show(text.Text);
                //scriptTabsList.ElementAt(prev).Document = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document;
                prev = TabControlScript.SelectedIndex;
                (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.Blocks.Clear();
                CopyText(scriptTabsList.ElementAt(prev).Document, (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document);

                //  MessageBox.Show(prev.ToString());

            }
            UpdateRTB();
        }
        private void CopyText(FlowDocument docCopyIn, FlowDocument docCopyOut)
        {
            var doc = docCopyIn;
            List<string> splitText = new List<string>();
            string[] splitTextNewLine = GetDocumentText(docCopyIn).Split('\n');
            for(int i=0;i<splitTextNewLine.Length-1;i++)
            {
                string[] splitTextR = splitTextNewLine[i].Split('\r');
                splitText.Add(splitTextR[0]);
            }
            for(int i=0;i<splitText.Count;i++)
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new Run(splitText[i]));
                docCopyOut.Blocks.Add(paragraph);
            }
           // UpdateRTB();
            //MessageBox.Show(GetDocumentText(docCopyIn));
        }

        private string SaveTextScript(FlowDocument document)
        {
            List<string> splitText = new List<string>();
            string[] splitTextNewLine = GetDocumentText(document).Split('\n');
            for (int i = 0; i < splitTextNewLine.Length - 1; i++)
            {
                string[] splitTextR = splitTextNewLine[i].Split('\r');
                splitText.Add(splitTextR[0]);
            }
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<splitText.Count;i++)
            {
                sb.AppendLine(splitText.ElementAt(i));
            }
            return sb.ToString();
        }

        private void ShowOpenFileDialog(object sender, ExecutedRoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".ps1";
            dlg.Filter = "PowerShell scripts (.ps1)|*.ps1";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                string[] textInFile = File.ReadAllLines(filename);
                FlowDocument doc = new FlowDocument();
                for(int i=0;i<textInFile.Length;i++)
                {
                    doc.Blocks.Add(new Paragraph(new Run(textInFile[i])));
                }
                TextRange t = new TextRange(doc.ContentStart, doc.ContentEnd);
                MessageBox.Show(t.Text);
                TabItem tab = new TabItem();
                tab.Header = filename.Split('\\')[filename.Split('\\').Length-1];
                ScriptTab scriptTab = new ScriptTab(doc, tab);
                scriptTab.Path = filename;
                scriptTab.Name = tab.Header.ToString();
                TabControlScript.Items.Add(tab);
                scriptTabsList.Add(scriptTab);
                //    FileNameTextBox.Text = filename;
            }
        }

        private void ShowSaveFileDialog()
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = (TabControlScript.SelectedItem as TabItem).Header.ToString(); // Default file name
            dlg.DefaultExt = ".ps1"; // Default file extension
            dlg.Filter = "PowerShell scripts (.ps1)|*.ps1"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //File.Create(filename);
                for (int i = 0; i < scriptTabsList.Count; i++)
                {
                    if(scriptTabsList.ElementAt(i).TabItem == TabControlScript.SelectedItem as TabItem)
                    {
                        scriptTabsList.ElementAt(i).TabItem.Header = dlg.FileName.Split('\\')[filename.Split('\\').Length - 1].Split('.')[0];
                        scriptTabsList.ElementAt(i).Path = dlg.FileName;
                        scriptTabsList.ElementAt(i).Name = dlg.FileName.Split('\\')[filename.Split('\\').Length - 1].Split('.')[0];
                        ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
                        //scriptTabsList.ElementAt(i).Document = (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document;
                        CopyText((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document, scriptTabsList.ElementAt(i).Document);
                        string cont = SaveTextScript(scriptTabsList.ElementAt(i).Document);
                        File.WriteAllText(filename, cont);
                        break;
                        //File.AppendText(SaveScript(scriptTabsList.ElementAt(i).Document));
                    }
                }
                (TabControlScript.SelectedItem as TabItem).Header = dlg.FileName.Split('\\')[filename.Split('\\').Length - 1].Split('.')[0];
                //File.AppendText(SaveScript())
            }
        }

        private void ReSaveScript()
        {
            for (int i = 0; i < scriptTabsList.Count; i++)
            {
                if (scriptTabsList.ElementAt(i).TabItem == TabControlScript.SelectedItem as TabItem)
                {
                    File.WriteAllText(scriptTabsList.ElementAt(i).Path, "");
                    FlowDocument fakeDoc = new FlowDocument();
                    CopyText(fakeDoc, scriptTabsList.ElementAt(i).Document);
                    ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
                    CopyText((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document, scriptTabsList.ElementAt(i).Document);
                    string cont = SaveTextScript(scriptTabsList.ElementAt(i).Document);
                    File.WriteAllText(scriptTabsList.ElementAt(i).Path, cont);
                    break;
                    //File.AppendText(SaveScript(scriptTabsList.ElementAt(i).Document));
                }
            }
        }

        private void SaveScript(object sender, ExecutedRoutedEventArgs e)
        {
            for (int i = 0; i < scriptTabsList.Count; i++)
            {
                if (scriptTabsList.ElementAt(i).TabItem == TabControlScript.SelectedItem as TabItem)
                {
                    if(IsSaved(scriptTabsList.ElementAt(i)))
                    {
                        ReSaveScript();
                        break;
                    }
                    else
                    {
                        ShowSaveFileDialog();
                        break;
                    }
                }
            }
        }
        private bool IsSaved(ScriptTab script)
        {
            if (script.Path != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OpenSettings(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow(this);
            set.ShowDialog();
            UpdateRTB();
        }


        /////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #region BindingProperty
        public SolidColorBrush MainColor
        {
            get
            {
                return MainWindow.Terminal.Style.MainColor as SolidColorBrush;//_back;//MainWindow.Terminal.Style.MainColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.MainColor = value; //_back = value; MainWindow.Terminal.Style.MainColor = value;
                NotifyPropertyChanged("MainColor");
            }
        }
        public SolidColorBrush MarkingColor
        {
            get
            {
                return MainWindow.Terminal.Style.MarkingColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.MarkingColor = value;
                this.NotifyPropertyChanged("MarkingColor");
            }
        }

        public SolidColorBrush BorderColor
        {
            get
            {
                return MainWindow.Terminal.Style.BorderColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.BorderColor = value;
                this.NotifyPropertyChanged("BorderColor");
            }
        }

        public SolidColorBrush BorderTabItemColor
        {
            get
            {
                return MainWindow.Terminal.Style.BorderTabItemColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.BorderTabItemColor = value;
                this.NotifyPropertyChanged("BorderTabItemColor");
            }
        }

        public SolidColorBrush MarkingTabItemColor
        {
            get
            {
                return MainWindow.Terminal.Style.MarkingTabItemColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.MarkingTabItemColor = value;
                this.NotifyPropertyChanged("MarkingTabItemColor");
            }
        }

        public SolidColorBrush BackgroundTabItemColor
        {
            get
            {
                return MainWindow.Terminal.Style.BackgroundTabItemColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.BackgroundTabItemColor = value;
                this.NotifyPropertyChanged("BackgroundTabItemColor");
            }
        }

        public SolidColorBrush InputTextBoxBrush
        {
            get
            {
                return MainWindow.Terminal.Style.InputTextBoxBrush as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.InputTextBoxBrush = value;
                this.NotifyPropertyChanged("InputTextBoxBrush");
            }
        }

        public SolidColorBrush OutputTextBoxBrush
        {
            get
            {
                return MainWindow.Terminal.Style.OutputTextBoxBrush as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.OutputTextBoxBrush = value;
                this.NotifyPropertyChanged("OutputTextBoxBrush");
            }
        }

        public int SizeOfFont
        {
            get
            {
                return MainWindow.Terminal.Style.FontSize;
            }

            set
            {
                MainWindow.Terminal.Style.FontSize = value;
                this.NotifyPropertyChanged("SizeOfFont");
            }
        }

        public SolidColorBrush UserFontForeground
        {
            get
            {
                return MainWindow.Terminal.Style.UserFontForeground as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.UserFontForeground = value;
                this.NotifyPropertyChanged("FontForeground");
            }
        }

        public SolidColorBrush ParameterHighlight
        {
            get
            {
                return MainWindow.Terminal.HighLight.ParameterBrush();
            }
            set
            {
                (MainWindow.Terminal.HighLight as PowershellHighlight).ParameterHighlight = value;
                this.NotifyPropertyChanged("ParameterHighlight");
            }
        }

        public SolidColorBrush CommandHighlight
        {
            get
            {
                return MainWindow.Terminal.HighLight.CommandBrush();
            }

            set
            {
                (MainWindow.Terminal.HighLight as PowershellHighlight).CommandHighlight = value;
                this.NotifyPropertyChanged("CommandHighlight");
            }
        }

        public SolidColorBrush FontForeground
        {
            get
            {
                return MainWindow.Terminal.Style.FontForeground as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.FontForeground = value;
                this.NotifyPropertyChanged("FontForeground");
            }
        }

        public SolidColorBrush SeparatorColor
        {
            get
            {
                return MainWindow.Terminal.Style.SeparatorColor as SolidColorBrush;
            }

            set
            {
                MainWindow.Terminal.Style.SeparatorColor = value;
                this.NotifyPropertyChanged("SeparatorColor");
            }
        }

        #endregion

        private void CreateSettingsFile()
        {
            FileInfo file = new FileInfo("settings.ini");
            if (!file.Exists)
                file.Create();
            else MessageBox.Show("File has been created");
        }

        private void WriteChangeToSettingsDocument(string style, string inputTexboxColor, string outputTexboxColor, string fontColor, string fontSize, string userFontForeground
            ,string commandHightLight, string parameterHightLight)
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
                sb.Append(parameterHightLight);
                writer.Write(sb.ToString());
                writer.Close();
            }
        }

        private string ReadSettingsDocument()
        {
            FileStream file = new FileStream("settings.ini", FileMode.Open);
            string outputString="";
            using (StreamReader reader = new StreamReader(file))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(reader.ReadToEnd());
                reader.Close();
                outputString = sb.ToString();
            }
            return outputString;
        }
        private StyleBase StyleFromSettingsDocument()
        {
            string style = ReadSettingsDocument();
            Type T = null;
            if (style != "")
            {
                style = ReadSettingsDocument().Split('\n')[0].Split(' ')[1].Split('\r')[0];
                T = Type.GetType("PSterminal." + style + "Style");
            }
            else
                T = Type.GetType("PSterminal.LightSideStyle");
            object obj = Activator.CreateInstance(T);
            return (StyleBase)obj;
            //Type T = Type.GetType("PSterminal." + nameCommand + "Command");
           // object Obj = Activator.CreateInstance(T);
        }
        private void SettingsForTerminal()
        {
            string[] settings = ReadSettingsDocument().Split('\n');
            InputTextBoxBrush = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[1].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[1].Split(',')[1])
                , Convert.ToByte(settings[1].Split(',')[2]), Convert.ToByte(settings[1].Split(',')[3])));
            OutputTextBoxBrush = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[2].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[2].Split(',')[1])
                , Convert.ToByte(settings[2].Split(',')[2]), Convert.ToByte(settings[2].Split(',')[3])));
            FontForeground = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[3].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[3].Split(',')[1])
                , Convert.ToByte(settings[3].Split(',')[2]), Convert.ToByte(settings[3].Split(',')[3])));
            SizeOfFont = Convert.ToInt32(settings[4].Split(' ')[1]);
            UserFontForeground = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[5].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[5].Split(',')[1])
                , Convert.ToByte(settings[5].Split(',')[2]), Convert.ToByte(settings[5].Split(',')[3])));
            CommandHighlight = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[6].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[6].Split(',')[1])
                , Convert.ToByte(settings[6].Split(',')[2]), Convert.ToByte(settings[6].Split(',')[3])));
            ParameterHighlight = new SolidColorBrush(Color.FromArgb(Convert.ToByte(settings[7].Split(',')[0].Split(' ')[1]), Convert.ToByte(settings[7].Split(',')[1])
               , Convert.ToByte(settings[7].Split(',')[2]), Convert.ToByte(settings[7].Split(',')[3])));
        }

        private void UpdateFontSize()
        {
            ContentPresenter cp = TabControlScript.Template.FindName("PART_SelectedContentHost", TabControlScript) as ContentPresenter;
            TextRange range = new TextRange((TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentStart, (TabControlScript.ContentTemplate.FindName("TextScript", cp) as RichTextBox).Document.ContentEnd);
            range.ApplyPropertyValue(TextElement.FontSizeProperty, SizeOfFont.ToString());
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
