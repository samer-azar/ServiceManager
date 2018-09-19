namespace ServiceManager.Forms
{
    partial class Service_UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service_UserControl));
            this.lblServiceName = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbColorStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServiceName
            // 
            this.lblServiceName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblServiceName.Location = new System.Drawing.Point(51, 8);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(269, 60);
            this.lblServiceName.TabIndex = 12;
            this.lblServiceName.Text = "Service Display Name";
            this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStop.Location = new System.Drawing.Point(392, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 60);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = " ■";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStart.Location = new System.Drawing.Point(326, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 60);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = " ▶";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 2);
            this.label2.TabIndex = 14;
            // 
            // pbColorStatus
            // 
            this.pbColorStatus.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbColorStatus.ErrorImage")));
            this.pbColorStatus.ImageLocation = "center";
            this.pbColorStatus.InitialImage = null;
            this.pbColorStatus.Location = new System.Drawing.Point(12, 22);
            this.pbColorStatus.Name = "pbColorStatus";
            this.pbColorStatus.Size = new System.Drawing.Size(34, 33);
            this.pbColorStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbColorStatus.TabIndex = 15;
            this.pbColorStatus.TabStop = false;
            // 
            // Service_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.pbColorStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServiceName);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Service_UserControl";
            this.Size = new System.Drawing.Size(465, 102);
            ((System.ComponentModel.ISupportInitialize)(this.pbColorStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbColorStatus;
    }
}
