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
            this.textBoxMaxHoldDays = new System.Windows.Forms.TextBox();
            this.textBoxProfit = new System.Windows.Forms.TextBox();
            this.textBoxLowPointPeriod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLeastHoldDays = new System.Windows.Forms.TextBox();
            this.checkBoxLeastHoldDays = new System.Windows.Forms.CheckBox();
            this.textBoxStopLossPoint = new System.Windows.Forms.TextBox();
            this.checkBoxStopLoss = new System.Windows.Forms.CheckBox();
            this.checkBoxWilliam = new System.Windows.Forms.CheckBox();
            this.checkBoxMaxHoldDays = new System.Windows.Forms.CheckBox();
            this.checkBoxProfit = new System.Windows.Forms.CheckBox();
            this.checkBoxLowPointPeriod = new System.Windows.Forms.CheckBox();
            this.textBoxWilliam = new System.Windows.Forms.TextBox();
            this.checkBoxDetailLog = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(429, 703);
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
            this.startDate.Location = new System.Drawing.Point(13, 54);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(240, 23);
            this.startDate.TabIndex = 13;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(273, 54);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(240, 23);
            this.endDate.TabIndex = 14;
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(10, 28);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(76, 17);
            this.startLabel.TabIndex = 15;
            this.startLabel.Text = "Start Date:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(270, 28);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(71, 17);
            this.endLabel.TabIndex = 16;
            this.endLabel.Text = "End Date:";
            // 
            // radioButtonImportFile
            // 
            this.radioButtonImportFile.AutoSize = true;
            this.radioButtonImportFile.Location = new System.Drawing.Point(13, 91);
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
            this.radioButtonTypeIn.Location = new System.Drawing.Point(13, 161);
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
            this.stockListFileTextBox.Location = new System.Drawing.Point(13, 121);
            this.stockListFileTextBox.Name = "stockListFileTextBox";
            this.stockListFileTextBox.Size = new System.Drawing.Size(383, 23);
            this.stockListFileTextBox.TabIndex = 20;
            // 
            // StockNameTextBox
            // 
            this.StockNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockNameTextBox.Location = new System.Drawing.Point(13, 191);
            this.StockNameTextBox.Name = "StockNameTextBox";
            this.StockNameTextBox.Size = new System.Drawing.Size(383, 23);
            this.StockNameTextBox.TabIndex = 21;
            // 
            // buttonSelectStockListFile
            // 
            this.buttonSelectStockListFile.Location = new System.Drawing.Point(417, 118);
            this.buttonSelectStockListFile.Name = "buttonSelectStockListFile";
            this.buttonSelectStockListFile.Size = new System.Drawing.Size(96, 28);
            this.buttonSelectStockListFile.TabIndex = 22;
            this.buttonSelectStockListFile.Text = "Select";
            this.buttonSelectStockListFile.UseVisualStyleBackColor = true;
            this.buttonSelectStockListFile.Click += new System.EventHandler(this.buttonSelectStockListFile_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(25, 533);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageTextBox.Size = new System.Drawing.Size(383, 231);
            this.MessageTextBox.TabIndex = 23;
            // 
            // downloadDirTextBox
            // 
            this.downloadDirTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadDirTextBox.Location = new System.Drawing.Point(25, 281);
            this.downloadDirTextBox.Name = "downloadDirTextBox";
            this.downloadDirTextBox.Size = new System.Drawing.Size(383, 23);
            this.downloadDirTextBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Stock files folder:";
            // 
            // buttonSelectDownloadedFiles
            // 
            this.buttonSelectDownloadedFiles.Location = new System.Drawing.Point(429, 278);
            this.buttonSelectDownloadedFiles.Name = "buttonSelectDownloadedFiles";
            this.buttonSelectDownloadedFiles.Size = new System.Drawing.Size(96, 28);
            this.buttonSelectDownloadedFiles.TabIndex = 26;
            this.buttonSelectDownloadedFiles.Text = "Select";
            this.buttonSelectDownloadedFiles.UseVisualStyleBackColor = true;
            this.buttonSelectDownloadedFiles.Click += new System.EventHandler(this.buttonSelectDownloadedFiles_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(429, 634);
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
            this.groupBox1.Size = new System.Drawing.Size(525, 229);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download Source Option";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(429, 564);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(96, 61);
            this.buttonClear.TabIndex = 29;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxNumOfRed
            // 
            this.textBoxNumOfRed.Enabled = false;
            this.textBoxNumOfRed.Location = new System.Drawing.Point(16, 59);
            this.textBoxNumOfRed.Name = "textBoxNumOfRed";
            this.textBoxNumOfRed.Size = new System.Drawing.Size(80, 22);
            this.textBoxNumOfRed.TabIndex = 30;
            this.textBoxNumOfRed.Text = "3";
            this.textBoxNumOfRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMaxHoldDays
            // 
            this.textBoxMaxHoldDays.Location = new System.Drawing.Point(365, 59);
            this.textBoxMaxHoldDays.Name = "textBoxMaxHoldDays";
            this.textBoxMaxHoldDays.Size = new System.Drawing.Size(142, 22);
            this.textBoxMaxHoldDays.TabIndex = 31;
            this.textBoxMaxHoldDays.Text = "60";
            this.textBoxMaxHoldDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxProfit
            // 
            this.textBoxProfit.Location = new System.Drawing.Point(238, 59);
            this.textBoxProfit.Name = "textBoxProfit";
            this.textBoxProfit.Size = new System.Drawing.Size(113, 22);
            this.textBoxProfit.TabIndex = 32;
            this.textBoxProfit.Text = "30";
            this.textBoxProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxLowPointPeriod
            // 
            this.textBoxLowPointPeriod.Enabled = false;
            this.textBoxLowPointPeriod.Location = new System.Drawing.Point(379, 127);
            this.textBoxLowPointPeriod.Name = "textBoxLowPointPeriod";
            this.textBoxLowPointPeriod.Size = new System.Drawing.Size(128, 22);
            this.textBoxLowPointPeriod.TabIndex = 33;
            this.textBoxLowPointPeriod.Text = "10";
            this.textBoxLowPointPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Num of Red";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.textBoxLeastHoldDays);
            this.groupBox2.Controls.Add(this.checkBoxLeastHoldDays);
            this.groupBox2.Controls.Add(this.textBoxStopLossPoint);
            this.groupBox2.Controls.Add(this.checkBoxStopLoss);
            this.groupBox2.Controls.Add(this.checkBoxWilliam);
            this.groupBox2.Controls.Add(this.checkBoxMaxHoldDays);
            this.groupBox2.Controls.Add(this.checkBoxProfit);
            this.groupBox2.Controls.Add(this.checkBoxLowPointPeriod);
            this.groupBox2.Controls.Add(this.textBoxWilliam);
            this.groupBox2.Controls.Add(this.textBoxNumOfRed);
            this.groupBox2.Controls.Add(this.textBoxMaxHoldDays);
            this.groupBox2.Controls.Add(this.textBoxProfit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxLowPointPeriod);
            this.groupBox2.Location = new System.Drawing.Point(12, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 169);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rules";
            // 
            // textBoxLeastHoldDays
            // 
            this.textBoxLeastHoldDays.Location = new System.Drawing.Point(182, 127);
            this.textBoxLeastHoldDays.Name = "textBoxLeastHoldDays";
            this.textBoxLeastHoldDays.Size = new System.Drawing.Size(128, 22);
            this.textBoxLeastHoldDays.TabIndex = 45;
            this.textBoxLeastHoldDays.Text = "10";
            this.textBoxLeastHoldDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxLeastHoldDays
            // 
            this.checkBoxLeastHoldDays.AutoSize = true;
            this.checkBoxLeastHoldDays.Checked = true;
            this.checkBoxLeastHoldDays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLeastHoldDays.Location = new System.Drawing.Point(182, 99);
            this.checkBoxLeastHoldDays.Name = "checkBoxLeastHoldDays";
            this.checkBoxLeastHoldDays.Size = new System.Drawing.Size(134, 21);
            this.checkBoxLeastHoldDays.TabIndex = 44;
            this.checkBoxLeastHoldDays.Text = "Least Hold Days";
            this.checkBoxLeastHoldDays.UseVisualStyleBackColor = true;
            this.checkBoxLeastHoldDays.CheckedChanged += new System.EventHandler(this.checkBoxLeastHoldDays_CheckedChanged);
            // 
            // textBoxStopLossPoint
            // 
            this.textBoxStopLossPoint.Location = new System.Drawing.Point(16, 127);
            this.textBoxStopLossPoint.Name = "textBoxStopLossPoint";
            this.textBoxStopLossPoint.Size = new System.Drawing.Size(145, 22);
            this.textBoxStopLossPoint.TabIndex = 44;
            this.textBoxStopLossPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxStopLoss
            // 
            this.checkBoxStopLoss.AutoSize = true;
            this.checkBoxStopLoss.Checked = true;
            this.checkBoxStopLoss.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStopLoss.Location = new System.Drawing.Point(16, 99);
            this.checkBoxStopLoss.Name = "checkBoxStopLoss";
            this.checkBoxStopLoss.Size = new System.Drawing.Size(155, 21);
            this.checkBoxStopLoss.TabIndex = 43;
            this.checkBoxStopLoss.Text = "Stop Loss Point (%)";
            this.checkBoxStopLoss.UseVisualStyleBackColor = true;
            this.checkBoxStopLoss.CheckedChanged += new System.EventHandler(this.checkBoxStopLoss_CheckedChanged);
            // 
            // checkBoxWilliam
            // 
            this.checkBoxWilliam.AutoSize = true;
            this.checkBoxWilliam.Checked = true;
            this.checkBoxWilliam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWilliam.Location = new System.Drawing.Point(110, 31);
            this.checkBoxWilliam.Name = "checkBoxWilliam";
            this.checkBoxWilliam.Size = new System.Drawing.Size(100, 21);
            this.checkBoxWilliam.TabIndex = 42;
            this.checkBoxWilliam.Text = "William (%)";
            this.checkBoxWilliam.UseVisualStyleBackColor = true;
            this.checkBoxWilliam.CheckedChanged += new System.EventHandler(this.checkBoxWilliam_CheckedChanged);
            // 
            // checkBoxMaxHoldDays
            // 
            this.checkBoxMaxHoldDays.AutoSize = true;
            this.checkBoxMaxHoldDays.Checked = true;
            this.checkBoxMaxHoldDays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMaxHoldDays.Location = new System.Drawing.Point(365, 30);
            this.checkBoxMaxHoldDays.Name = "checkBoxMaxHoldDays";
            this.checkBoxMaxHoldDays.Size = new System.Drawing.Size(124, 21);
            this.checkBoxMaxHoldDays.TabIndex = 41;
            this.checkBoxMaxHoldDays.Text = "Max Hold Days";
            this.checkBoxMaxHoldDays.UseVisualStyleBackColor = true;
            this.checkBoxMaxHoldDays.CheckedChanged += new System.EventHandler(this.checkBoxMaxHoldDays_CheckedChanged);
            // 
            // checkBoxProfit
            // 
            this.checkBoxProfit.AutoSize = true;
            this.checkBoxProfit.Checked = true;
            this.checkBoxProfit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxProfit.Location = new System.Drawing.Point(238, 31);
            this.checkBoxProfit.Name = "checkBoxProfit";
            this.checkBoxProfit.Size = new System.Drawing.Size(89, 21);
            this.checkBoxProfit.TabIndex = 40;
            this.checkBoxProfit.Text = "Profit (%)";
            this.checkBoxProfit.UseVisualStyleBackColor = true;
            this.checkBoxProfit.CheckedChanged += new System.EventHandler(this.checkBoxProfit_CheckedChanged);
            // 
            // checkBoxLowPointPeriod
            // 
            this.checkBoxLowPointPeriod.AutoSize = true;
            this.checkBoxLowPointPeriod.Enabled = false;
            this.checkBoxLowPointPeriod.Location = new System.Drawing.Point(379, 99);
            this.checkBoxLowPointPeriod.Name = "checkBoxLowPointPeriod";
            this.checkBoxLowPointPeriod.Size = new System.Drawing.Size(127, 21);
            this.checkBoxLowPointPeriod.TabIndex = 30;
            this.checkBoxLowPointPeriod.Text = "Low Point Days";
            this.checkBoxLowPointPeriod.UseVisualStyleBackColor = true;
            // 
            // textBoxWilliam
            // 
            this.textBoxWilliam.Location = new System.Drawing.Point(110, 59);
            this.textBoxWilliam.Name = "textBoxWilliam";
            this.textBoxWilliam.Size = new System.Drawing.Size(113, 22);
            this.textBoxWilliam.TabIndex = 38;
            this.textBoxWilliam.Text = "70";
            this.textBoxWilliam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxDetailLog
            // 
            this.checkBoxDetailLog.AutoSize = true;
            this.checkBoxDetailLog.Location = new System.Drawing.Point(25, 499);
            this.checkBoxDetailLog.Name = "checkBoxDetailLog";
            this.checkBoxDetailLog.Size = new System.Drawing.Size(148, 21);
            this.checkBoxDetailLog.TabIndex = 30;
            this.checkBoxDetailLog.Text = "Show Detailed Log";
            this.checkBoxDetailLog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(548, 785);
            this.Controls.Add(this.checkBoxDetailLog);
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
        private System.Windows.Forms.TextBox textBoxMaxHoldDays;
        private System.Windows.Forms.TextBox textBoxProfit;
        private System.Windows.Forms.TextBox textBoxLowPointPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxWilliam;
        private System.Windows.Forms.CheckBox checkBoxLowPointPeriod;
        private System.Windows.Forms.CheckBox checkBoxWilliam;
        private System.Windows.Forms.CheckBox checkBoxMaxHoldDays;
        private System.Windows.Forms.CheckBox checkBoxProfit;
        private System.Windows.Forms.CheckBox checkBoxDetailLog;
        private System.Windows.Forms.CheckBox checkBoxStopLoss;
        private System.Windows.Forms.TextBox textBoxStopLossPoint;
        private System.Windows.Forms.TextBox textBoxLeastHoldDays;
        private System.Windows.Forms.CheckBox checkBoxLeastHoldDays;
    }
}

