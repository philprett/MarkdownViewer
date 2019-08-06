using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class Page
    {
        public string RootPath { get; set; }
        public string Path { get; set; }

        public Page(string rootPath, string parentPath, string pageName)
        {
            RootPath = rootPath;
            Path = PathUtils.Combine(parentPath, pageName);
        }
        public Page(string rootPath, string path)
        {
            RootPath = rootPath;
            Path = path;
        }
        public Page(string fullPath)
        {
            RootPath = fullPath;
            Path = "/";
        }

        public override string ToString()
        {
            return Path;
        }

        public string Contents
        {
            get
            {
                return File.ReadAllText(PathUtils.Combine(RootPath, Path), Encoding.UTF8);
            }
        }

        public bool Contains(string searchFor)
        {
            return Contents.IndexOf(searchFor, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        public bool Exists
        {
            get
            {
                string fullPath = PathUtils.GetFullPath(RootPath, Path);
                return File.Exists(fullPath);
            }
        }

    }
}
