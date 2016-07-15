using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace secl
{
    /// <summary>
    /// Ftp client
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxItemFilter("DataSet", ToolboxItemFilterType.Allow)]
    public class FtpClient
        : Component, IComponent
    {
        private FtpCredentials credentials;
        private System.Net.FtpClient.FtpClient client;

        /// <summary>
        /// G
        /// </summary>
        public FtpCredentials Credentials
        {
            get { return credentials; }
            set { credentials = value; }
        }

        /// <summary>
        /// Initalize a new instance <see cref="FtpClient"/> class.
        /// </summary>
        public FtpClient()
        {
            this.client = new System.Net.FtpClient.FtpClient();
        }

        /// <summary>
        /// Initalize a new instance <see cref="FtpClient"/> class.
        /// </summary>
        public FtpClient(FtpCredentials credentails)
        {
            this.client = new System.Net.FtpClient.FtpClient();
            this.Credentials = credentials;
        }


        /// <summary>
        /// Connect to the ftp client.
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                if(client == null)
                {
                    return false;
                }
                NetworkCredential creds = new NetworkCredential()
                {
                    Domain = credentials.Host,
                    UserName = credentials.UserName,
                    Password = credentials.Password,
                    SecurePassword = credentials.SucurePassword,
                };
                client.Credentials = creds;
                client.Host = creds.Domain;
                client.ConnectTimeout = 3000;
                client.Connect();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Download a file
        /// </summary>
        public bool Download( string filePath, string destFolder )
        {
            try
            {
                // List all files with a .txt extension
                foreach ( var ftpListItem in
                    client.GetListing(filePath, System.Net.FtpClient.FtpListOption.Modify | System.Net.FtpClient.FtpListOption.Size)
                        .Where(ftpListItem => string.Equals(Path.GetExtension(ftpListItem.Name), ".txt")) )
                {
                    var destinationPath = string.Format(@"{0}\{1}", destFolder, ftpListItem.Name);

                    using ( var ftpStream = client.OpenRead(ftpListItem.FullName) )
                    using ( var fileStream = File.Create(destinationPath, (int)ftpStream.Length) )
                    {
                        var buffer = new byte[8 * 1024];
                        int count;
                        while ( (count = ftpStream.Read(buffer, 0, buffer.Length)) > 0 )
                        {
                            fileStream.Write(buffer, 0, count);
                        }
                    }
                }
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        /// <summary>
        /// Upload a file.
        /// </summary>
        /// <param name="file">the file to upload</param>
        /// <param name="destPath">the path to add the file to.</param>
        /// <returns></returns>
        public bool UploadFile( string file, string destPath )
        {
            try
            {
                using ( var fileStream = File.OpenRead(file) )
                using ( var ftpStream = client.OpenWrite(string.Format("{0}/{1}", destPath, Path.GetFileName(file))) )
                {
                    var buffer = new byte[8 * 1024];
                    int count;
                    while ( (count = fileStream.Read(buffer, 0, buffer.Length)) > 0 )
                    {
                        ftpStream.Write(buffer, 0, count);
                    }
                }
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the files and directorys on the server.
        /// </summary>
        /// <returns></returns>
        public List<FtpListItem> GetItems()
        {
            List<FtpListItem> items =
                new List<FtpListItem>();

            var v_item = client.GetListing();

            foreach(object i in v_item)
            {
                var i_item = (System.Net.FtpClient.FtpListItem)i;
                FtpListItem item = new FtpListItem()
                {
                    Created = i_item.Created,
                    FullName = i_item.FullName,
                    Name = i_item.Name,
                    Input = i_item.Input,
                    OwnerPermissions = i_item.OwnerPermissions,
                    OthersPermissions = i_item.OthersPermissions,
                    GroupPermissions = i_item.GroupPermissions,
                    SpecialPermissions = i_item.SpecialPermissions,
                    LinkObject = i_item.LinkObject,
                    LinkTarget = i_item.LinkTarget,
                    Modified = i_item.Modified,
                    Size = i_item.Size,
                    Type = i_item.Type
                };
                items.Add(item);
            }
            return items;
        }

        public struct FtpCredentials
        {
            public string UserName { get; set; }
            public string Host { get; set; }
            public string Password { get; set; }
            public SecureString SucurePassword { get; set; }

            /// <summary>
            /// Gets the full address of the host address.
            /// </summary>
            /// <returns></returns>
            public Url GetHost()
            {
                Url url = new Url(Host.Replace("ftp.", "http://www."));
                return url;
            }
        }

        public struct FtpListItem
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public DateTime Created { get; set; }
            public System.Net.FtpClient.FtpPermission GroupPermissions { get; set; }
            public System.Net.FtpClient.FtpPermission OthersPermissions { get; set; }
            public System.Net.FtpClient.FtpPermission OwnerPermissions { get; set; }
            public System.Net.FtpClient.FtpSpecialPermissions SpecialPermissions { get; set; }
            public System.Net.FtpClient.FtpFileSystemObjectType Type { get; set; }
            public string Input { get; set; }
            public object LinkObject { get; set; }
            public string LinkTarget { get; set; }
            public DateTime Modified { get; set; }
            public long Size { get; set; }
        }
    }
}
