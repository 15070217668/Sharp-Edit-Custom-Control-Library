using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace secl.Windows.Form
{
    [ToolboxItem(true)]
    public sealed class SharpButton : ControlBase
    {
        private ThemeColorManger.ButtonGradient colors;

        /// <summary>
        /// The Theme style of the button.
        /// </summary>
        [SettingsBindable(true)]
        public ThemeColorManger.ButtonGradient DisplayConfig
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
                this.Invalidate();
            }
        }

        ThemeColorManger manager;

        public SharpButton()
        {
            manager = new ThemeColorManger(ThemeStyle.Gradient);
            colors = new ThemeColorManger.ButtonGradient();
            colors.BackgroundDown = Color.FromArgb(233, 233, 233);
            colors.BackgroundDown = Color.FromArgb(200, 200, 200);
            colors.BackgroundHover = Color.FromArgb(233, 233, 233);
            colors.BackgroundHover1 = Color.FromArgb(222, 222, 222);
            colors.BackgroundIdea = Color.FromArgb(233, 233, 233);
            colors.BackgroundIdea1 = Color.FromArgb(230, 230, 230);
            colors.Font = new Font("Open Sans", 10);
            colors.TextColor = Color.Black;
            colors.TextFormat = new ThemeColorManger.StringFormat() { Alignment = ThemeColorManger.StringFormat.StringAlign.Center, LineAlignment = ThemeColorManger.StringFormat.StringAlign.Center };
            manager.ButtonGradientColor = colors;
            ThemeManager.Draw(manager, Graphics);
        }
        public override void Paint(Graphics e)
        {
            e.DrawString(
                this.Text,
                DisplayConfig.Font,
                new SolidBrush(
                    this.DisplayConfig.TextColor),
                new Rectangle(0, 0, Width - 1, Height - 1),
                new StringFormat()
                {
                    Alignment = this.DisplayConfig.TextFormat.Alignment == ThemeColorManger.StringFormat.StringAlign.Center? StringAlignment.Center : this.DisplayConfig.TextFormat.Alignment == ThemeColorManger.StringFormat.StringAlign.Far? StringAlignment.Far : this.DisplayConfig.TextFormat.Alignment == ThemeColorManger.StringFormat.StringAlign.Near? StringAlignment.Near : StringAlignment.Center,
                    LineAlignment = this.DisplayConfig.TextFormat.LineAlignment == ThemeColorManger.StringFormat.StringAlign.Center ? StringAlignment.Center : this.DisplayConfig.TextFormat.LineAlignment == ThemeColorManger.StringFormat.StringAlign.Far ? StringAlignment.Far : this.DisplayConfig.TextFormat.LineAlignment == ThemeColorManger.StringFormat.StringAlign.Near ? StringAlignment.Near : StringAlignment.Center
                });
        }
    }
}
