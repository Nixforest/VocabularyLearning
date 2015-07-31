namespace VocabularyLearning
{
    partial class VocabularyFrm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblContent1 = new System.Windows.Forms.Label();
            this.lblContent2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(180, 9);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(106, 106);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseClick);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseDown);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseMove);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseUp);
            // 
            // lblContent1
            // 
            this.lblContent1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContent1.Location = new System.Drawing.Point(6, 10);
            this.lblContent1.Name = "lblContent1";
            this.lblContent1.Size = new System.Drawing.Size(167, 63);
            this.lblContent1.TabIndex = 2;
            this.lblContent1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContent1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseClick);
            this.lblContent1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseDown);
            this.lblContent1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseMove);
            this.lblContent1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseUp);
            // 
            // lblContent2
            // 
            this.lblContent2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent2.Location = new System.Drawing.Point(6, 73);
            this.lblContent2.Name = "lblContent2";
            this.lblContent2.Size = new System.Drawing.Size(167, 70);
            this.lblContent2.TabIndex = 2;
            this.lblContent2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContent2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseClick);
            this.lblContent2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseDown);
            this.lblContent2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseMove);
            this.lblContent2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseUp);
            // 
            // VocabularyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 153);
            this.Controls.Add(this.lblContent2);
            this.Controls.Add(this.lblContent1);
            this.Controls.Add(this.picImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VocabularyFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "8B086D72-A6D4-40C8-A1BB-EF4978231E81";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseDown);
            this.MouseLeave += new System.EventHandler(this.VocabularyFrm_MouseLeave);
            this.MouseHover += new System.EventHandler(this.VocabularyFrm_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VocabularyFrm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblContent1;
        private System.Windows.Forms.Label lblContent2;

    }
}

