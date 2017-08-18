namespace PhotoSort
{
    partial class PhotoSortGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IndexFilePath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IndexFileInputBox = new System.Windows.Forms.TextBox();
            this.PhotoLocationBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SortedLocationBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SortingProgress = new System.Windows.Forms.ProgressBar();
            this.OutputText = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.IndexFileButton = new System.Windows.Forms.Button();
            this.PhotoFileButton = new System.Windows.Forms.Button();
            this.SortedFileButton = new System.Windows.Forms.Button();
            this.SortingProgress2 = new System.Windows.Forms.ProgressBar();
            this.IndexFilePathError = new System.Windows.Forms.Label();
            this.PhotoLocationPathError = new System.Windows.Forms.Label();
            this.SortedLocationPathError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IndexFilePath
            // 
            this.IndexFilePath.AutoSize = true;
            this.IndexFilePath.Location = new System.Drawing.Point(13, 13);
            this.IndexFilePath.Name = "IndexFilePath";
            this.IndexFilePath.Size = new System.Drawing.Size(77, 13);
            this.IndexFilePath.TabIndex = 0;
            this.IndexFilePath.Text = "Index File Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Photo Location Path";
            // 
            // IndexFileInputBox
            // 
            this.IndexFileInputBox.Location = new System.Drawing.Point(19, 30);
            this.IndexFileInputBox.Name = "IndexFileInputBox";
            this.IndexFileInputBox.Size = new System.Drawing.Size(565, 20);
            this.IndexFileInputBox.TabIndex = 2;
            this.IndexFileInputBox.TextChanged += new System.EventHandler(this.IndexFileInputBox_TextChanged);
            // 
            // PhotoLocationBox
            // 
            this.PhotoLocationBox.Location = new System.Drawing.Point(19, 82);
            this.PhotoLocationBox.Name = "PhotoLocationBox";
            this.PhotoLocationBox.Size = new System.Drawing.Size(565, 20);
            this.PhotoLocationBox.TabIndex = 3;
            this.PhotoLocationBox.TextChanged += new System.EventHandler(this.PhotoLocationBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorted Location Path";
            // 
            // SortedLocationBox
            // 
            this.SortedLocationBox.Location = new System.Drawing.Point(16, 134);
            this.SortedLocationBox.Name = "SortedLocationBox";
            this.SortedLocationBox.Size = new System.Drawing.Size(568, 20);
            this.SortedLocationBox.TabIndex = 5;
            this.SortedLocationBox.TextChanged += new System.EventHandler(this.SortedLocationBox_TextChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(16, 161);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 6;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // SortingProgress
            // 
            this.SortingProgress.Location = new System.Drawing.Point(98, 161);
            this.SortingProgress.Name = "SortingProgress";
            this.SortingProgress.Size = new System.Drawing.Size(522, 10);
            this.SortingProgress.Step = 1;
            this.SortingProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.SortingProgress.TabIndex = 16;

            // 
            // OutputText
            // 
            this.OutputText.AutoSize = true;
            this.OutputText.Location = new System.Drawing.Point(16, 191);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(10, 13);
            this.OutputText.TabIndex = 8;
            this.OutputText.Text = ":";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(545, 191);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 12;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_click);
            // 
            // IndexFileButton
            // 
            this.IndexFileButton.Location = new System.Drawing.Point(590, 30);
            this.IndexFileButton.Name = "IndexFileButton";
            this.IndexFileButton.Size = new System.Drawing.Size(30, 20);
            this.IndexFileButton.TabIndex = 13;
            this.IndexFileButton.Text = "...";
            this.IndexFileButton.UseVisualStyleBackColor = true;
            this.IndexFileButton.Click += new System.EventHandler(this.IndexFileButton_Click);
            // 
            // PhotoFileButton
            // 
            this.PhotoFileButton.Location = new System.Drawing.Point(589, 82);
            this.PhotoFileButton.Name = "PhotoFileButton";
            this.PhotoFileButton.Size = new System.Drawing.Size(30, 20);
            this.PhotoFileButton.TabIndex = 14;
            this.PhotoFileButton.Text = "...";
            this.PhotoFileButton.UseVisualStyleBackColor = true;
            this.PhotoFileButton.Click += new System.EventHandler(this.PhotoFileButton_Click);
            // 
            // SortedFileButton
            // 
            this.SortedFileButton.Location = new System.Drawing.Point(589, 134);
            this.SortedFileButton.Name = "SortedFileButton";
            this.SortedFileButton.Size = new System.Drawing.Size(30, 20);
            this.SortedFileButton.TabIndex = 15;
            this.SortedFileButton.Text = "...";
            this.SortedFileButton.UseVisualStyleBackColor = true;
            this.SortedFileButton.Click += new System.EventHandler(this.SortedFileButton_Click);
            // 
            // SortingProgress2
            // 
            this.SortingProgress2.Location = new System.Drawing.Point(98, 173);
            this.SortingProgress2.Name = "SortingProgress2";
            this.SortingProgress2.Size = new System.Drawing.Size(522, 10);
            this.SortingProgress2.Step = 1;
            this.SortingProgress2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.SortingProgress2.TabIndex = 16;

            // 
            // IndexFilePathError
            // 
            this.IndexFilePathError.AutoSize = true;
            this.IndexFilePathError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexFilePathError.ForeColor = System.Drawing.Color.Red;
            this.IndexFilePathError.Location = new System.Drawing.Point(6, 34);
            this.IndexFilePathError.Name = "IndexFilePathError";
            this.IndexFilePathError.Size = new System.Drawing.Size(11, 13);
            this.IndexFilePathError.TabIndex = 17;
            this.IndexFilePathError.Text = "!";
            this.IndexFilePathError.Visible = false;

            // 
            // PhotoLocationPathError
            // 
            this.PhotoLocationPathError.AutoSize = true;
            this.PhotoLocationPathError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhotoLocationPathError.ForeColor = System.Drawing.Color.Red;
            this.PhotoLocationPathError.Location = new System.Drawing.Point(6, 86);
            this.PhotoLocationPathError.Name = "PhotoLocationPathError";
            this.PhotoLocationPathError.Size = new System.Drawing.Size(11, 13);
            this.PhotoLocationPathError.TabIndex = 18;
            this.PhotoLocationPathError.Text = "!";
            this.PhotoLocationPathError.Visible = false;
            // 
            // SortedLocationPathError
            // 
            this.SortedLocationPathError.AutoSize = true;
            this.SortedLocationPathError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortedLocationPathError.ForeColor = System.Drawing.Color.Red;
            this.SortedLocationPathError.Location = new System.Drawing.Point(3, 138);
            this.SortedLocationPathError.Name = "SortedLocationPathError";
            this.SortedLocationPathError.Size = new System.Drawing.Size(11, 13);
            this.SortedLocationPathError.TabIndex = 19;
            this.SortedLocationPathError.Text = "!";
            this.SortedLocationPathError.Visible = false;
            // 
            // PhotoSortGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 223);
            this.Controls.Add(this.SortedLocationPathError);
            this.Controls.Add(this.PhotoLocationPathError);
            this.Controls.Add(this.IndexFilePathError);
            this.Controls.Add(this.SortingProgress2);
            this.Controls.Add(this.SortedFileButton);
            this.Controls.Add(this.PhotoFileButton);
            this.Controls.Add(this.IndexFileButton);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.SortingProgress);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.SortedLocationBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PhotoLocationBox);
            this.Controls.Add(this.IndexFileInputBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IndexFilePath);
            this.Name = "PhotoSortGUI";
            this.Text = "Photo sort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IndexFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label OutputText;
        public System.Windows.Forms.TextBox IndexFileInputBox;
        public System.Windows.Forms.TextBox PhotoLocationBox;
        public System.Windows.Forms.TextBox SortedLocationBox;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button IndexFileButton;
        private System.Windows.Forms.Button PhotoFileButton;
        private System.Windows.Forms.Button SortedFileButton;
        public System.Windows.Forms.ProgressBar SortingProgress;
        public System.Windows.Forms.ProgressBar SortingProgress2;
        private System.Windows.Forms.Label IndexFilePathError;
        private System.Windows.Forms.Label PhotoLocationPathError;
        private System.Windows.Forms.Label SortedLocationPathError;
    }
}

