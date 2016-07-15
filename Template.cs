using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secl
{
    public class TemplateHeader
    {
        /// <summary>
        /// The directory of the content
        /// </summary>
        public string ContentDirectory { get; set; }
        /// <summary>
        /// The path of the main index file.
        /// </summary>
        public string ContentPath { get; set; }
        /// <summary>
        /// The full path of this template.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// The title of this template.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The description of this template.
        /// </summary>
        public string Description { get; set; }
    }

    public class TemplateManager
    {
        /// <summary>
        /// Open a template file (.tmpl)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TemplateHeader OpenTemplate(string filePath)
        {
            TemplateHeader header = null;
            using (var stream = new StreamReader(filePath))
            {
                header.ContentDirectory = Path.GetDirectoryName(stream.ReadLine());
                header.ContentPath = stream.ReadLine();
                header.FileName = stream.ReadLine();
                header.Title = stream.ReadLine();
                header.Description = stream.ReadLine();
                stream.Close();
            }
            return header;
        }
    }
}
