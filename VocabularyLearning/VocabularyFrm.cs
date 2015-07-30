using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using HtmlAgilityPack;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace VocabularyLearning
{
    public partial class VocabularyFrm : Form
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public int WM_REFRESH_SCREEN = 0x0400 + 100;

        [DllImport("WtsApi32.dll")]
        private static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)]int dwFlags);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);

        private const int NOTIFY_FOR_THIS_SESSION = 0;
        private const int WM_WTSSESSION_CHANGE = 0x2b1;
        private const int WTS_SESSION_LOCK = 0x7;
        private const int WTS_SESSION_UNLOCK = 0x8;


        double OPACITY_MIN = 0.4;
        double OPACITY_PLUS = 0.1;
        int IMGBOX_WIDTH = 110;
        int PADDING = 5;

        public static Timer timerControl = new Timer();
        public static Timer timerDisplay = new Timer();
        Timer appearTimer = new Timer();
        StatusFrm statusform;

        public static ApplicationSetting AppConfig= new ApplicationSetting(false);
        const int MYACTION_HOTKEY_ID = 1000;
        public static bool REFRESH_SCREEN_FLAG = false;

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public VocabularyFrm()
        {
            InitializeComponent();
            int id = 0;     // The id of the hotkey. 
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.OemQuestion.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.Down.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.Up.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.Right.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.Left.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.End.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.OemMinus.GetHashCode());
            RegisterHotKey(this.Handle, id, (uint)KeyModifier.Control, (uint)Keys.F1.GetHashCode());
            WTSRegisterSessionNotification(this.Handle, NOTIFY_FOR_THIS_SESSION);
        }

        private void LoadAppConfiguration()
        {
            if (File.Exists(AppConfig.CURRENT_SETTING))
            {
                ApplicationSetting setTemp = DeSerializeObject(AppConfig.CURRENT_SETTING);
                if (setTemp != null)
                {
                    if (File.GetLastWriteTime(AppConfig.CONFIG_RESOURCE).CompareTo(setTemp.SettingFileTime) == 0)
                    {
                        AppConfig = setTemp;
                        //return;
                    }
                }
            }
            AppConfig = new ApplicationSetting(true);
            //Load First item
            AppConfig.ListOfLearnItem = this.LoadData();
            if (AppConfig.ListOfLearnItem.Count >= 1)
            {
                if (AppConfig.RandomSort)
                {
                    AppConfig.ShuffleRandomListItem();
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_REFRESH_SCREEN)
            {
                UpdateScreen();
            }
            else if (m.Msg == WM_WTSSESSION_CHANGE)
            {
                int value = m.WParam.ToInt32();
                if (value == WTS_SESSION_LOCK)
                {
                    timerControl.Stop();
                }
                else if (value == WTS_SESSION_UNLOCK)
                {
                    timerControl.Start();
                }
            }

            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);

                if (modifier == KeyModifier.Control)
                {
                    switch (key)
                    {
                        case Keys.OemQuestion:
                            if (statusform != null && statusform.Visible) statusform.Close();
                            statusform = new StatusFrm();
                            statusform.StartPosition = FormStartPosition.Manual;
                            statusform.Top = this.Top;
                            statusform.Left = this.Left - statusform.Width;
                            statusform.Show();
                            break;
                        case Keys.Up:
                            if (timerControl.Enabled == false)
                            {
                                timerControl.Start();
                                timerDisplay.Start();
                                NextItem(timerControl, new EventArgs());
                            }
                            break;
                        case Keys.Down:
                            timerControl.Stop();
                            timerDisplay.Stop();
                            if (lblContent2.Visible == false) lblContent2.Visible = true;
                            break;
                        case Keys.Right:
                            NextItem(timerControl, new EventArgs());
                            //timerControl.Start();
                            break;
                        case Keys.Left:
                            if (AppConfig.ItemShowedIndex > 0)
                            {
                                AppConfig.ItemShowedIndex -= 2;
                            }
                            else
                            {
                                AppConfig.ItemShowedIndex--;
                            }
                            NextItem(timerControl, null);
                            break;
                        case Keys.OemMinus:
                            AppConfig.RemoveItem(AppConfig.ItemShowedIndex);
                            NextItem(timerControl, new EventArgs());
                            break;
                        case Keys.F1:
                            SettingUpdate updatefrm = new SettingUpdate();
                            updatefrm.Show();
                            break;
                        case Keys.End:
                            this.CloseApp();
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            //Load Configuration
            LoadAppConfiguration();

            SettingBackground();
            CustomizeWindowSize();
            CustomizeWindowPosition();
            CustomizeControlFont();

            //Order window
            if (AppConfig.TopMost)
            {
                this.TopMost = true;
            }

            timerControl.Interval = AppConfig.ShowTimeInterval;
            timerControl.Tick += NextItem;
            timerControl.Start();

            timerDisplay.Interval = AppConfig.ShowTimeInterval / 2;
            timerDisplay.Tick += DisplayTerm2;
            timerDisplay.Start();

            base.OnLoad(e);
            NextItem(timerControl, new EventArgs());
        }

        private void VocabularyFrm_MouseHover(object sender, EventArgs e)
        {
            //this.Opacity = OPACITY_MAX;
        }

        private void VocabularyFrm_MouseLeave(object sender, EventArgs e)
        {
            //this.Opacity = OPACITY_MIN;
        }

        private void VocabularyFrm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.CloseApp();
            }
        }

        private void AppearShow()
        {
            this.Opacity = 0.0;
            this.Show();
            appearTimer.Interval = AppConfig.AppearTimeInterval;
            appearTimer.Tick += OpacityUp;
            appearTimer.Start();
        }

        private void OpacityUp(object sender, EventArgs e)
        {
            this.Opacity += OPACITY_PLUS;
            if (this.Opacity >= OPACITY_MIN)
            {
                appearTimer.Stop();
            }
        }

        private void NextItem(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + " ->Next Item");
            if (AppConfig.ListOfLearnItem.Count == 0)
            {
                timerControl.Stop();
                MessageBox.Show("Data record is empty. Application will be closed!\nPlease check your data.");
                this.CloseApp();
            }
            AppConfig.ItemShowedIndex++;
            if (AppConfig.ItemShowedIndex < 0) AppConfig.ItemShowedIndex = 0;
            if (AppConfig.ItemShowedIndex < AppConfig.ListOfLearnItem.Count)
            {
                if (AppConfig.ConfirmMode && timerDisplay.Enabled)
                {
                    lblContent2.Visible = false;
                    timerDisplay.Stop();
                    timerDisplay.Start();
                }
                LearnItem li = AppConfig.ListOfLearnItem[AppConfig.ItemShowedIndex];
                if (AppConfig.IncludedImage && li.ImageSource != null)
                {
                    // NguyenPT
                    try
                    {
                        // Change method load image
                        //this.picImage.Load(li.ImageSource);
                        this.picImage.WaitOnLoad = false;
                        this.picImage.LoadAsync(li.ImageSource);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    // NguyenPT                    
                }
                // NguyenPT
                else
                {
                    // If last image is not null -> reset it
                    if (this.picImage.Image != null)
                    {
                        this.picImage.Image.Dispose();
                        this.picImage.Image = null;
                    }
                }
                // NguyenPT
                if (li.Content1Lang != LearningLanguage.VN)
                {
                    this.lblContent1.Text = li.Content1;
                    this.lblContent2.Text = li.Content2;
                }
                else
                {
                    this.lblContent1.Text = li.Content2;
                    this.lblContent2.Text = li.Content1;
                }

                if (this.Visible == false)
                {
                    //this.AppearShow();
                    this.Show();
                    this.TopMost = true;
                }
            }
                //Repeat
            else if(AppConfig.PlayRepeat)
            {
                AppConfig.ItemShowedIndex = 0;
                if (AppConfig.RandomSort)
                {
                    AppConfig.ShuffleRandomListItem();
                }
            }
            else
            {
                timerControl.Stop();
                this.CloseApp();
            }
        }

        private void DisplayTerm2(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + " ->Display Term2");
            if (lblContent2.Visible == false)
            {
                lblContent2.Visible = true;
            }
        }

        private List<LearnItem> ShuffleList(List<LearnItem> inputList)
        {
            List<LearnItem> randomList = new List<LearnItem>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            for (int i = 1; i <= randomList.Count; i++)
            {
                randomList[i - 1].DisplayOrder = i;
            }

            return randomList; //return the new random list
        }

        private void SettingBackground()
        {
            if(AppConfig.NoBackground)
            {
                Color delColor = AppConfig.IncludedImage ? Color.Magenta : Color.White;

                BackColor = delColor;
                TransparencyKey = delColor;
            }
            else
            {
                BackColor = Color.GreenYellow;
                Opacity = AppConfig.Opacity;
            }
        }

        private void CustomizeWindowSize()
        {
            if (AppConfig.IncludedImage == false)
            {
                this.picImage.Visible = false;
                this.Width = AppConfig.TermWidth;
                this.lblContent1.Width = AppConfig.TermWidth - PADDING;
                this.lblContent2.Width = AppConfig.TermWidth - PADDING;
            }
            else
            {
                this.picImage.Visible = true;
                this.picImage.Location = new Point(AppConfig.TermWidth + PADDING, PADDING);
                this.Width = AppConfig.TermWidth + IMGBOX_WIDTH;
                this.lblContent1.Width = AppConfig.TermWidth - PADDING;
                this.lblContent2.Width = AppConfig.TermWidth - PADDING;
            }
        }

        private void CustomizeWindowPosition()
        {
            Screen rightmost = Screen.AllScreens.OrderBy(s => s.WorkingArea.Right).Last();
            switch (AppConfig.StartPosition)
            {
                case 1:
                    this.Left = rightmost.WorkingArea.Right - this.Width;
                    this.Top = rightmost.WorkingArea.Bottom - this.Height;
                    break;
                case 2:
                    this.Left = rightmost.WorkingArea.Right - this.Width;
                    this.Top = (rightmost.WorkingArea.Bottom / 2) - (this.Height / 2);
                    break;
                default:
                    this.Left = rightmost.WorkingArea.Right - this.Width;
                    this.Top = rightmost.WorkingArea.Bottom - this.Height;
                    break;
            }
         }

        private void CustomizeControlFont()
        {
            this.lblContent1.Font = AppConfig.Term1Font;
            this.lblContent2.Font = AppConfig.Term2Font;
            this.lblContent1.ForeColor = AppConfig.Term1Color;
            this.lblContent2.ForeColor = AppConfig.Term2Color;
        }

        private List<LearnItem> LoadData()
        {
        
            List<LearnItem> listitem = new List<LearnItem>();
            if (AppConfig.IsLoadFromQuizlet)
            {
                listitem = LoadDataFromQuizlet();
            }
            else
            {
                listitem = LoadDataFromFile(AppConfig.ResourceFilePath);
            }

            return listitem;
        }

        private List<LearnItem> LoadDataFromFile(ApplicationSetting.ResourceLink fileResource)
        {
            List<LearnItem> listitem = new List<LearnItem>();

            if (File.Exists(fileResource.path) == false)
            {
                MessageBox.Show("File source is not exists.\n" + fileResource.path);
                return listitem;
            }

            string[] contents = File.ReadAllLines(fileResource.path);

            listitem = ParseStringArray(contents, fileResource.Term1Lang, fileResource.Term2Lang);
            return listitem;
        }

        private List<LearnItem> LoadDataFromQuizlet()
        {
            List<LearnItem> lstItem = new List<LearnItem>();

            foreach (ApplicationSetting.ResourceLink quizLink in AppConfig.QuizletPathList)
            {
                string stringdata = GetStringDataFormUrl(quizLink.path);
                if(stringdata.Length == 0) continue;
                lstItem.AddRange(ParseStringArray(stringdata.Split('\n'), quizLink.Term1Lang, quizLink.Term2Lang));
            }

            return lstItem;
        }

        private List<LearnItem> ParseStringArray(string[] lines, LearningLanguage Term1Language, LearningLanguage Term2Language)
        {
            List<LearnItem> listitem = new List<LearnItem>();
            int ItemCount = lines.Count();
            if (ItemCount == 0)
                return listitem;

            //List<string> contents = File.ReadAllLines(path).ToList<string>();
            if (Term1Language != LearningLanguage.VN)
            {
                for (int i = 0; i < ItemCount; i++)
                {
                    string[] itemInLine = lines[i].Split('\t');
                    if (itemInLine.Count() >= 2)
                    {
                        LearnItem item = new LearnItem(itemInLine[0], itemInLine[1], (itemInLine.Count() >= 3 ? itemInLine[2] : null));
                        item.Content1Lang = Term1Language;
                        item.Content2Lang = Term2Language;
                        //Find tails
                        if (i < ItemCount - 1)
                        {
                            for (; i < ItemCount - 1; i++)
                            {
                                if (lines[i + 1].Contains('\t'))
                                {
                                    break;
                                }
                                else
                                {
                                    item.Content2 += "\n" + lines[i + 1];
                                }
                            }
                        }
                        listitem.Add(item);
                    }
                }
            }
            else
            {
                for (int x = 0; x < ItemCount; x++)
                {
                    string multiLineTerm = "";
                    for (; x < ItemCount - 1; x++)
                    {
                        string[] splitedItem = lines[x].Split('\t');
                        if (splitedItem.Count() < 2)
                        {
                            multiLineTerm +=lines[x] + "\n";
                        }
                        else
                        {
                            LearnItem li = new LearnItem(multiLineTerm + splitedItem[0], 
                                                        splitedItem[1], (splitedItem.Count() >= 3? splitedItem[2] : null));
                            li.Content1Lang = Term1Language;
                            li.Content2Lang = Term2Language;
                            listitem.Add(li);
                            multiLineTerm = "";
                        }
                    }
                }
            }
            return listitem;
        }

        private string GetStringDataFormUrl(string url)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(result);
                HtmlAgilityPack.HtmlNode datanode = htmldoc.GetElementbyId("js-exportData");

                if (datanode != null)
                {
                    return datanode.InnerText;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" +url);
            }
            return "";
       }

        public void SerializeObject(string filename, ApplicationSetting objectToSerialize)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Save application configuration is fail.\n" + e.Message);
            }
        }

        public ApplicationSetting DeSerializeObject(string filename)
        {
            ApplicationSetting objectToSerialize = new ApplicationSetting(false);
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (ApplicationSetting)bFormatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Load current application configuration is fail.\n" + e.Message);
            }
            return objectToSerialize;
        }

        private void CloseApp()
        {
            timerControl.Stop();
            timerDisplay.Stop();
            SerializeObject(AppConfig.CURRENT_SETTING, AppConfig);
            this.Close();
        }

        private void UpdateScreen()
        {
            this.lblContent1.Font = AppConfig.Term1Font;
            this.lblContent1.ForeColor = AppConfig.Term1Color;
            this.lblContent2.Font = AppConfig.Term2Font;
            this.lblContent2.ForeColor = AppConfig.Term2Color;
            if (AppConfig.ConfirmMode == false)
            {
                timerDisplay.Stop();
                lblContent2.Visible = true;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            // unregister the handle before it gets destroyed
            WTSUnRegisterSessionNotification(this.Handle);
            base.OnHandleDestroyed(e);
        }
    }
}
