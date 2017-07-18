using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoSort;
using MainSort;

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
                ProgressBar ProgressBarOfProgram =  SortingProgress;
                ProgressBar SecondProgressBar = SortingProgress2;
                Main.TriggerFunctions(IndexFileInputBox.Text, PhotoLocationBox.Text, SortedLocationBox.Text, ProgressBarOfProgram, SecondProgressBar);
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
            using (var ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    IndexFileInputBox.Text = ofd.FileName;
                }
            }
        }
        private void PhotoFileButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    PhotoLocationBox.Text = fbd.SelectedPath;
                }
            }
        }
        private void SortedFileButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SortedLocationBox.Text = fbd.SelectedPath;
                }
            }
        }
        private void Close_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ReadFile_Click(object sender, EventArgs e)
        {
            string[] IndexFile = Main.ImportIndexFile(IndexFileInputBox.Text);
        }
        public void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
        //not used
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void photo_sort_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
