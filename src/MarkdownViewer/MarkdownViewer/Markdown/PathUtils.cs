using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class PathUtils
    {
        public const string Root = "/";

        public static string Combine(params string[] paths)
        {
            StringBuilder sb = new StringBuilder();
            if (paths != null)
            {
                for(int p = 0; p < paths.Length; p++)
                {
                    if (p > 0)
                    {
                        sb.Append("/");
                    }
                    sb.Append(paths[p]);
                }
            }
            return sb.ToString().Replace("//", "/");
        }

        public static string GetFullPath(string rootPath, string path)
        {
            return Combine(rootPath, path);
        }

        public static string GetPathFromFullPath(string fullPath, string rootPath)
        {
            return ("/" + fullPath.Substring(rootPath.Length)).Replace(@"\", "/");
        }

        public static string GetName(string path)
        {
            string ret = path;
            int pos = path.LastIndexOf("/");
            if (pos >= 0)
            {
                ret = path.Substring(pos + 1);
            }
            pos = path.LastIndexOf(@"\");
            if (pos >= 0)
            {
                ret = path.Substring(pos + 1);
            }
            return ret;
        }
    }
}
