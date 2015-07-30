namespace VocabularyLearning
{
    partial class SettingUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApple = new System.Windows.Forms.Button();
            this.ckbPlayRepeat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConfirmMode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeInterval = new System.Windows.Forms.TextBox();
            this.ckbRandomSort = new System.Windows.Forms.CheckBox();
            this.btnFont2 = new System.Windows.Forms.Button();
            this.btnFont1 = new System.Windows.Forms.Button();
            this.lblFont1 = new System.Windows.Forms.Label();
            this.lblFont2 = new System.Windows.Forms.Label();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBackground = new System.Windows.Forms.CheckBox();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.chkTopmost = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rotation Time Interval";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(292, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApple
            // 
            this.btnApple.Location = new System.Drawing.Point(211, 323);
            this.btnApple.Name = "btnApple";
            this.btnApple.Size = new System.Drawing.Size(75, 25);
            this.btnApple.TabIndex = 2;
            this.btnApple.Text = "Apply";
            this.btnApple.UseVisualStyleBackColor = true;
            this.btnApple.Click += new System.EventHandler(this.btnApple_Click);
            // 
            // ckbPlayRepeat
            // 
            this.ckbPlayRepeat.AutoSize = true;
            this.ckbPlayRepeat.Location = new System.Drawing.Point(14, 20);
            this.ckbPlayRepeat.Name = "ckbPlayRepeat";
            this.ckbPlayRepeat.Size = new System.Drawing.Size(84, 17);
            this.ckbPlayRepeat.TabIndex = 3;
            this.ckbPlayRepeat.Text = "Play Repeat";
            this.ckbPlayRepeat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarOpacity);
            this.groupBox1.Controls.Add(this.lblOpacity);
            this.groupBox1.Controls.Add(this.chkTopmost);
            this.groupBox1.Controls.Add(this.chkImage);
            this.groupBox1.Controls.Add(this.chkBackground);
            this.groupBox1.Controls.Add(this.chkConfirmMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTimeInterval);
            this.groupBox1.Controls.Add(this.ckbRandomSort);
            this.groupBox1.Controls.Add(this.ckbPlayRepeat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Play Setting";
            // 
            // chkConfirmMode
            // 
            this.chkConfirmMode.AutoSize = true;
            this.chkConfirmMode.Location = new System.Drawing.Point(137, 20);
            this.chkConfirmMode.Name = "chkConfirmMode";
            this.chkConfirmMode.Size = new System.Drawing.Size(91, 17);
            this.chkConfirmMode.TabIndex = 7;
            this.chkConfirmMode.Text = "Confirm Mode";
            this.chkConfirmMode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ms";
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.Location = new System.Drawing.Point(137, 66);
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.Size = new System.Drawing.Size(100, 20);
            this.txtTimeInterval.TabIndex = 5;
            // 
            // ckbRandomSort
            // 
            this.ckbRandomSort.AutoSize = true;
            this.ckbRandomSort.Location = new System.Drawing.Point(14, 43);
            this.ckbRandomSort.Name = "ckbRandomSort";
            this.ckbRandomSort.Size = new System.Drawing.Size(91, 17);
            this.ckbRandomSort.TabIndex = 4;
            this.ckbRandomSort.Text = "Random Sort ";
            this.ckbRandomSort.UseVisualStyleBackColor = true;
            // 
            // btnFont2
            // 
            this.btnFont2.Location = new System.Drawing.Point(6, 15);
            this.btnFont2.Name = "btnFont2";
            this.btnFont2.Size = new System.Drawing.Size(50, 25);
            this.btnFont2.TabIndex = 10;
            this.btnFont2.Text = "Font";
            this.btnFont2.UseVisualStyleBackColor = true;
            this.btnFont2.Click += new System.EventHandler(this.btnFont2_Click);
            // 
            // btnFont1
            // 
            this.btnFont1.Location = new System.Drawing.Point(6, 16);
            this.btnFont1.Name = "btnFont1";
            this.btnFont1.Size = new System.Drawing.Size(50, 25);
            this.btnFont1.TabIndex = 9;
            this.btnFont1.Text = "Font";
            this.btnFont1.UseVisualStyleBackColor = true;
            this.btnFont1.Click += new System.EventHandler(this.btnFont1_Click);
            // 
            // lblFont1
            // 
            this.lblFont1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFont1.Location = new System.Drawing.Point(62, 16);
            this.lblFont1.Name = "lblFont1";
            this.lblFont1.Size = new System.Drawing.Size(286, 49);
            this.lblFont1.TabIndex = 11;
            this.lblFont1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFont2
            // 
            this.lblFont2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFont2.Location = new System.Drawing.Point(62, 16);
            this.lblFont2.Name = "lblFont2";
            this.lblFont2.Size = new System.Drawing.Size(286, 49);
            this.lblFont2.TabIndex = 11;
            this.lblFont2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnColor1
            // 
            this.btnColor1.Location = new System.Drawing.Point(6, 40);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(50, 25);
            this.btnColor1.TabIndex = 9;
            this.btnColor1.Text = "Color";
            this.btnColor1.UseVisualStyleBackColor = true;
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.Location = new System.Drawing.Point(6, 40);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(50, 25);
            this.btnColor2.TabIndex = 10;
            this.btnColor2.Text = "Color";
            this.btnColor2.UseVisualStyleBackColor = true;
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFont1);
            this.groupBox2.Controls.Add(this.btnFont1);
            this.groupBox2.Controls.Add(this.btnColor1);
            this.groupBox2.Location = new System.Drawing.Point(13, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 75);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Term 1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFont2);
            this.groupBox3.Controls.Add(this.btnColor2);
            this.groupBox3.Controls.Add(this.btnFont2);
            this.groupBox3.Location = new System.Drawing.Point(13, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 75);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Term 2";
            // 
            // chkBackground
            // 
            this.chkBackground.AutoSize = true;
            this.chkBackground.Location = new System.Drawing.Point(137, 43);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(84, 17);
            this.chkBackground.TabIndex = 8;
            this.chkBackground.Text = "Background";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(95, 90);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(253, 45);
            this.trackBarOpacity.TabIndex = 9;
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(12, 96);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(81, 13);
            this.lblOpacity.TabIndex = 0;
            this.lblOpacity.Text = "Opacity (100%):";
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Location = new System.Drawing.Point(246, 20);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(55, 17);
            this.chkImage.TabIndex = 8;
            this.chkImage.Text = "Image";
            this.chkImage.UseVisualStyleBackColor = true;
            // 
            // chkTopmost
            // 
            this.chkTopmost.AutoSize = true;
            this.chkTopmost.Location = new System.Drawing.Point(246, 43);
            this.chkTopmost.Name = "chkTopmost";
            this.chkTopmost.Size = new System.Drawing.Size(67, 17);
            this.chkTopmost.TabIndex = 8;
            this.chkTopmost.Text = "Topmost";
            this.chkTopmost.UseVisualStyleBackColor = true;
            // 
            // SettingUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 354);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApple);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Update";
            this.Load += new System.EventHandler(this.SettingUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApple;
        private System.Windows.Forms.CheckBox ckbPlayRepeat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbRandomSort;
        private System.Windows.Forms.TextBox txtTimeInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFont2;
        private System.Windows.Forms.Button btnFont1;
        private System.Windows.Forms.Label lblFont2;
        private System.Windows.Forms.Label lblFont1;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkConfirmMode;
        private System.Windows.Forms.CheckBox chkBackground;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.CheckBox chkTopmost;
    }
}