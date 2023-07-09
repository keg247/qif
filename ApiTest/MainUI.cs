using System;
using System.Windows.Forms;
using System.IO;
using Keg247.Qif;

namespace QifApiTest
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            var fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) ?? ".", "sample.qif");
            using (StreamReader sr = new StreamReader(fileName))
            {
                qifDomPropertyGrid.SelectedObject = QifDocument.Load(sr);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (ConfirmOverwrite())
            {
                InitializeQifDom();
            }
        }

        private void InitializeQifDom()
        {
            qifDomPropertyGrid.SelectedObject = new QifDocument();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                QifDocument qif = (QifDocument)qifDomPropertyGrid.SelectedObject;
                string fileName = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.AutoFlush = true;

                    qif.Save(writer);
                }
                MessageBox.Show(this, "The export is complete.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (ConfirmOverwrite())
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        qifDomPropertyGrid.SelectedObject = QifDocument.Load(sr);
                    }
                }
            }
        }

        private bool ConfirmOverwrite()
        {
            bool result = false;

            if (qifDomPropertyGrid.SelectedObject != null)
            {
                result = MessageBox.Show(this, "Do you want to overwrite the existing QifDocument?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
