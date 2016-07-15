using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secl
{
    public class EventArgsEx : EventArgs
    {
        private bool cancel;

        /// <summary>
        /// Should this event be canceled?.
        /// </summary>
        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
    }
}
