using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class Folder
    {
        public string RootPath { get; set; }
        public string Path { get; set; }

        public Folder(string rootPath, string parentPath, string folderName)
        {
            RootPath = rootPath;
            Path = PathUtils.Combine(parentPath, folderName);
        }
        public Folder(string rootPath, string path)
        {
            RootPath = rootPath;
            Path = path;
        }
        public Folder(string fullPath)
        {
            RootPath = fullPath;
            Path = "/";
        }

        public override string ToString()
        {
            return Path;
        }

        public string FullPath
        {
            get
            {
                return PathUtils.Combine(RootPath, Path);
            }
        }

        public Folder[] Folders
        {
            get
            {
                List<Folder> folders = new List<Folder>();

                DirectoryInfo dir = new DirectoryInfo(FullPath);
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    folders.Add(new Folder(RootPath, Path, sub.Name));
                }

                return folders.ToArray();
            }
        }

        public Page[] Pages
        {
            get
            {
                List<Page> pages = new List<Page>();

                DirectoryInfo dir = new DirectoryInfo(FullPath);
                foreach (FileInfo file in dir.GetFiles("*.md"))
                {
                    pages.Add(new Page(RootPath, Path, file.Name));
                }

                return pages.ToArray();
            }
        }

        public Page[] GetAllPages()
        {
            List<Page> pages = Pages.ToList();

            foreach (Folder folder in Folders.OrderBy(f => f.Path))
            {
                pages.AddRange(folder.GetAllPages());
            }

            return pages.ToArray();
        }
    }
}