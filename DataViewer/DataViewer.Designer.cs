namespace DataViewer
{
    partial class DataViewer
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
            this.btnViewWrapData = new System.Windows.Forms.Button();
            this.gridUploadedData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblXMLLoc = new System.Windows.Forms.Label();
            this.lblCSVLoc = new System.Windows.Forms.Label();
            this.lblJSONLoc = new System.Windows.Forms.Label();
            this.btnXMLUpload = new System.Windows.Forms.Button();
            this.btnJSONUpload = new System.Windows.Forms.Button();
            this.btnCSVUpload = new System.Windows.Forms.Button();
            this.btnViewXMLData = new System.Windows.Forms.Button();
            this.btnViewJSONData = new System.Windows.Forms.Button();
            this.btnViewCSVData = new System.Windows.Forms.Button();
            this.btnFileUpload = new System.Windows.Forms.Button();
            this.btnExtractDataFiles = new System.Windows.Forms.Button();
            this.btnExtractAll = new System.Windows.Forms.Button();
            this.btnViewAllData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUploadedData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewWrapData
            // 
            this.btnViewWrapData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewWrapData.Location = new System.Drawing.Point(1532, 0);
            this.btnViewWrapData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewWrapData.Name = "btnViewWrapData";
            this.btnViewWrapData.Size = new System.Drawing.Size(188, 35);
            this.btnViewWrapData.TabIndex = 4;
            this.btnViewWrapData.Text = "View Wrap Data";
            this.btnViewWrapData.UseVisualStyleBackColor = true;
            this.btnViewWrapData.Visible = false;
            this.btnViewWrapData.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridUploadedData
            // 
            this.gridUploadedData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUploadedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUploadedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUploadedData.Location = new System.Drawing.Point(100, 129);
            this.gridUploadedData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridUploadedData.Name = "gridUploadedData";
            this.gridUploadedData.ReadOnly = true;
            this.gridUploadedData.Size = new System.Drawing.Size(1618, 598);
            this.gridUploadedData.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "XML";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "JSON";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Upload File";
            // 
            // lblXMLLoc
            // 
            this.lblXMLLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXMLLoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblXMLLoc.Location = new System.Drawing.Point(202, -3);
            this.lblXMLLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXMLLoc.MaximumSize = new System.Drawing.Size(0, 23);
            this.lblXMLLoc.MinimumSize = new System.Drawing.Size(525, 23);
            this.lblXMLLoc.Name = "lblXMLLoc";
            this.lblXMLLoc.Size = new System.Drawing.Size(525, 23);
            this.lblXMLLoc.TabIndex = 9;
            this.lblXMLLoc.Visible = false;
            // 
            // lblCSVLoc
            // 
            this.lblCSVLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCSVLoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblCSVLoc.Location = new System.Drawing.Point(202, -3);
            this.lblCSVLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCSVLoc.MaximumSize = new System.Drawing.Size(0, 23);
            this.lblCSVLoc.MinimumSize = new System.Drawing.Size(525, 23);
            this.lblCSVLoc.Name = "lblCSVLoc";
            this.lblCSVLoc.Size = new System.Drawing.Size(525, 23);
            this.lblCSVLoc.TabIndex = 10;
            this.lblCSVLoc.Visible = false;
            // 
            // lblJSONLoc
            // 
            this.lblJSONLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJSONLoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblJSONLoc.Location = new System.Drawing.Point(244, 52);
            this.lblJSONLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJSONLoc.MaximumSize = new System.Drawing.Size(0, 35);
            this.lblJSONLoc.MinimumSize = new System.Drawing.Size(525, 23);
            this.lblJSONLoc.Name = "lblJSONLoc";
            this.lblJSONLoc.Size = new System.Drawing.Size(525, 35);
            this.lblJSONLoc.TabIndex = 11;
            // 
            // btnXMLUpload
            // 
            this.btnXMLUpload.Location = new System.Drawing.Point(1002, 0);
            this.btnXMLUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXMLUpload.Name = "btnXMLUpload";
            this.btnXMLUpload.Size = new System.Drawing.Size(112, 35);
            this.btnXMLUpload.TabIndex = 12;
            this.btnXMLUpload.Text = "Upload";
            this.btnXMLUpload.UseVisualStyleBackColor = true;
            this.btnXMLUpload.Visible = false;
            this.btnXMLUpload.Click += new System.EventHandler(this.btnXMLUpload_Click);
            // 
            // btnJSONUpload
            // 
            this.btnJSONUpload.Location = new System.Drawing.Point(1002, 0);
            this.btnJSONUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnJSONUpload.Name = "btnJSONUpload";
            this.btnJSONUpload.Size = new System.Drawing.Size(112, 35);
            this.btnJSONUpload.TabIndex = 13;
            this.btnJSONUpload.Text = "Upload";
            this.btnJSONUpload.UseVisualStyleBackColor = true;
            this.btnJSONUpload.Visible = false;
            this.btnJSONUpload.Click += new System.EventHandler(this.btnJSONUpload_Click);
            // 
            // btnCSVUpload
            // 
            this.btnCSVUpload.Location = new System.Drawing.Point(1002, 0);
            this.btnCSVUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCSVUpload.Name = "btnCSVUpload";
            this.btnCSVUpload.Size = new System.Drawing.Size(112, 35);
            this.btnCSVUpload.TabIndex = 14;
            this.btnCSVUpload.Text = "Upload";
            this.btnCSVUpload.UseVisualStyleBackColor = true;
            this.btnCSVUpload.Visible = false;
            this.btnCSVUpload.Click += new System.EventHandler(this.btnCSVUpload_Click);
            // 
            // btnViewXMLData
            // 
            this.btnViewXMLData.Location = new System.Drawing.Point(1152, 0);
            this.btnViewXMLData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewXMLData.Name = "btnViewXMLData";
            this.btnViewXMLData.Size = new System.Drawing.Size(112, 35);
            this.btnViewXMLData.TabIndex = 15;
            this.btnViewXMLData.Text = "View Data";
            this.btnViewXMLData.UseVisualStyleBackColor = true;
            this.btnViewXMLData.Visible = false;
            this.btnViewXMLData.Click += new System.EventHandler(this.btnViewXMLData_Click);
            // 
            // btnViewJSONData
            // 
            this.btnViewJSONData.Location = new System.Drawing.Point(1152, 0);
            this.btnViewJSONData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewJSONData.Name = "btnViewJSONData";
            this.btnViewJSONData.Size = new System.Drawing.Size(112, 35);
            this.btnViewJSONData.TabIndex = 16;
            this.btnViewJSONData.Text = "View Data";
            this.btnViewJSONData.UseVisualStyleBackColor = true;
            this.btnViewJSONData.Visible = false;
            this.btnViewJSONData.Click += new System.EventHandler(this.btnViewJSONData_Click);
            // 
            // btnViewCSVData
            // 
            this.btnViewCSVData.Location = new System.Drawing.Point(1152, 0);
            this.btnViewCSVData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewCSVData.Name = "btnViewCSVData";
            this.btnViewCSVData.Size = new System.Drawing.Size(112, 35);
            this.btnViewCSVData.TabIndex = 17;
            this.btnViewCSVData.Text = "View Data";
            this.btnViewCSVData.UseVisualStyleBackColor = true;
            this.btnViewCSVData.Visible = false;
            this.btnViewCSVData.Click += new System.EventHandler(this.btnViewCSVData_Click);
            // 
            // btnFileUpload
            // 
            this.btnFileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileUpload.Location = new System.Drawing.Point(838, 52);
            this.btnFileUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileUpload.Name = "btnFileUpload";
            this.btnFileUpload.Size = new System.Drawing.Size(192, 35);
            this.btnFileUpload.TabIndex = 18;
            this.btnFileUpload.Text = "Upload File";
            this.btnFileUpload.UseVisualStyleBackColor = true;
            this.btnFileUpload.Click += new System.EventHandler(this.btnFileUpload_Click);
            // 
            // btnExtractDataFiles
            // 
            this.btnExtractDataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractDataFiles.Location = new System.Drawing.Point(1072, 52);
            this.btnExtractDataFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtractDataFiles.Name = "btnExtractDataFiles";
            this.btnExtractDataFiles.Size = new System.Drawing.Size(192, 35);
            this.btnExtractDataFiles.TabIndex = 19;
            this.btnExtractDataFiles.Text = "Export XML";
            this.btnExtractDataFiles.UseVisualStyleBackColor = true;
            this.btnExtractDataFiles.Click += new System.EventHandler(this.btnExtractDataFiles_Click);
            // 
            // btnExtractAll
            // 
            this.btnExtractAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractAll.Location = new System.Drawing.Point(1304, 52);
            this.btnExtractAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtractAll.Name = "btnExtractAll";
            this.btnExtractAll.Size = new System.Drawing.Size(192, 35);
            this.btnExtractAll.TabIndex = 20;
            this.btnExtractAll.Text = "Export Combined XML";
            this.btnExtractAll.UseVisualStyleBackColor = true;
            this.btnExtractAll.Click += new System.EventHandler(this.btnExtractAll_Click);
            // 
            // btnViewAllData
            // 
            this.btnViewAllData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAllData.Location = new System.Drawing.Point(1532, 52);
            this.btnViewAllData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewAllData.Name = "btnViewAllData";
            this.btnViewAllData.Size = new System.Drawing.Size(192, 35);
            this.btnViewAllData.TabIndex = 21;
            this.btnViewAllData.Text = "View Wrapped Data";
            this.btnViewAllData.UseVisualStyleBackColor = true;
            this.btnViewAllData.Click += new System.EventHandler(this.btnViewAllData_Click);
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1792, 768);
            this.Controls.Add(this.btnViewAllData);
            this.Controls.Add(this.btnExtractAll);
            this.Controls.Add(this.btnExtractDataFiles);
            this.Controls.Add(this.btnFileUpload);
            this.Controls.Add(this.btnViewCSVData);
            this.Controls.Add(this.btnViewJSONData);
            this.Controls.Add(this.btnViewXMLData);
            this.Controls.Add(this.btnCSVUpload);
            this.Controls.Add(this.btnJSONUpload);
            this.Controls.Add(this.btnXMLUpload);
            this.Controls.Add(this.lblJSONLoc);
            this.Controls.Add(this.lblCSVLoc);
            this.Controls.Add(this.lblXMLLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridUploadedData);
            this.Controls.Add(this.btnViewWrapData);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DataViewer";
            this.Text = "Data Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUploadedData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnViewWrapData;
        private System.Windows.Forms.DataGridView gridUploadedData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblXMLLoc;
        private System.Windows.Forms.Label lblCSVLoc;
        private System.Windows.Forms.Label lblJSONLoc;
        private System.Windows.Forms.Button btnXMLUpload;
        private System.Windows.Forms.Button btnJSONUpload;
        private System.Windows.Forms.Button btnCSVUpload;
        private System.Windows.Forms.Button btnViewXMLData;
        private System.Windows.Forms.Button btnViewJSONData;
        private System.Windows.Forms.Button btnViewCSVData;
        private System.Windows.Forms.Button btnFileUpload;
        private System.Windows.Forms.Button btnExtractDataFiles;
        private System.Windows.Forms.Button btnExtractAll;
        private System.Windows.Forms.Button btnViewAllData;
    }
}

