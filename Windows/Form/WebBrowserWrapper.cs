using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secl.Windows.Form
{
    public class WebBrowserWrapper
        : WrapperBase
    {
        private WebBrowser browser;

        /// <summary>
        /// Initalize a new instance of <see cref="WebBrowserWrapper"/> class.
        /// </summary>
        /// <param name="wbB"></param>
        public WebBrowserWrapper(WebBrowser wbB)
        {
            if (wbB == null)
            {
                return;
            }
            browser = wbB;
        }

        /// <summary>
        /// Gets the title of the current page.
        /// </summary>
        public string Title
        {
            get { return this.browser.DocumentTitle; }
        }
        /// <summary>
        /// Gets or sets the text of this page.
        /// </summary>
        public string InnerText
        {
            get { return this.browser.DocumentText; }
            set { this.browser.DocumentText = value; }
        }
        /// <summary>
        /// Gets the type of document
        /// </summary>
        public object Type
        {
            get { return this.browser.DocumentType; }
        }

        /// <summary>
        /// Get an element by its id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object getElementById(string id)
        {
            if(browser.Document == null)
            {
                return null;
            }
            return browser.Document.GetElementById(id);
        }

        /// <summary>
        /// Excute a peace of script that is embeded inside the page.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object ExcuteScriptMethod(string name)
        {
            if(browser.Document == null)
            {
                return null;
            }
            return browser.Document.InvokeScript(name);
        }
    }

    public class WrapperBase
        :ControlBase
    {
        /// <summary>
        /// Paint Hook.
        /// </summary>
        /// <param name="e"></param>
        public override void Paint(Graphics
           e)
        {
            e.FillRectangle(new SolidBrush(
                Color.White),
                this.ClientRectangle
            );
        }

        private WebBrowser browserBase;
        private string source;
        private List<HistoryItem> history =
            new List<HistoryItem>();

        /// <summary>
        /// The recent searchs made by this wrapper.
        /// </summary>
        public List<HistoryItem> History
        {
            get { return history; }
            private set { history = value; }
        }

        /// <summary>
        /// The url of this instance.
        /// </summary>
        public string Url
        {
            get
            {
                return source;
            }
            set
            {
                if(source == ""||string.IsNullOrWhiteSpace(source))
                {
                    source = "about:blank";
                }
                source = value;
                if(this.browserBase != null)
                {
                    this.browserBase.Navigate(value);
                    History.Add(new HistoryItem() {
                        Name = this.browserBase.DocumentTitle,
                        Url = value
                    });
                }
            }
        }

        /// <summary>
        /// Initalize a new instance of <see cref="WrapperBase"/> class.
        /// </summary>
        /// <param name="wb"></param>
        public WrapperBase(WebBrowser wb)
        {
            this.history = new List<HistoryItem>();
            this.browserBase = wb;
        }

        /// <summary>
        /// Initalize a new instance of <see cref="WrapperBase"/> class.
        /// </summary>
        public WrapperBase() { } 

        public class HistoryItem
        {
            /// <summary>
            /// The url for this item;
            /// </summary>
            public string Url;
            /// <summary>
            /// The name of this item.
            /// </summary>
            public string Name;

            /// <summary>
            /// Initalize a new instance of <see cref="HistoryItem"/> class.
            /// </summary>
            public HistoryItem()
            {
            }
        }
    }
}
