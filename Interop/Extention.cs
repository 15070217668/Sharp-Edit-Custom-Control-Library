using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secl.Interop
{
    /// <summary>
    /// Extention class.
    /// </summary>
    public abstract class Extention
    {
        private Form parentForm;

        /// <summary>
        /// Get the tabControl on the window.
        /// </summary>
        /// <returns></returns>
        public CustomTabControl GetCurrentTabControl()
        {
            CustomTabControl tabControl = null;
            for(int i = 0; i< parentForm.Controls.Count; i++)
            {
                if(parentForm.Controls[i] is CustomTabControl)
                {
                    tabControl = parentForm.Controls[i] as CustomTabControl;
                    break;
                }
            }
            return tabControl;
        }

        /// <summary>
        /// Get the Folder TreeView on the window.
        /// </summary>
        /// <returns></returns>
        public TreeView GetCurrentProjectView()
        {
            TreeView projectView = null;
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i] is TreeView)
                {
                    projectView = parentForm.Controls[i] as TreeView;
                    break;
                }
            }
            return projectView;
        }

        /// <summary>
        /// Get the MainMenu on the window.
        /// </summary>
        /// <returns></returns>
        public MainMenu GetCurrentMenu()
        {
            return parentForm.Menu;
        }

        /// <summary>
        /// Get a control on the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Control GetControl(int index)
        {
            return parentForm.Controls[index];
        }

        /// <summary>
        /// Get a control on the window.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Control GetControl(string name)
        {
            Control control = null;
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if(parentForm.Controls[i].Name == name)
                {
                    control = parentForm.Controls[i];
                    break;
                }
            }
            return control;
        }

        /// <summary>
        /// Get the text editor on a tab page.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public SharpControl GetTextEditor(int index)
        {
            SharpControl editor = null;
            var tabControl = GetCurrentTabControl();
            var tab = tabControl.TabPages[index];

            for(int i = 0; i < tab.Controls.Count;i++)
            {
                if(tab.Controls[i] is SharpControl)
                {
                    editor = tab.Controls[i] as SharpControl;
                    break;
                }
            }
            return editor;
        }

        public abstract void Load(object obj);
        public abstract void AfterLoaded(object obj);

        /// <summary>
        /// Initalize a new instance of <see cref="Extention"/> Class.
        /// </summary>
        /// <param name="formWindow"></param>
        public Extention(Form formWindow)
        {
            this.parentForm = formWindow;
            Load(this);
        }
    }
}
