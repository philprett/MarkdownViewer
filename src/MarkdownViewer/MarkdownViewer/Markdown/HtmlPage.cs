using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class HtmlPage
    {
        public string Head { get; set; }
        public string Body { get; set; }

        public HtmlPage()
        {
            StringBuilder head = new StringBuilder();
            head.AppendLine("<style>");
            head.AppendLine("body, table { font-family : Arial; font-size : 10pt; }");
            head.AppendLine("img { max-width : 100%; }");
            head.AppendLine(".Header1 { font-size : 24pt; }");
            head.AppendLine(".Quote { font-family : Consolas, 'Courier New'; font-size : 10pt; background-color : #EEEEEE;}");
            head.AppendLine(".BlockQuote { font-family : Consolas, 'Courier New'; font-size : 10pt; background-color : #EEEEEE;}");
            head.AppendLine("</style>");
            Head = head.ToString();
            Body = string.Empty;
        }

        public string CompleteFile
        {
            get
            {
                return string.Format("<html>\n<head>\n{0}\n</head>\n<body>\n{1}\n</body>\n</html>", Head, Body);
            }
        }

        public string SaveTempFile()
        {
            string tempFile = Path.GetTempFileName();
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
            tempFile += ".html";
            File.WriteAllText(tempFile, CompleteFile, Encoding.UTF8);

            return tempFile;
        }
    }
}
