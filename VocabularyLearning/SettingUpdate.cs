using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VocabularyLearning
{
    public partial class SettingUpdate : Form
    {
        public int WM_USER = 0x0400;
        public int WM_REFRESH_SCREEN = 0x0400 + 100;
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        FontDialog font1 = new FontDialog();
        FontDialog font2 = new FontDialog();
        ColorDialog color1 = new ColorDialog();
        ColorDialog color2 = new ColorDialog();

        public SettingUpdate()
        {
            InitializeComponent();
        }

        private void btnApple_Click(object sender, EventArgs e)
        {
            //Set time interval
            SettingTimeInterval(txtTimeInterval.Text);
            VocabularyFrm.AppConfig.PlayRepeat = ckbPlayRepeat.Checked;
            VocabularyFrm.AppConfig.ConfirmMode = chkConfirmMode.Checked;
            //Random Sort
            if (ckbRandomSort.Checked)
            {
                VocabularyFrm.AppConfig.RandomSort = ckbRandomSort.Checked;
                VocabularyFrm.AppConfig.ShuffleRandomListItem();
            }

            VocabularyFrm.AppConfig.Term1Font = font1.Font;
            VocabularyFrm.AppConfig.Term2Font = font2.Font;
            VocabularyFrm.AppConfig.Term1Color = color1.Color;
            VocabularyFrm.AppConfig.Term2Color = color2.Color;
            int mainfrm = FindWindow(null, "VocabularyLearning");
            SendMessage((IntPtr)mainfrm, WM_REFRESH_SCREEN, IntPtr.Zero, IntPtr.Zero);
        }

        private void SettingTimeInterval(string input)
        {
            if (input.Length <= 0) return;
            int newTimeInterval = VocabularyFrm.AppConfig.AppearTimeInterval;
            try
            {
                newTimeInterval = Int32.Parse(input);
                if (newTimeInterval > 0 && newTimeInterval != VocabularyFrm.AppConfig.AppearTimeInterval)
                {
                    VocabularyFrm.AppConfig.ShowTimeInterval = newTimeInterval;
                    VocabularyFrm.timerControl.Interval = VocabularyFrm.AppConfig.ShowTimeInterval;
                    VocabularyFrm.timerDisplay.Interval = VocabularyFrm.AppConfig.ShowTimeInterval / 2;
                }
            }
            catch
            {
                MessageBox.Show("Value of Rotation Time Interval is wrong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingUpdate_Load(object sender, EventArgs e)
        {
            ckbPlayRepeat.Checked = VocabularyFrm.AppConfig.PlayRepeat;
            ckbRandomSort.Checked = VocabularyFrm.AppConfig.RandomSort;
            chkConfirmMode.Checked = VocabularyFrm.AppConfig.ConfirmMode;
            txtTimeInterval.Text = VocabularyFrm.AppConfig.ShowTimeInterval.ToString();

            font1.Font = VocabularyFrm.AppConfig.Term1Font;
            font2.Font = VocabularyFrm.AppConfig.Term2Font;

            lblFont1.Text = FontPrint(VocabularyFrm.AppConfig.Term1Font);
            lblFont1.Font = VocabularyFrm.AppConfig.Term1Font;
            lblFont1.ForeColor = VocabularyFrm.AppConfig.Term1Color;
            color1.Color = VocabularyFrm.AppConfig.Term1Color;

            lblFont2.Text = FontPrint(VocabularyFrm.AppConfig.Term2Font);
            lblFont2.Font = VocabularyFrm.AppConfig.Term2Font;
            lblFont2.ForeColor = VocabularyFrm.AppConfig.Term2Color;
            color2.Color = VocabularyFrm.AppConfig.Term2Color;
        }

        private void btnFont1_Click(object sender, EventArgs e)
        {
            
            if (font1.ShowDialog() == DialogResult.OK)
            {
                lblFont1.Text = FontPrint(font1.Font);
                lblFont1.Font = font1.Font;
            }
        }

        private void btnFont2_Click(object sender, EventArgs e)
        {
            if (font2.ShowDialog() == DialogResult.OK)
            {
                lblFont2.Text = FontPrint(font2.Font);
                lblFont2.Font = font2.Font;
            }
        }

        private string FontPrint(Font font)
        {
            string str = string.Format("{0}, {1}, {2}", font.Name, font.Size, font.Style);
            return str;
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            if (color1.ShowDialog() == DialogResult.OK)
            {
                lblFont1.ForeColor = color1.Color;
            }
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            if (color2.ShowDialog() == DialogResult.OK)
            {
                lblFont2.ForeColor = color2.Color;
            }
        }

    }
}
