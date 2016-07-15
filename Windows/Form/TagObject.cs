using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secl.Windows.Form
{
    public struct TagObject
    {
        private object tag;
        private object tag1;
        private object tag2;

        /// <summary>
        /// Gets or sets the a tag object.
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        /// Gets or sets the a tag object.
        /// </summary>
        public object Tag1
        {
            get { return tag1; }
            set { tag1 = value; }
        }

        /// <summary>
        /// Gets or sets the a tag object.
        /// </summary>
        public object Tag2
        {
            get { return tag2; }
            set { tag2 = value; }
        }
    }
}
