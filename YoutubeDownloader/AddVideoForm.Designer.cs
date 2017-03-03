namespace YoutubeDownloader
{
    partial class AddVideoForm
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
            this.videoUrlLabel = new System.Windows.Forms.Label();
            this.videoUrlTextBox = new System.Windows.Forms.TextBox();
            this.videoNameTextBox = new System.Windows.Forms.TextBox();
            this.videoNameLabel = new System.Windows.Forms.Label();
            this.videoResolutionLabel = new System.Windows.Forms.Label();
            this.videoListComboBox = new System.Windows.Forms.ComboBox();
            this.addVideoButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // videoUrlLabel
            // 
            this.videoUrlLabel.AutoSize = true;
            this.videoUrlLabel.Location = new System.Drawing.Point(12, 54);
            this.videoUrlLabel.Name = "videoUrlLabel";
            this.videoUrlLabel.Size = new System.Drawing.Size(32, 13);
            this.videoUrlLabel.TabIndex = 0;
            this.videoUrlLabel.Text = "URL:";
            // 
            // videoUrlTextBox
            // 
            this.videoUrlTextBox.Location = new System.Drawing.Point(81, 51);
            this.videoUrlTextBox.Name = "videoUrlTextBox";
            this.videoUrlTextBox.ReadOnly = true;
            this.videoUrlTextBox.Size = new System.Drawing.Size(238, 20);
            this.videoUrlTextBox.TabIndex = 1;
            // 
            // videoNameTextBox
            // 
            this.videoNameTextBox.Location = new System.Drawing.Point(81, 84);
            this.videoNameTextBox.Name = "videoNameTextBox";
            this.videoNameTextBox.ReadOnly = true;
            this.videoNameTextBox.Size = new System.Drawing.Size(238, 20);
            this.videoNameTextBox.TabIndex = 3;
            // 
            // videoNameLabel
            // 
            this.videoNameLabel.AutoSize = true;
            this.videoNameLabel.Location = new System.Drawing.Point(12, 87);
            this.videoNameLabel.Name = "videoNameLabel";
            this.videoNameLabel.Size = new System.Drawing.Size(41, 13);
            this.videoNameLabel.TabIndex = 2;
            this.videoNameLabel.Text = "Name: ";
            // 
            // videoResolutionLabel
            // 
            this.videoResolutionLabel.AutoSize = true;
            this.videoResolutionLabel.Location = new System.Drawing.Point(12, 121);
            this.videoResolutionLabel.Name = "videoResolutionLabel";
            this.videoResolutionLabel.Size = new System.Drawing.Size(63, 13);
            this.videoResolutionLabel.TabIndex = 4;
            this.videoResolutionLabel.Text = "Resolution: ";
            // 
            // videoListComboBox
            // 
            this.videoListComboBox.FormattingEnabled = true;
            this.videoListComboBox.Location = new System.Drawing.Point(81, 117);
            this.videoListComboBox.Name = "videoListComboBox";
            this.videoListComboBox.Size = new System.Drawing.Size(238, 21);
            this.videoListComboBox.TabIndex = 5;
            // 
            // addVideoButton
            // 
            this.addVideoButton.Location = new System.Drawing.Point(174, 178);
            this.addVideoButton.Name = "addVideoButton";
            this.addVideoButton.Size = new System.Drawing.Size(75, 23);
            this.addVideoButton.TabIndex = 6;
            this.addVideoButton.Text = "Add Video";
            this.addVideoButton.UseVisualStyleBackColor = true;
            this.addVideoButton.Click += new System.EventHandler(this.addVideoButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(93, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 231);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addVideoButton);
            this.Controls.Add(this.videoListComboBox);
            this.Controls.Add(this.videoResolutionLabel);
            this.Controls.Add(this.videoNameTextBox);
            this.Controls.Add(this.videoNameLabel);
            this.Controls.Add(this.videoUrlTextBox);
            this.Controls.Add(this.videoUrlLabel);
            this.Name = "AddVideoForm";
            this.Text = "Add New Video";
            this.Load += new System.EventHandler(this.AddVideoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label videoUrlLabel;
        private System.Windows.Forms.TextBox videoUrlTextBox;
        private System.Windows.Forms.TextBox videoNameTextBox;
        private System.Windows.Forms.Label videoNameLabel;
        private System.Windows.Forms.Label videoResolutionLabel;
        private System.Windows.Forms.ComboBox videoListComboBox;
        private System.Windows.Forms.Button addVideoButton;
        private System.Windows.Forms.Button cancelButton;
    }
}