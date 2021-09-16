
namespace GetImagesPDFINATOR
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SelectPDFsButton = new System.Windows.Forms.Button();
            this.historiqueDataGridView = new System.Windows.Forms.DataGridView();
            this.cleanHistoriqueButton = new System.Windows.Forms.Button();
            this.goToMainFolderButton = new System.Windows.Forms.Button();
            this.extractButton = new System.Windows.Forms.Button();
            this.pdfsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mainFolderPathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearDeadPathButton = new System.Windows.Forms.Button();
            this.refreshHistoriqueButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.historiqueDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectPDFsButton
            // 
            this.SelectPDFsButton.Location = new System.Drawing.Point(14, 87);
            this.SelectPDFsButton.Name = "SelectPDFsButton";
            this.SelectPDFsButton.Size = new System.Drawing.Size(74, 71);
            this.SelectPDFsButton.TabIndex = 0;
            this.SelectPDFsButton.Text = "Selectionner les PDFs";
            this.SelectPDFsButton.UseVisualStyleBackColor = true;
            this.SelectPDFsButton.Click += new System.EventHandler(this.SelectPDFsButton_Click);
            // 
            // historiqueDataGridView
            // 
            this.historiqueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historiqueDataGridView.Location = new System.Drawing.Point(12, 299);
            this.historiqueDataGridView.Name = "historiqueDataGridView";
            this.historiqueDataGridView.Size = new System.Drawing.Size(616, 148);
            this.historiqueDataGridView.TabIndex = 1;
            this.historiqueDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.historiqueDataGridView_CellContentDoubleClick);
            // 
            // cleanHistoriqueButton
            // 
            this.cleanHistoriqueButton.Location = new System.Drawing.Point(526, 453);
            this.cleanHistoriqueButton.Name = "cleanHistoriqueButton";
            this.cleanHistoriqueButton.Size = new System.Drawing.Size(102, 22);
            this.cleanHistoriqueButton.TabIndex = 2;
            this.cleanHistoriqueButton.Text = "Clear all historique";
            this.cleanHistoriqueButton.UseVisualStyleBackColor = true;
            this.cleanHistoriqueButton.Click += new System.EventHandler(this.cleanHistoriqueButton_Click);
            // 
            // goToMainFolderButton
            // 
            this.goToMainFolderButton.Location = new System.Drawing.Point(14, 249);
            this.goToMainFolderButton.Name = "goToMainFolderButton";
            this.goToMainFolderButton.Size = new System.Drawing.Size(100, 23);
            this.goToMainFolderButton.TabIndex = 3;
            this.goToMainFolderButton.Text = "GoToMainFolder";
            this.goToMainFolderButton.UseVisualStyleBackColor = true;
            this.goToMainFolderButton.Click += new System.EventHandler(this.goToMainFolderButton_Click);
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(542, 221);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(86, 23);
            this.extractButton.TabIndex = 4;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // pdfsDataGridView
            // 
            this.pdfsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pdfsDataGridView.Location = new System.Drawing.Point(107, 87);
            this.pdfsDataGridView.Name = "pdfsDataGridView";
            this.pdfsDataGridView.Size = new System.Drawing.Size(521, 128);
            this.pdfsDataGridView.TabIndex = 5;
            this.pdfsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pdfsDataGridView_CellContentDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "MainFolderPath : ";
            // 
            // mainFolderPathLabel
            // 
            this.mainFolderPathLabel.AutoSize = true;
            this.mainFolderPathLabel.Location = new System.Drawing.Point(104, 233);
            this.mainFolderPathLabel.Name = "mainFolderPathLabel";
            this.mainFolderPathLabel.Size = new System.Drawing.Size(10, 13);
            this.mainFolderPathLabel.TabIndex = 7;
            this.mainFolderPathLabel.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(131, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "ExtractImagesPDFINATOR";
            // 
            // ClearDeadPathButton
            // 
            this.ClearDeadPathButton.Location = new System.Drawing.Point(417, 453);
            this.ClearDeadPathButton.Name = "ClearDeadPathButton";
            this.ClearDeadPathButton.Size = new System.Drawing.Size(102, 22);
            this.ClearDeadPathButton.TabIndex = 9;
            this.ClearDeadPathButton.Text = "Clear Dead path";
            this.ClearDeadPathButton.UseVisualStyleBackColor = true;
            this.ClearDeadPathButton.Click += new System.EventHandler(this.ClearDeadPathButton_Click);
            // 
            // refreshHistoriqueButton
            // 
            this.refreshHistoriqueButton.Location = new System.Drawing.Point(305, 453);
            this.refreshHistoriqueButton.Name = "refreshHistoriqueButton";
            this.refreshHistoriqueButton.Size = new System.Drawing.Size(106, 22);
            this.refreshHistoriqueButton.TabIndex = 10;
            this.refreshHistoriqueButton.Text = "Refresh Historique";
            this.refreshHistoriqueButton.UseVisualStyleBackColor = true;
            this.refreshHistoriqueButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(479, 221);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(57, 22);
            this.ResetButton.TabIndex = 11;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(290, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Historiques";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(317, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pdf(s) selectionné";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GetImagesPDFINATOR.Properties.Resources.iconmonstr_picture_17_240;
            this.pictureBox1.InitialImage = global::GetImagesPDFINATOR.Properties.Resources.iconmonstr_picture_17_240;
            this.pictureBox1.Location = new System.Drawing.Point(23, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 495);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.refreshHistoriqueButton);
            this.Controls.Add(this.ClearDeadPathButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainFolderPathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pdfsDataGridView);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.goToMainFolderButton);
            this.Controls.Add(this.cleanHistoriqueButton);
            this.Controls.Add(this.historiqueDataGridView);
            this.Controls.Add(this.SelectPDFsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ExtractImagesPDFINATOR";
            ((System.ComponentModel.ISupportInitialize)(this.historiqueDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectPDFsButton;
        private System.Windows.Forms.DataGridView historiqueDataGridView;
        private System.Windows.Forms.Button cleanHistoriqueButton;
        private System.Windows.Forms.Button goToMainFolderButton;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.DataGridView pdfsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mainFolderPathLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClearDeadPathButton;
        private System.Windows.Forms.Button refreshHistoriqueButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

