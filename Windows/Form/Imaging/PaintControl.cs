using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secl.Windows.Form.Imaging
{
    public class PaintControl :
        ControlBase
    {
        private bool isPaining = false;
        private Image image;
        private Brush brush;

        public Brush BrushObject
        {
            get { return brush; }
            set { brush = value; }
        }

        /// <summary>
        /// Gets weather this control is doing a paint operation.
        /// </summary>
        public bool IsPaining
        {
            get
            {
                return isPaining;
            }
            private set { isPaining = value; }
        }

        #region Overrides
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.isPaining = true;
            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.isPaining = false;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.isPaining = true;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.isPaining = true;
            Graphics graphicsDevice = Graphics.FromImage(image);
            this.Cursor = Cursors.Cross;
            if(this.BrushObject == null)
            {
                return;
            }
            if (this.brush.Style == BrushStyle.Line)
            {
                graphicsDevice.FillEllipse(new SolidBrush(
                    this.brush.Color),
                    new Rectangle(e.X, e.Y, 2, 2));
            }
            else
            {
                graphicsDevice.FillEllipse(new SolidBrush(
                    this.brush.Color),
                    new Rectangle(e.X, e.Y, this.brush.Size, this.brush.Size));
            }
            Paint(this.Graphics);
        }
        #endregion

        public override void Paint(Graphics e)
        {
            e.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.DrawImage(image, 0, 0);
        }

        void initalizeNewImageBase()
        {
            this.image = new Bitmap(this.Width, this.Height);
        }

        public PaintControl()
        {
            this.initalizeNewImageBase();
        }

        [Serializable]
        public class Brush
        {
            /// <summary>
            /// The size of this brush.
            /// </summary>
            [DefaultValue(5)]
            public int Size { get; set; }
            /// <summary>
            /// The color to be used for this brush.
            /// </summary>
            [DefaultValue(typeof(Color), "Black")]
            public Color Color { get; set; }
            /// <summary>
            /// The style of this brush.
            /// </summary>
            [DefaultValue(typeof(BrushStyle), "Default")]
            public BrushStyle Style { get; set; }
        }

        [Serializable]
        public enum BrushStyle
        {
            /// <summary>
            /// The default style of the brush (PaintBrush)
            /// </summary>
            Default = 0x00001,
            /// <summary>
            /// A line styled brush
            /// </summary>
            Line = 0x00002,
        }

        /// <summary>
        /// Add an image to the current images.
        /// </summary>
        /// <param name="filePath"></param>
        public void AddImage(string filePath)
        {
            if(string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }
            this.image = Image.FromFile(filePath);
        }
    }
}
