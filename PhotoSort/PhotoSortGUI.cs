using System;
using System.IO;
using System.Windows.Forms;

namespace PhotoSort
{
    public partial class PhotoSortGUI : Form
    {
        public PhotoSortGUI()
        {
            //initilise form objects
            InitializeComponent();
            SortingProgress.Value = 0;
            OutputText.Text = "";

            
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //make sure all inputs have been entered
            if ((IndexFilePath.Text == "") || (PhotoLocationBox.Text == "") || (SortedLocationBox.Text == ""))
            {
                OutputText.Text = "ERROR! Not all fields have been filled in";
            }
            else
            {
                var processor = new Processor(File.ReadAllLines(IndexFileInputBox.Text));
                processor.SortProgress += progress =>
                {
                    SortingProgress.Value = progress;
                    SortingProgress.Update();
                };

                processor.CopyProgress += progress =>
                {
                    SortingProgress2.Value = progress;
                    SortingProgress2.Update();
                };

                processor.Sort(new DirectoryInfo(PhotoLocationBox.Text));
                processor.CopyImages(new DirectoryInfo(SortedLocationBox.Text));
            }
        }
        //check if paths are valid
        private void CheckDirectoryPathValid(TextBox TextField, Label Error)
        {
            OutputText.Text = "";
            if ((!Directory.Exists(TextField.Text)) && (TextField.Text != "") || (TextField.Text.Contains(" ")))
            {
                OutputText.ForeColor = System.Drawing.Color.Red;
                Error.Visible = true;
                OutputText.Text = "One or more directory paths are invalid";
                SubmitButton.Enabled = false;
            }
            else if (TextField.Text.Contains(" "))
            {
                OutputText.ForeColor = System.Drawing.Color.Red;
                OutputText.Text = "Path has whitespaces, please rename files or replace whitespace with underscores";
                Error.Visible = true;
                SubmitButton.Enabled = false;
            }
            else
            {
                OutputText.ForeColor = System.Drawing.Color.Black;
                Error.Visible = false;
                OutputText.Text = "";
                SubmitButton.Enabled = true;
            }
        }
        private void IndexFileInputBox_TextChanged(object sender, EventArgs e)
        {
            OutputText.Text = "";
            if (!File.Exists(IndexFileInputBox.Text) && (IndexFileInputBox.Text != ""))
            {
                IndexFilePathError.Visible = true;
                OutputText.ForeColor = System.Drawing.Color.Red;
                OutputText.Text = "One or more directory paths are invalid";
                SubmitButton.Enabled = false;
            }
            else if (IndexFileInputBox.Text.Contains(" "))//function
            {
                OutputText.ForeColor = System.Drawing.Color.Red;
                OutputText.Text = "Path has whitespaces, please rename files or replace whitespace with underscores";
                IndexFilePathError.Visible = true;
                SubmitButton.Enabled = false;
            }
            else
            {
                OutputText.ForeColor = System.Drawing.Color.Black;
                IndexFilePathError.Visible = false;
                OutputText.Text = "";
                SubmitButton.Enabled = true;
            }
        }
        private void PhotoLocationBox_TextChanged(object sender, EventArgs e)
        {
            CheckDirectoryPathValid(PhotoLocationBox, PhotoLocationPathError);
        }
        private void SortedLocationBox_TextChanged(object sender, EventArgs e)
        {
            CheckDirectoryPathValid(SortedLocationBox, SortedLocationPathError);
        }
        private void IndexFileButton_Click(object sender, EventArgs e)
        {
            PopulateFilePath(IndexFileInputBox);
        }
        private void PhotoFileButton_Click(object sender, EventArgs e)
        {
            PopulateDirectoryPath(PhotoLocationBox);
        }

        private void SortedFileButton_Click(object sender, EventArgs e)
        {
            PopulateDirectoryPath(SortedLocationBox);
        }

        private static void PopulateDirectoryPath(TextBox textBox)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox.Text = fbd.SelectedPath;
                }
            }
        }

        private static void PopulateFilePath(TextBox textBox)
        {
            using (var ofd = new OpenFileDialog())
            {
                var result = ofd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    textBox.Text = ofd.FileName;
                }
            }
        }

        private void Close_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
