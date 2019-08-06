using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class BaseFolder
    {
        public string Path { get; set; }
        public string StartPage { get; set; }

        public BaseFolder()
        {
            Path = string.Empty;
            StartPage = string.Empty;
        }

        public Folder Folder
        {
            get
            {
                Folder folder = new Folder(Path, PathUtils.Root);
                return folder;
            }
        }
    }
}
