namespace ServiceManager.Forms
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.tbConfiguration = new System.Windows.Forms.TabControl();
            this.tbServices = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPickedServicesCount = new System.Windows.Forms.Label();
            this.lblAllServicesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbPickedServices = new System.Windows.Forms.ListBox();
            this.lbAllServices = new System.Windows.Forms.ListBox();
            this.tbSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nuTimerIntervalInSeconds = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogFileDirectoryPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbConfiguration.SuspendLayout();
            this.tbServices.SuspendLayout();
            this.tbSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimerIntervalInSeconds)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConfiguration
            // 
            this.tbConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConfiguration.Controls.Add(this.tbServices);
            this.tbConfiguration.Controls.Add(this.tbSettings);
            this.tbConfiguration.Location = new System.Drawing.Point(12, 12);
            this.tbConfiguration.Name = "tbConfiguration";
            this.tbConfiguration.SelectedIndex = 0;
            this.tbConfiguration.Size = new System.Drawing.Size(920, 680);
            this.tbConfiguration.TabIndex = 0;
            this.tbConfiguration.SelectedIndexChanged += new System.EventHandler(this.tbConfiguration_SelectedIndexChanged);
            // 
            // tbServices
            // 
            this.tbServices.Controls.Add(this.label3);
            this.tbServices.Controls.Add(this.lblPickedServicesCount);
            this.tbServices.Controls.Add(this.lblAllServicesCount);
            this.tbServices.Controls.Add(this.label2);
            this.tbServices.Controls.Add(this.label1);
            this.tbServices.Controls.Add(this.btnRemoveAll);
            this.tbServices.Controls.Add(this.btnRemove);
            this.tbServices.Controls.Add(this.btnAdd);
            this.tbServices.Controls.Add(this.lbPickedServices);
            this.tbServices.Controls.Add(this.lbAllServices);
            this.tbServices.Location = new System.Drawing.Point(4, 29);
            this.tbServices.Name = "tbServices";
            this.tbServices.Padding = new System.Windows.Forms.Padding(3);
            this.tbServices.Size = new System.Drawing.Size(912, 647);
            this.tbServices.TabIndex = 0;
            this.tbServices.Text = "Services";
            this.tbServices.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Select service(s) from the list";
            // 
            // lblPickedServicesCount
            // 
            this.lblPickedServicesCount.Location = new System.Drawing.Point(724, 49);
            this.lblPickedServicesCount.Name = "lblPickedServicesCount";
            this.lblPickedServicesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPickedServicesCount.Size = new System.Drawing.Size(179, 20);
            this.lblPickedServicesCount.TabIndex = 24;
            // 
            // lblAllServicesCount
            // 
            this.lblAllServicesCount.Location = new System.Drawing.Point(196, 49);
            this.lblAllServicesCount.Name = "lblAllServicesCount";
            this.lblAllServicesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllServicesCount.Size = new System.Drawing.Size(213, 20);
            this.lblAllServicesCount.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Chosen services";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "All the services";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemoveAll.Location = new System.Drawing.Point(415, 290);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(83, 35);
            this.btnRemoveAll.TabIndex = 17;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemove.Location = new System.Drawing.Point(415, 234);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 35);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd.Location = new System.Drawing.Point(415, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 35);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbPickedServices
            // 
            this.lbPickedServices.FormattingEnabled = true;
            this.lbPickedServices.ItemHeight = 20;
            this.lbPickedServices.Location = new System.Drawing.Point(504, 72);
            this.lbPickedServices.Name = "lbPickedServices";
            this.lbPickedServices.Size = new System.Drawing.Size(402, 564);
            this.lbPickedServices.TabIndex = 14;
            // 
            // lbAllServices
            // 
            this.lbAllServices.FormattingEnabled = true;
            this.lbAllServices.ItemHeight = 20;
            this.lbAllServices.Location = new System.Drawing.Point(6, 72);
            this.lbAllServices.Name = "lbAllServices";
            this.lbAllServices.Size = new System.Drawing.Size(403, 564);
            this.lbAllServices.TabIndex = 13;
            // 
            // tbSettings
            // 
            this.tbSettings.Controls.Add(this.groupBox2);
            this.tbSettings.Controls.Add(this.groupBox1);
            this.tbSettings.Location = new System.Drawing.Point(4, 29);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbSettings.Size = new System.Drawing.Size(912, 647);
            this.tbSettings.TabIndex = 1;
            this.tbSettings.Text = "Settings";
            this.tbSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nuTimerIntervalInSeconds);
            this.groupBox2.Location = new System.Drawing.Point(481, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 229);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Set the timer interval (seconds)";
            // 
            // nuTimerIntervalInSeconds
            // 
            this.nuTimerIntervalInSeconds.Location = new System.Drawing.Point(287, 44);
            this.nuTimerIntervalInSeconds.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuTimerIntervalInSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuTimerIntervalInSeconds.Name = "nuTimerIntervalInSeconds";
            this.nuTimerIntervalInSeconds.Size = new System.Drawing.Size(85, 26);
            this.nuTimerIntervalInSeconds.TabIndex = 0;
            this.nuTimerIntervalInSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuTimerIntervalInSeconds.ValueChanged += new System.EventHandler(this.nuTimerIntervalInSeconds_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLogFileDirectoryPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Path";
            // 
            // txtLogFileDirectoryPath
            // 
            this.txtLogFileDirectoryPath.AutoSize = true;
            this.txtLogFileDirectoryPath.Location = new System.Drawing.Point(6, 145);
            this.txtLogFileDirectoryPath.Name = "txtLogFileDirectoryPath";
            this.txtLogFileDirectoryPath.Size = new System.Drawing.Size(21, 20);
            this.txtLogFileDirectoryPath.TabIndex = 3;
            this.txtLogFileDirectoryPath.Text = "\\\\\\";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(315, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(133, 38);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select the directory path of the log files";
            // 
            // btnOkay
            // 
            this.btnOkay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnOkay.Location = new System.Drawing.Point(557, 718);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(121, 35);
            this.btnOkay.TabIndex = 25;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnCancel.Location = new System.Drawing.Point(684, 718);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 35);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnApply.Location = new System.Drawing.Point(811, 718);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(121, 35);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the directory path of the log files";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 765);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServiceList";
            this.tbConfiguration.ResumeLayout(false);
            this.tbServices.ResumeLayout(false);
            this.tbServices.PerformLayout();
            this.tbSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimerIntervalInSeconds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbConfiguration;
        private System.Windows.Forms.TabPage tbServices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPickedServicesCount;
        private System.Windows.Forms.Label lblAllServicesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbPickedServices;
        private System.Windows.Forms.ListBox lbAllServices;
        private System.Windows.Forms.TabPage tbSettings;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nuTimerIntervalInSeconds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtLogFileDirectoryPath;
    }
}