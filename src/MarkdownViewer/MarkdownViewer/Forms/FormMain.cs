using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkdownViewer
{
    public partial class FormMain : Form
    {
        private BaseFolder baseFolder = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            baseFolder = new BaseFolder();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                string argPath = args[1];
                if (File.Exists(argPath))
                {
                    FileInfo fi = new FileInfo(argPath);
                    baseFolder.Path = fi.Directory.FullName;
                    baseFolder.StartPage = fi.Name;
                }
                else if (Directory.Exists(argPath))
                {
                    DirectoryInfo di = new DirectoryInfo(argPath);
                    baseFolder.Path = di.FullName;
                    baseFolder.StartPage = string.Empty;
                }
                else
                {
                    baseFolder.Path = string.Empty;
                    baseFolder.StartPage = string.Empty;
                }
            }

            if (string.IsNullOrWhiteSpace(baseFolder.Path) || string.IsNullOrWhiteSpace(baseFolder.StartPage))
            {
                baseFolderToolStripMenuItem_Click(sender, e);
            }
            if (string.IsNullOrWhiteSpace(baseFolder.Path) || string.IsNullOrWhiteSpace(baseFolder.StartPage))
            {
                MessageBox.Show("You must specify a base folder and start file");
                Application.Exit();
            }

            UpdatePages();
        }

        private void baseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaseFolder f = new FormBaseFolder();
            f.BaseFolder = baseFolder.Path;
            f.StartFile = baseFolder.StartPage;
            if (f.ShowDialog() == DialogResult.OK)
            {
                baseFolder.Path = f.BaseFolder;
                baseFolder.StartPage = f.StartFile;
            }
        }

        private string GetTreeName(string path)
        {
            StringBuilder sb = new StringBuilder();

            string[] bits = path.Split(new[] { '/' });
            for (int b = 1; b < bits.Length - 1; b++)
            {
                sb.Append("    ");
            }
            sb.Append(bits[bits.Length - 1]);

            return sb.ToString();
        }

        // Make sure lstObjects.DrawMode is set to OwnerDrawFixed
        private void lstPages_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            ListBox lb = (ListBox)sender;
            Page page = (Page)lb.Items[e.Index];
            //string text = PathUtils.GetName(page.Path);
            string text = GetTreeName(page.Path);

            e.DrawBackground();

            Graphics g = e.Graphics;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                g.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
            else
            {
                g.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            }
            g.DrawString(text, e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void UpdatePages()
        {
            lstPages.Items.Clear();

            foreach (Page page in baseFolder.Folder.GetAllPages().OrderBy(p => p.Path))
            {
                lstPages.Items.Add(page);
            }
        }

        private void lstPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPages.SelectedItem == null) return;

            Page page = (Page)lstPages.SelectedItem;
            LoadPage(page);
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            lstPages_SelectedIndexChanged(sender, e);
        }

        bool pageLoading = false;
        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (pageLoading)
            {
                pageLoading = false;
                return;
            }

            Page page = new Page(baseFolder.Path, e.Url.AbsolutePath.Substring(2) + ".md");
            LoadPage(page);
        }

        private void LoadPage(Page page)
        {
            txtFilePath.Text = page.Path;

            HtmlPage htmlPage = new HtmlPage();
            if (!page.Exists)
            {
                htmlPage.Body = MarkdownUtils.GetHtml("Page not found", baseFolder.Path);
            }
            else
            {
                htmlPage.Body = MarkdownUtils.GetHtml(page.Contents, baseFolder.Path);
            }
            pageLoading = true;
            webBrowser.Url = new Uri(htmlPage.SaveTempFile());
        }
    }
}
