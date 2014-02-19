namespace K_Line
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
            this.buttonProcess = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.radioButtonImportFile = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeIn = new System.Windows.Forms.RadioButton();
            this.stockListFileTextBox = new System.Windows.Forms.TextBox();
            this.StockNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonSelectStockListFile = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.downloadDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonSelectDownloadedFiles = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxNumOfRed = new System.Windows.Forms.TextBox();
            this.textBoxWaitingDays = new System.Windows.Forms.TextBox();
            this.textBoxProfit = new System.Windows.Forms.TextBox();
            this.textBoxLowPointPeriod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(429, 722);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(96, 61);
            this.buttonProcess.TabIndex = 0;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.Process_Click);
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(13, 62);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(240, 23);
            this.startDate.TabIndex = 13;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(273, 62);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(240, 23);
            this.endDate.TabIndex = 14;
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(10, 36);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(76, 17);
            this.startLabel.TabIndex = 15;
            this.startLabel.Text = "Start Date:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(270, 36);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(71, 17);
            this.endLabel.TabIndex = 16;
            this.endLabel.Text = "End Date:";
            // 
            // radioButtonImportFile
            // 
            this.radioButtonImportFile.AutoSize = true;
            this.radioButtonImportFile.Location = new System.Drawing.Point(13, 105);
            this.radioButtonImportFile.Name = "radioButtonImportFile";
            this.radioButtonImportFile.Size = new System.Drawing.Size(255, 21);
            this.radioButtonImportFile.TabIndex = 18;
            this.radioButtonImportFile.TabStop = true;
            this.radioButtonImportFile.Text = "Download all stocks listed in the file:";
            this.radioButtonImportFile.UseVisualStyleBackColor = true;
            this.radioButtonImportFile.CheckedChanged += new System.EventHandler(this.radioButtonImportFile_CheckedChanged);
            // 
            // radioButtonTypeIn
            // 
            this.radioButtonTypeIn.AutoSize = true;
            this.radioButtonTypeIn.Location = new System.Drawing.Point(13, 177);
            this.radioButtonTypeIn.Name = "radioButtonTypeIn";
            this.radioButtonTypeIn.Size = new System.Drawing.Size(188, 21);
            this.radioButtonTypeIn.TabIndex = 19;
            this.radioButtonTypeIn.TabStop = true;
            this.radioButtonTypeIn.Text = "Download this stock only:";
            this.radioButtonTypeIn.UseVisualStyleBackColor = true;
            this.radioButtonTypeIn.CheckedChanged += new System.EventHandler(this.radioButtonTypeIn_CheckedChanged);
            // 
            // stockListFileTextBox
            // 
            this.stockListFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockListFileTextBox.Location = new System.Drawing.Point(13, 135);
            this.stockListFileTextBox.Name = "stockListFileTextBox";
            this.stockListFileTextBox.Size = new System.Drawing.Size(383, 23);
            this.stockListFileTextBox.TabIndex = 20;
            // 
            // StockNameTextBox
            // 
            this.StockNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockNameTextBox.Location = new System.Drawing.Point(13, 207);
            this.StockNameTextBox.Name = "StockNameTextBox";
            this.StockNameTextBox.Size = new System.Drawing.Size(383, 23);
            this.StockNameTextBox.TabIndex = 21;
            // 
            // buttonSelectStockListFile
            // 
            this.buttonSelectStockListFile.Location = new System.Drawing.Point(417, 132);
            this.buttonSelectStockListFile.Name = "buttonSelectStockListFile";
            this.buttonSelectStockListFile.Size = new System.Drawing.Size(96, 28);
            this.buttonSelectStockListFile.TabIndex = 22;
            this.buttonSelectStockListFile.Text = "Select";
            this.buttonSelectStockListFile.UseVisualStyleBackColor = true;
            this.buttonSelectStockListFile.Click += new System.EventHandler(this.buttonSelectStockListFile_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(25, 471);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageTextBox.Size = new System.Drawing.Size(383, 312);
            this.MessageTextBox.TabIndex = 23;
            // 
            // downloadDirTextBox
            // 
            this.downloadDirTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadDirTextBox.Location = new System.Drawing.Point(25, 312);
            this.downloadDirTextBox.Name = "downloadDirTextBox";
            this.downloadDirTextBox.Size = new System.Drawing.Size(383, 23);
            this.downloadDirTextBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Stock files folder:";
            // 
            // buttonSelectDownloadedFiles
            // 
            this.buttonSelectDownloadedFiles.Location = new System.Drawing.Point(429, 309);
            this.buttonSelectDownloadedFiles.Name = "buttonSelectDownloadedFiles";
            this.buttonSelectDownloadedFiles.Size = new System.Drawing.Size(96, 28);
            this.buttonSelectDownloadedFiles.TabIndex = 26;
            this.buttonSelectDownloadedFiles.Text = "Select";
            this.buttonSelectDownloadedFiles.UseVisualStyleBackColor = true;
            this.buttonSelectDownloadedFiles.Click += new System.EventHandler(this.buttonSelectDownloadedFiles_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(429, 653);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(96, 61);
            this.buttonDownload.TabIndex = 27;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.StockNameTextBox);
            this.groupBox1.Controls.Add(this.startDate);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.startLabel);
            this.groupBox1.Controls.Add(this.endLabel);
            this.groupBox1.Controls.Add(this.radioButtonImportFile);
            this.groupBox1.Controls.Add(this.buttonSelectStockListFile);
            this.groupBox1.Controls.Add(this.radioButtonTypeIn);
            this.groupBox1.Controls.Add(this.stockListFileTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 254);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download Source Option";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(429, 583);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(96, 61);
            this.buttonClear.TabIndex = 29;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxNumOfRed
            // 
            this.textBoxNumOfRed.Location = new System.Drawing.Point(15, 60);
            this.textBoxNumOfRed.Name = "textBoxNumOfRed";
            this.textBoxNumOfRed.Size = new System.Drawing.Size(113, 22);
            this.textBoxNumOfRed.TabIndex = 30;
            this.textBoxNumOfRed.Text = "3";
            this.textBoxNumOfRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxNumOfRed.TextChanged += new System.EventHandler(this.textBoxNumOfRed_TextChanged);
            // 
            // textBoxWaitingDays
            // 
            this.textBoxWaitingDays.Location = new System.Drawing.Point(273, 60);
            this.textBoxWaitingDays.Name = "textBoxWaitingDays";
            this.textBoxWaitingDays.Size = new System.Drawing.Size(113, 22);
            this.textBoxWaitingDays.TabIndex = 31;
            this.textBoxWaitingDays.Text = "30";
            this.textBoxWaitingDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxWaitingDays.TextChanged += new System.EventHandler(this.textBoxWaitingDays_TextChanged);
            // 
            // textBoxProfit
            // 
            this.textBoxProfit.Location = new System.Drawing.Point(144, 60);
            this.textBoxProfit.Name = "textBoxProfit";
            this.textBoxProfit.Size = new System.Drawing.Size(113, 22);
            this.textBoxProfit.TabIndex = 32;
            this.textBoxProfit.Text = "10";
            this.textBoxProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxProfit.TextChanged += new System.EventHandler(this.textBoxProfit_TextChanged);
            // 
            // textBoxLowPointPeriod
            // 
            this.textBoxLowPointPeriod.Location = new System.Drawing.Point(402, 60);
            this.textBoxLowPointPeriod.Name = "textBoxLowPointPeriod";
            this.textBoxLowPointPeriod.Size = new System.Drawing.Size(113, 22);
            this.textBoxLowPointPeriod.TabIndex = 33;
            this.textBoxLowPointPeriod.Text = "20";
            this.textBoxLowPointPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxLowPointPeriod.TextChanged += new System.EventHandler(this.textBoxLowPointPeriod_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Num of Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(399, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Low Point Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Waiting Days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Profit (%)";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxNumOfRed);
            this.groupBox2.Controls.Add(this.textBoxWaitingDays);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxProfit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxLowPointPeriod);
            this.groupBox2.Location = new System.Drawing.Point(12, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 100);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rules";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(548, 810);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonSelectDownloadedFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadDirTextBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.buttonProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "K Line Analyzer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.RadioButton radioButtonImportFile;
        private System.Windows.Forms.RadioButton radioButtonTypeIn;
        private System.Windows.Forms.TextBox stockListFileTextBox;
        private System.Windows.Forms.TextBox StockNameTextBox;
        private System.Windows.Forms.Button buttonSelectStockListFile;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.TextBox downloadDirTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonSelectDownloadedFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxNumOfRed;
        private System.Windows.Forms.TextBox textBoxWaitingDays;
        private System.Windows.Forms.TextBox textBoxProfit;
        private System.Windows.Forms.TextBox textBoxLowPointPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

