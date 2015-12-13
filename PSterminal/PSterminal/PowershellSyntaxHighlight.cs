using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PSterminal
{
    public class PowershellSyntaxHighlight: SyntaxHighlight
    {
        private TextPointer _startPoint;
        private TextPointer _endPoint;
        private FlowDocument _richBox;

        public FlowDocument RichBox
        {
            get
            {
                return _richBox;
            }

            set
            {
                _richBox = value;
            }
        }

        public PowershellSyntaxHighlight(FlowDocument richBox)
        {
            RichBox = PaintOver(richBox);
        }

        public FlowDocument PaintOver(FlowDocument richBox)
        {
            // parameter
            var allText = new TextRange(richBox.ContentStart, richBox.ContentEnd);
            MatchCollection regex_results = Regex.Matches(allText.Text, @"\s-(.*?)\s");
            string res2 = regex_results[0].Groups[0].Value;
            Regex regex = new Regex(res2, RegexOptions.IgnoreCase);
            var start = richBox.ContentStart;
            while (start != null && start.CompareTo(richBox.ContentEnd) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));

                    Match m = Regex.Match(match.ToString(), @".*?$");
                    string s = m.ToString().Split(' ')[0];

                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                        start.GetPositionAtOffset(match.Index + s.Length, LogicalDirection.Backward));
                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.BlueViolet));
                    textrange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

                    start = textrange.End;
                }
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }
            // command

            regex_results = Regex.Matches(allText.Text, @"(.*?)-(.*)");
            //string res1 = regex_results[0].Groups[0].Value;
            res2 = regex_results[0].Groups[0].Value;
            regex = new Regex(res2, RegexOptions.IgnoreCase);
            start = richBox.ContentStart;
            while (start != null && start.CompareTo(richBox.ContentEnd) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));

                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Coral));

                    start = textrange.End;
                }
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }

            return richBox;
        }
    }
}
