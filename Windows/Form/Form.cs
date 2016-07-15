using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secl.Windows.Form
{
    public class FormEx  : System.Windows.Forms.Form
    {
        bool showBlur;
        bool hasComposition;
        IntPtr blurColor = new IntPtr(0xffffff);
        ThemeManager themeManager;

        /// <summary>
        /// Get or set the theme manager.
        /// And control the theme of alll this forms controls.
        /// </summary>
        public ThemeManager ThemeManager
        {
            get { return themeManager; }
            set { themeManager = value; }
        }

        /// <summary>
        /// Gets weather Composition is enabled on the system.
        /// </summary>
        public bool IsCompositionEnabled
        {
            get { return DWM.isDWMEnabled(); }
        }
        /// <summary>
        /// Gets or set weather this form has Composition.
        /// </summary>
        public bool HasComposition
        {
            get { return hasComposition; }
            set { hasComposition = value; }
        }
        /// <summary>
        /// Gets or sets weather this form shows the blur effect.
        /// </summary>
        public bool Showblur
        {
            get { return showBlur; }
            set
            {
                showBlur = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the blur behind this form.
        /// </summary>
        public IntPtr BlurColor
        {
            get { return blurColor; }
            set
            {
                blurColor = value;
            }
        }

        /// <summary>
        /// Initalize a new instance of <see cref="FormEx"/> class.
        /// </summary>
        public FormEx()
        {
            DWM_BLURBEHIND blur = new DWM_BLURBEHIND()
            {
                dwFlags = DWM_BB.BlurRegion,
                fEnable = showBlur,
                fTransitionOnMaximized = true,
                hRgnBlur = blurColor,
            };
            DWM.DwmEnableBlurBehindWindow(this.Handle, ref blur);

            if (!this.hasComposition)
                DWM.EnableComposition();
            else
                DWM.DisableComposition();
        }
    }
}
