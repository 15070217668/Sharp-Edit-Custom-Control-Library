using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace secl.Windows.Form
{
    public class ThemeManager
    {
        private Dictionary<string, ThemeColorManger> customThemes =
            new Dictionary<string, ThemeColorManger>();

        private ControlBase control;

        /// <summary>
        /// Initalize a new instance of <see cref="ThemeManager"/> class.
        /// </summary>
        public ThemeManager(ControlBase controlBase)
        {
            if(controlBase != null)
            {
                control = controlBase;
            }
        }

        /// <summary>
        /// Gets or sets weather this manager should draw the borders with a curve.
        /// </summary>
        public bool IsCurved
        {
            get;
            set;
        }
        /// <summary>
        /// Initalize a new instance of <see cref="ThemeManager"/> class.
        /// </summary>
        public ThemeManager()
        {
        }

        /// <summary>
        /// Add a theme to the collection.
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="name"></param>
        public void AddCustom(ThemeColorManger theme, string name)
        {
            this.customThemes.Add(name, theme);
        }

        private bool draw(ThemeColorManger theme,
            ControlBase control)
        {
            if (control.Graphics != null)
            {
                control.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                if (theme.Style == ThemeStyle.Gradient)
                {
                    if (theme.isButton)
                    {
                        System.Drawing.Drawing2D.LinearGradientBrush brush = null;
                        switch (control.State)
                        {
                            case MouseState.MouseDown:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundDown, theme.ButtonGradientColor.BackgroundDown1, 90f);
                                control.Graphics.FillRectangle(brush, control.ClientRectangle);
                                control.Graphics.DrawPath(new Pen(theme.ButtonGradientColor.Border), Style.GetRoundedRectangle(new Rectangle(0, 0, control.Width - 1, control.Height - 1), 5));
                                break;
                            case MouseState.MouseNone:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundIdea, theme.ButtonGradientColor.BackgroundIdea1, 90f);
                                control.Graphics.FillRectangle(brush, control.ClientRectangle);
                                break;
                            case MouseState.MouseOver:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundHover, theme.ButtonGradientColor.BackgroundHover1, 90f);
                                control.Graphics.FillRectangle(brush, control.ClientRectangle);
                                if (IsCurved)
                                {
                                    control.Graphics.DrawPath(new Pen(theme.ButtonGradientColor.Border), Style.GetRoundedRectangle(new Rectangle(0, 0, control.Width - 1, control.Height - 1), 5));
                                    control.Graphics.DrawPath(new Pen(theme.ButtonGradientColor.Border2), Style.GetRoundedRectangle(new Rectangle(1, 1, control.Width - 3, control.Height - 3), 5));
                                }
                                else
                                {
                                    control.Graphics.DrawRectangle(new Pen(theme.ButtonGradientColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                                    control.Graphics.DrawRectangle(new Pen(theme.ButtonGradientColor.Border2), new Rectangle(1, 1, control.Width - 3, control.Height - 3));
                                }
                                break;
                        }
                        return true;
                    }
                    else
                    {
                        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                            theme.GradientColor.Background1, theme.GradientColor.Background2, 90f);
                        control.Graphics.FillRectangle(brush, control.ClientRectangle);
                        control.Graphics.DrawRectangle(new Pen(theme.GradientColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                    }
                }
                else if (theme.Style == ThemeStyle.Solid)
                {
                    control.Graphics.FillRectangle(new SolidBrush(theme.SolidColor.Background), control.ClientRectangle);
                    control.Graphics.DrawRectangle(new Pen(theme.SolidColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                }

            }
            else
            {
                return false;
            }
            return false;
        }


        /// <summary>
        /// Draw a set of colors to a control.
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="graphics"></param>
        /// <returns></returns>
        public bool Draw(ThemeColorManger theme, Graphics graphics)
        {
            if (graphics != null)
            {
                if (theme.Style == ThemeStyle.Gradient)
                {
                    if (theme.isButton)
                    {
                        System.Drawing.Drawing2D.LinearGradientBrush brush = null;
                        switch (control.State)
                        {
                            case MouseState.MouseDown:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundDown, theme.ButtonGradientColor.BackgroundDown1, 90f);
                                break;
                            case MouseState.MouseNone:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundIdea, theme.ButtonGradientColor.BackgroundIdea1, 90f);
                                break;
                            case MouseState.MouseOver:
                                brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                                    theme.ButtonGradientColor.BackgroundHover, theme.ButtonGradientColor.BackgroundHover1, 90f);
                                break;
                        }
                        graphics.FillRectangle(brush, control.ClientRectangle);
                        graphics.DrawRectangle(new Pen(theme.ButtonGradientColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                        graphics.DrawRectangle(new Pen(theme.ButtonGradientColor.Border2), new Rectangle(1, 1, control.Width - 3, control.Height - 3));
                        return true;
                    }
                    else
                    {
                        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(control.ClientRectangle,
                            theme.GradientColor.Background1, theme.GradientColor.Background2, 90f);
                        graphics.FillRectangle(brush, control.ClientRectangle);
                        graphics.DrawRectangle(new Pen(theme.GradientColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                    }
                }
                else if (theme.Style == ThemeStyle.Solid)
                {
                    graphics.FillRectangle(new SolidBrush(theme.SolidColor.Background), control.ClientRectangle);
                    graphics.DrawRectangle(new Pen(theme.SolidColor.Border), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Draw the theme to a control.
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="control"></param>
        public void DrawTheme(ThemeColorManger theme, 
            ControlBase control)
        {
            this.draw(theme, control);
        }

        /// <summary>
        /// Draw custom theme.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="control"></param>
        public void DrawCustom(string name,
            ControlBase control)
        {
            ThemeColorManger theme = this.customThemes[name];
            this.draw(theme, control);
        }

        /// <summary>
        /// Apply this theme to this control.
        /// </summary>
        /// <param name="theme"></param>
        public void Apply(ThemeColorManger theme)
        {
            this.DrawTheme(theme, this.control);
        }

        /// <summary>
        /// Apply this theme to this control.
        /// </summary>
        /// <param name="name"></param>
        public void Apply(string name)
        {
            this.DrawCustom(name, this.control);
        }

        /// <summary>
        /// Get a theme color.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ThemeColorManger GetColors(string name)
        {
            return this.customThemes[name];
        }
    }

    public class ThemeColorManger
    {
        [Serializable]
        public class Gradient
        {
            public Color Border;
            public Color Background1;
            public Color Background2;
            public Font Font;
            public Color TextColor;
        }

        [Serializable]
        public class Solid
        {
            public Color Border;
            public Color Background;
            public Font Font;
            public Color TextColor;
        }

        [Serializable]
        public class ButtonGradient
        {
            public Color Border;
            public Color Border2;
            public Color BackgroundDown;
            public Color BackgroundDown1;
            public Color BackgroundHover;
            public Color BackgroundHover1;
            public Color BackgroundIdea;
            public Color BackgroundIdea1;
            public Font Font;
            public Color TextColor;
            public StringFormat TextFormat;
        }

        [Serializable]
        public class StringFormat
        {
            public StringAlign Alignment { get; set; }
            public StringAlign LineAlignment { get; set; }

            [Serializable]
            public enum StringAlign
            {
                Center,
                Near,
                Far
            }
        }
        /// <summary>
        /// This is only used if 
        /// ButtonGradientColor
        /// Solid as both null.
        /// </summary>
        public Gradient GradientColor;
        /// <summary>
        /// This is only used if 
        /// GradientColor
        /// Solid as both null.
        /// </summary>
        public ButtonGradient ButtonGradientColor;
        /// <summary>
        /// This is only used if 
        /// ButtonGradientColor
        /// GradientColor as both null.
        /// </summary>
        public Solid SolidColor;

        /// <summary>
        /// Is this instance of colors for a button.
        /// </summary>
        public bool isButton = false;

        /// <summary>
        /// The style of this color block;
        /// </summary>
        public ThemeStyle Style;

        /// <summary>
        /// Initalize a new instance of <see cref="ThemeColorManger"/>
        /// </summary>
        /// <param name="style"></param>
        public ThemeColorManger(ThemeStyle 
           style)
        {
            this.Style = style;
        }
    }
}
