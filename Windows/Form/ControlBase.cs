using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using secl.Windows.Form;

namespace secl
{
    public abstract class ControlBase :UserControl, IComponent, IDisposable
    {
        private string text;
        private MouseState state;
        private string name;
        private Graphics graphics;
        private ThemeManager themeManager;
        private TagObject objects;

        public TagObject Tags
        {
            get { return objects; }
            set { objects = value; }
        }

        public ThemeManager ThemeManager
        {
            get
            {
                return themeManager;
            }
            private set { themeManager = value; }
        }
        public new string Text
        {
            get { return text; }
            set
            {
                text = value;
            }
        }

        public MouseState State
        {
            get { return state; }
            set {
                state = value;
                this.Invalidate();
                this.Update();
            }
        }

        public new string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public Graphics Graphics
        {
            get { return this.graphics; }
            private set
            {
                this.graphics = value;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.State = MouseState.MouseDown;
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.State = MouseState.MouseOver;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseHover(EventArgs e)
        {
            this.State = MouseState.MouseOver;
            base.OnMouseHover(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.State = MouseState.MouseNone;
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.graphics = e.Graphics;
            Paint(this.graphics);
            base.OnPaint(e);
        }

        /// <summary>
        /// Paint the control base.
        /// </summary>
        /// <param name="e"></param>
        public abstract new void Paint(Graphics e);

        /// <summary>
        /// Initalize a new instance of <see cref="ControlBase"/> class.
        /// </summary>
        public ControlBase()
        {
            this.themeManager = new ThemeManager(this);
            this.Tags = new TagObject();
        }
    }
}
