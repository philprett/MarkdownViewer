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
    public partial class FormBaseFolder : Form
    {
        private string baseFolder;
        private string startFile;

        public string BaseFolder
        {
            get
            {
                return baseFolder;
            }
            set
            {
                baseFolder = value;
                txtBaseFolder.Text = value;
            }
        }

        public string StartFile
        {
            get
            {
                return startFile;
            }
            set
            {
                startFile = value;
                cmbStartFile.SelectedItem = value;
            }
        }

        public FormBaseFolder()
        {
            InitializeComponent();
        }

        private void FormBaseFolder_Load(object sender, EventArgs e)
        {
            txtBaseFolder.Text = baseFolder;
            cmbStartFile.SelectedItem = startFile;
            UpdateFileList();
        }

        private void butUseFolder_Click(object sender, EventArgs e)
        {
            baseFolder = txtBaseFolder.Text;
            startFile = (string)cmbStartFile.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = txtBaseFolder.Text;
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtBaseFolder.Text = f.SelectedPath;
                UpdateFileList();
            }
        }

        private void UpdateFileList()
        {
            string currentFile = (string)cmbStartFile.SelectedItem ?? startFile;
            bool currentFileFound = false;
            cmbStartFile.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(txtBaseFolder.Text);
            if (di.Exists)
            {
                foreach (FileInfo fi in di.GetFiles("*.md").OrderBy(f => f.Name))
                {
                    cmbStartFile.Items.Add(fi.Name);
                    if (fi.Name == currentFile)
                    {
                        currentFileFound = true;
                    }
                }
                if (currentFileFound)
                {
                    cmbStartFile.SelectedItem = currentFile;
                }
                else if (cmbStartFile.Items.Count > 0)
                {
                    cmbStartFile.SelectedIndex = 0;
                }
            }
        }
    }
}
