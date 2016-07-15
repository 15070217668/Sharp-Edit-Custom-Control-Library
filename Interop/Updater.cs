using secl.Windows.Form;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secl.Interop
{
    public class Updater
    {
        private string versionLink = "http://sharptech.xyz/SharpEdit/assets/version.txt";
        private string versionDescriptionUrl = "http://sharptech.xyz/SharpEdit/assets/version-details.html";
        private string thisVersion = Properties.Settings.Default.currentVersion;


        /// <summary>
        /// Check for updates on this app.
        /// </summary>
        /// <param name="afterCheck"></param>
        /// <returns></returns>
        public UpdateTags Check(EventHandler afterCheck = null)
        {
            UpdateTags objects = new UpdateTags();
            WebClient client = new WebClient();
            if ( !Directory.Exists(Environment.CurrentDirectory + "/SharpEdit") )
                Directory.CreateDirectory(Environment.CurrentDirectory + "/SharpEdit");
            client.DownloadFileAsync(new Uri(versionLink), Environment.CurrentDirectory + "/SharpEdit/version.txt");
            var newVersion = "0000";
            using ( var stream = new StreamReader(Environment.CurrentDirectory + "/SharpEdit/version.txt") )
            {
                newVersion = stream.ReadLine();
                stream.Close();
            }
            objects.NewVersion = newVersion;
            objects.DescriptionLink = versionDescriptionUrl;
            objects.OldVersion = thisVersion;
            objects.DownloadLink = "http://sharptech.xyz/SharpEdit/assets/version.zip";
            if ( newVersion == thisVersion )
            {
                MessageBox.Show("You already have the latest version of SharpEdit");

            }
            else
            {
                if(afterCheck != null )
                {
                    afterCheck(objects, new EventArgs());
                }
            }
            return objects;
        }
        public class UpdateTags
        {
            public string NewVersion;
            public string OldVersion;
            public string DescriptionLink;
            public string DownloadLink;

            public void Save()
            {
                Properties.Settings.Default.currentVersion = NewVersion;
                Properties.Settings.Default.Save();
            }
        }
    }
}
