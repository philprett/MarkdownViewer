using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownViewer
{
    class MarkdownUtils
    {
        public static string GetHtml(string markdown, string rootPath)
        {
            string html = markdown;

            html = html.Replace("\r", "");
            html = html.Replace("\n", "<br>\n");

            html = DoHeaders(html);
            html = DoBold(html);
            html = DoBlockQuotes(html);
            html = DoQuotes(html);
            html = DoImages(html, rootPath);
            html = DoLinks(html);

            return html;
        }

        private static string DoHeaders(string markdown)
        {
            string ret = markdown;

            int start;
            if (ret.Length == 0)
            {
                return ret;
            }

            int endHeaderTag = 0;
            if (ret[0] == '#')
            {
                ret = DoHeader(ret, 0);
                endHeaderTag = ret.IndexOf("</span>");
            }

            start = ret.IndexOf("\n#", endHeaderTag);
            while (start > 0)
            {
                ret = DoHeader(ret, start + 1);
                endHeaderTag = ret.IndexOf("</span>", start);
                start = ret.IndexOf("\n#", endHeaderTag);
            }

            return ret;
        }

        private static string DoHeader(string markdown, int start)
        {
            string ret = markdown;
            int len = ret.Length;
            int endOfHashes = start;
            while (ret[endOfHashes] == '#' && endOfHashes < len) endOfHashes++;

            if (endOfHashes < len)
            {
                int level = endOfHashes - start;
                string headerTag = "<span class='Header" + level.ToString() + "'>";
                string headerTagEnd = "</span>";

                int endOfLine = ret.IndexOf("\n", endOfHashes);
                if (endOfLine < 0)
                {
                    ret = ret.Substring(0, start) + headerTag + ret.Substring(endOfHashes, endOfLine - endOfHashes) + headerTagEnd;
                }
                else
                {
                    ret = ret.Substring(0, start) + headerTag + ret.Substring(endOfHashes, endOfLine - endOfHashes) + headerTagEnd + ret.Substring(endOfLine);
                }
            }

            return ret;
        }

        private static string ReplaceSurroundingMarkdownWithTags(string markdown, string start, string end, string htmlStart, string htmlEnd)
        {
            string ret = markdown;
            int s = ret.IndexOf(start);
            while (s >= 0)
            {
                int e = ret.IndexOf(end, s + start.Length);
                if (e < 0)
                {
                    s = -1;
                }
                else
                {
                    string before = ret.Substring(0, s);
                    string middle = ret.Substring(s + start.Length, e - s - start.Length);
                    string after = ret.Substring(e + end.Length);
                    ret = string.Format(
                        "{0}{1}{2}{3}{4}",
                        before,
                        htmlStart,
                        middle,
                        htmlEnd,
                        after);
                    s = ret.IndexOf(start, before.Length + htmlStart.Length + middle.Length + htmlEnd.Length);
                }
            }
            return ret;
        }

        private static string ReplaceSurroundingMarkdownWithTagsPerLine(string markdown, string start, string end, string htmlStart, string htmlEnd)
        {
            string[] lines = markdown.Split(new[] { '\n' });

            for (int l = 0; l < lines.Length; l++)
            {
                lines[l] = ReplaceSurroundingMarkdownWithTags(lines[l], start, end, htmlStart, htmlEnd);
            }

            return string.Join("\n", lines);
        }

        private static string DoBold(string markdown)
        {
            return ReplaceSurroundingMarkdownWithTagsPerLine(markdown, "**", "**", "<b>", "</b>");
        }

        private static string DoItalics(string markdown)
        {
            return ReplaceSurroundingMarkdownWithTagsPerLine(markdown, "*", "*", "<i>", "</i>");
        }

        private static string DoBlockQuotes(string markdown)
        {
            return ReplaceSurroundingMarkdownWithTags(markdown, "```", "```", "<div class='BlockQuote'>", "</div>");
        }

        private static string DoQuotes(string markdown)
        {
            return ReplaceSurroundingMarkdownWithTagsPerLine(markdown, "`", "`", "<span class='Quote'>", "</span>");
        }

        private static string DoImages(string markdown, string rootPath)
        {
            string ret = markdown;
            int startText, endText, startLink, endLink;
            startText = ret.IndexOf("![");
            while (startText >= 0)
            {
                endText = ret.IndexOf("]", startText);
                if (endText < 0)
                {
                    startText = ret.IndexOf("![", startText + 2);
                }
                else
                {
                    startLink = ret.IndexOf("(", endText);
                    if (startLink < 0 || startLink - endText != 1)
                    {
                        startText = ret.IndexOf("![", endText + 1);
                    }
                    else
                    {
                        endLink = ret.IndexOf(")", startLink);
                        if (endLink < 0)
                        {
                            startText = ret.IndexOf("![", startLink + 1);
                        }
                        else
                        {
                            string text = ret.Substring(startText + 2, endText - startText - 2);
                            string link = ret.Substring(startLink + 1, endLink - startLink - 1);
                            string before = ret.Substring(0, startText);
                            string after = ret.Substring(endLink + 1);
                            ret = string.Format(
                                "{0}<img alt='{2}' title='{2}' border='0' src='{4}{1}'>{3}",
                                before,
                                link,
                                text,
                                after,
                                rootPath.Replace(@"\","/"));
                            startText = ret.IndexOf("![", before.Length + link.Length + text.Length + 13);
                        }
                    }
                }
            }
            return ret;
        }


        private static string DoLinks(string markdown)
        {
            string ret = markdown;
            int startText, endText, startLink, endLink;
            startText = ret.IndexOf("[");
            while (startText >= 0)
            {
                endText = ret.IndexOf("]", startText);
                if (endText < 0)
                {
                    startText = ret.IndexOf("[", startText + 1);
                }
                else
                {
                    startLink = ret.IndexOf("(", endText);
                    if (startLink < 0 || startLink - endText != 1)
                    {
                        startText = ret.IndexOf("[", endText + 1);
                    }
                    else
                    {
                        endLink = ret.IndexOf(")", startLink);
                        if (endLink < 0)
                        {
                            startText = ret.IndexOf("[", startLink + 1);
                        }
                        else
                        {
                            string text = ret.Substring(startText + 1, endText - startText - 1);
                            string link = ret.Substring(startLink + 1, endLink - startLink - 1);
                            string before = ret.Substring(0, startText);
                            string after = ret.Substring(endLink + 1);
                            ret = string.Format(
                                "{0}<a href='{1}'>{2}</a>{3}",
                                before,
                                link,
                                text,
                                after);
                            startText = ret.IndexOf("[", before.Length + link.Length + text.Length + 13);
                        }
                    }
                }
            }
            return ret;
        }


    }
}
