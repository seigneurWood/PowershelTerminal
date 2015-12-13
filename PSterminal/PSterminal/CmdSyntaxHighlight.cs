using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace PSterminal
{
    public class CmdSyntaxHighlight: SyntaxHighlight
    {
        private FlowDocument _document;

        public FlowDocument Document
        {
            get
            {
                return _document;
            }

            set
            {
                _document = value;
            }
        }

        public CmdSyntaxHighlight(FlowDocument doc)
        {
            Document = PaintOver(doc);
        }

        public FlowDocument PaintOver(FlowDocument richBox)
        {
            var allText = new TextRange(richBox.ContentStart, richBox.ContentEnd);
            MatchCollection regex_results = Regex.Matches(allText.Text, @"(.*?)\s");
            string res2 = regex_results[0].Groups[0].Value;
            Regex regex = new Regex(res2, RegexOptions.IgnoreCase);
            var start = richBox.ContentStart;
            while (start != null && start.CompareTo(richBox.ContentEnd) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    var match = regex.Match(start.GetTextInRun(LogicalDirection.Forward));

                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                    textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Gold));
                    textrange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

                    start = textrange.End;
                }
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }

            return richBox;
        }
    }
}
