using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PSterminal
{
    public class ScriptTab
    {
        private FlowDocument _document;
        private TabItem _tabItem;
        private string _path;
        private string _name;

        public ScriptTab(FlowDocument document, TabItem tabItem)
        {
            this.Document = document;
            this.TabItem = tabItem;
        }

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

        public TabItem TabItem
        {
            get
            {
                return _tabItem;
            }

            set
            {
                _tabItem = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }
}
