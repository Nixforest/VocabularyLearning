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
    /// <summary>
    /// Class Setting update
    /// </summary>
    public partial class SettingUpdate : Form
    {
        /// <summary>
        /// User message
        /// </summary>
        public int WM_USER = 0x0400;
        /// <summary>
        /// Find window by class name and window name
        /// </summary>
        /// <param name="lpClassName">Class name</param>
        /// <param name="lpWindowName">Window name</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, String lpWindowName);
        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="hWnd">Handle of windows receive message</param>
        /// <param name="wMsg">Message content</param>
        /// <param name="wParam">Word param</param>
        /// <param name="lParam">Long param</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Font of term 1
        /// </summary>
        FontDialog font1 = new FontDialog();
        /// <summary>
        /// Font of term 2
        /// </summary>
        FontDialog font2 = new FontDialog();
        /// <summary>
        /// Color of term 1
        /// </summary>
        ColorDialog color1 = new ColorDialog();
        /// <summary>
        /// Color of term 2
        /// </summary>
        ColorDialog color2 = new ColorDialog();
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle click Apply button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnApple_Click(object sender, EventArgs e)
        {
            //Set time interval
            SettingTimeInterval(txtTimeInterval.Text);
            VocabularyFrm.AppConfig.PlayRepeat = ckbPlayRepeat.Checked;
            VocabularyFrm.AppConfig.ConfirmMode = chkConfirmMode.Checked;
            // NguyenPT
            VocabularyFrm.AppConfig.NoBackground = !chkBackground.Checked;
            VocabularyFrm.AppConfig.IncludedImage = chkImage.Checked;
            VocabularyFrm.AppConfig.Opacity = trackBarOpacity.Value / 100;
            VocabularyFrm.AppConfig.TopMost = chkTopmost.Checked;
            // NguyenPT
            //Random Sort
            //++ Mod (20150821 NguyenPT) Update list items orders
            int mainfrm = FindWindow(null, "8B086D72-A6D4-40C8-A1BB-EF4978231E81");
            if (VocabularyFrm.AppConfig.RandomSort != ckbRandomSort.Checked)
            {
                VocabularyFrm.AppConfig.RandomSort = ckbRandomSort.Checked;
                SendMessage((IntPtr)mainfrm, VocabularyFrm.WM_REFRESH_LISTITEM, IntPtr.Zero, IntPtr.Zero);
            }
            //if (ckbRandomSort.Checked)
            //{
            //    VocabularyFrm.AppConfig.RandomSort = ckbRandomSort.Checked;
            //    VocabularyFrm.AppConfig.ShuffleRandomListItem();
            //}
            //-- Mod (20150821 NguyenPT)

            VocabularyFrm.AppConfig.Term1Font = font1.Font;
            VocabularyFrm.AppConfig.Term2Font = font2.Font;
            VocabularyFrm.AppConfig.Term1Color = color1.Color;
            VocabularyFrm.AppConfig.Term2Color = color2.Color;
            //++ Mod (20150821 NguyenPT) Move up
            //int mainfrm = FindWindow(null, "8B086D72-A6D4-40C8-A1BB-EF4978231E81");
            //SendMessage((IntPtr)mainfrm, WM_REFRESH_SCREEN, IntPtr.Zero, IntPtr.Zero);
            SendMessage((IntPtr)mainfrm, VocabularyFrm.WM_REFRESH_SCREEN, IntPtr.Zero, IntPtr.Zero);
            //-- Mod (20150821 NguyenPT)
        }
        /// <summary>
        /// Setting time interval
        /// </summary>
        /// <param name="input">Input value</param>
        private void SettingTimeInterval(string input)
        {
            // If not input: return function
            if (input.Length <= 0) return;
            // Get old value
            int newTimeInterval = VocabularyFrm.AppConfig.AppearTimeInterval;
            try
            {
                // Parse value from input string
                newTimeInterval = Int32.Parse(input);
                // Check new value
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
        /// <summary>
        /// Handle click Close button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load update setting
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void SettingUpdate_Load(object sender, EventArgs e)
        {
            ckbPlayRepeat.Checked = VocabularyFrm.AppConfig.PlayRepeat;
            ckbRandomSort.Checked = VocabularyFrm.AppConfig.RandomSort;
            chkConfirmMode.Checked = VocabularyFrm.AppConfig.ConfirmMode;
            // NguyenPT
            chkBackground.Checked = !VocabularyFrm.AppConfig.NoBackground;
            chkImage.Checked = VocabularyFrm.AppConfig.IncludedImage;
            chkTopmost.Checked = VocabularyFrm.AppConfig.TopMost;
            trackBarOpacity.Value = (int)(VocabularyFrm.AppConfig.Opacity * 100);
            // NguyenPT
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
        /// <summary>
        /// Handle click Font1 button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnFont1_Click(object sender, EventArgs e)
        {
            
            if (font1.ShowDialog() == DialogResult.OK)
            {
                lblFont1.Text = FontPrint(font1.Font);
                lblFont1.Font = font1.Font;
            }
        }

        /// <summary>
        /// Handle click Font2 button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnFont2_Click(object sender, EventArgs e)
        {
            if (font2.ShowDialog() == DialogResult.OK)
            {
                lblFont2.Text = FontPrint(font2.Font);
                lblFont2.Font = font2.Font;
            }
        }
        /// <summary>
        /// Show example font
        /// </summary>
        /// <param name="font">Font</param>
        /// <returns>String of font</returns>
        private string FontPrint(Font font)
        {
            string str = string.Format("{0}, {1}, {2}", font.Name, font.Size, font.Style);
            return str;
        }

        /// <summary>
        /// Handle click Color1 button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnColor1_Click(object sender, EventArgs e)
        {
            if (color1.ShowDialog() == DialogResult.OK)
            {
                lblFont1.ForeColor = color1.Color;
            }
        }

        /// <summary>
        /// Handle click Color2 button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnColor2_Click(object sender, EventArgs e)
        {
            if (color2.ShowDialog() == DialogResult.OK)
            {
                lblFont2.ForeColor = color2.Color;
            }
        }

    }
}
