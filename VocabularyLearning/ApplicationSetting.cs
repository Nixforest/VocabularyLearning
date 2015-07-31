using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace VocabularyLearning
{
    /// <summary>
    /// Setting application
    /// </summary>
    [Serializable()]
    public class ApplicationSetting : ISerializable
    {
        /// <summary>
        /// Link of resource
        /// </summary>
        [Serializable()]
        public struct ResourceLink
        {
            /// <summary>
            /// Link
            /// </summary>
            public string path;
            /// <summary>
            /// Language 1
            /// </summary>
            public LearningLanguage Term1Lang;
            /// <summary>
            /// Language 2
            /// </summary>
            public LearningLanguage Term2Lang;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="info">Information</param>
            /// <param name="context">Context</param>
            public ResourceLink(SerializationInfo info, StreamingContext context)
            {
                path = (string)info.GetValue("AS_Path", typeof(string));
                Term1Lang = (LearningLanguage)info.GetValue("AS_Term1Lang", typeof(LearningLanguage));
                Term2Lang = (LearningLanguage)info.GetValue("AS_Term2Lang", typeof(LearningLanguage));
            }

            /// <summary>
            /// Get data
            /// </summary>
            /// <param name="info">Information</param>
            /// <param name="context">Context</param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("AS_Path", path);
                info.AddValue("AS_Term1Lang", Term1Lang);
                info.AddValue("AS_Term2Lang", Term2Lang);
            }
        }
        /// <summary>
        /// Setting file time
        /// </summary>
        public DateTime SettingFileTime { get; set; }
        /// <summary>
        /// Generate order
        /// </summary>
        public int GeneratedOrder { get; set; }
        /// <summary>
        /// Get timer interval: show time
        /// </summary>
        public int ShowTimeInterval { get; set; }
        /// <summary>
        /// Get timer interval: appear time
        /// </summary>
        public int AppearTimeInterval { get; set; }
        /// <summary>
        /// Resource file path
        /// </summary>
        public ResourceLink ResourceFilePath { get; set; }
        /// <summary>
        /// Is play repeat?
        /// </summary>
        public bool PlayRepeat { get; set; }
        /// <summary>
        /// Background?
        /// </summary>
        public bool NoBackground { get; set; }
        /// <summary>
        /// Get opacity property
        /// </summary>
        public double Opacity { get; set; }
        /// <summary>
        /// Sort random terms
        /// </summary>
        public bool RandomSort { get; set; }
        /// <summary>
        /// Get topmost option
        /// </summary>
        public bool TopMost { get; set; }
        /// <summary>
        /// Show image?
        /// </summary>
        public bool IncludedImage { get; set; }
        /// <summary>
        /// Width of term
        /// </summary>
        public int TermWidth { get; set; }
        /// <summary>
        /// Start position
        /// </summary>
        public int StartPosition { get; set; }
        /// <summary>
        /// Font of term 1
        /// </summary>
        public Font Term1Font { get; set; }
        /// <summary>
        /// Font of term 2
        /// </summary>
        public Font Term2Font { get; set; }
        /// <summary>
        /// Color of term 1
        /// </summary>
        public Color Term1Color { get; set; }
        /// <summary>
        /// Color of term 2
        /// </summary>
        public Color Term2Color { get; set; }
        /// <summary>
        /// Load from Quizlet
        /// </summary>
        public bool IsLoadFromQuizlet { get; set; }
        /// <summary>
        /// Quizlet path list
        /// </summary>
        public List<ResourceLink> QuizletPathList { get; set; }
        /// <summary>
        /// List learn items
        /// </summary>
        public List<LearnItem> ListOfLearnItem { get; set; }
        /// <summary>
        /// List of remove learn items
        /// </summary>
        public List<LearnItem> ListOfRemovedLearnItem { get; set; }
        /// <summary>
        /// Index of showed item
        /// </summary>
        public int ItemShowedIndex { get; set; }
        /// <summary>
        /// Confirm mode
        /// </summary>
        public bool ConfirmMode { get; set; }
        /// <summary>
        /// Config resource
        /// </summary>
        public string CONFIG_RESOURCE = @".\AppConfig.xml";
        /// <summary>
        /// Current setting
        /// </summary>
        public string CURRENT_SETTING = @".\CurrentAppConfig.dat";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isNewLoad"></param>
        public ApplicationSetting(bool isNewLoad = false)
        {
            if (isNewLoad)
            {
                LoadSetting();
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Information</param>
        /// <param name="context"></param>
        public ApplicationSetting(SerializationInfo info, StreamingContext context)
        {
            SettingFileTime = (DateTime)info.GetValue("AS_SettingFileTime", typeof(DateTime));
            GeneratedOrder = (int)info.GetValue("AS_GeneratedOrder", typeof(int));
            ShowTimeInterval = (int)info.GetValue("AS_ShowTimeInterval", typeof(int));
            AppearTimeInterval = (int)info.GetValue("AS_AppearTimeInterval", typeof(int));
            ResourceFilePath = (ResourceLink)info.GetValue("AS_ResourceFilePath", typeof(ResourceLink));
            PlayRepeat = (bool)info.GetValue("AS_PlayRepeat", typeof(bool));
            NoBackground = (bool)info.GetValue("AS_NoBackground", typeof(bool));
            Opacity = (double)info.GetValue("AS_Opacity", typeof(double));
            RandomSort = (bool)info.GetValue("AS_RandomSort", typeof(bool));
            TopMost = (bool)info.GetValue("AS_TopMost", typeof(bool));
            IncludedImage = (bool)info.GetValue("AS_IncludedImage", typeof(bool));
            TermWidth = (int)info.GetValue("AS_TermWidth", typeof(int));
            StartPosition = (int)info.GetValue("AS_StartPosition", typeof(int));
            Term1Font = (Font)info.GetValue("AS_Term1Font", typeof(Font));
            Term2Font = (Font)info.GetValue("AS_Term2Font", typeof(Font));
            Term1Color = (Color)info.GetValue("AS_Term1Color", typeof(Color));
            Term2Color = (Color)info.GetValue("AS_Term2Color", typeof(Color));
            IsLoadFromQuizlet = (bool)info.GetValue("AS_IsLoadFromQuizlet", typeof(bool));
            QuizletPathList = (List<ResourceLink>)info.GetValue("AS_QuizletPathList", typeof(List<ResourceLink>));
            ListOfLearnItem = (List<LearnItem>)info.GetValue("AS_ListOfLearnItem", typeof(List<LearnItem>));
            ListOfRemovedLearnItem = (List<LearnItem>)info.GetValue("AS_ListOfRemovedLearnItem", typeof(List<LearnItem>));
            CONFIG_RESOURCE = (string)info.GetValue("AS_CONFIG_RESOURCE", typeof(string));
            CURRENT_SETTING = (string)info.GetValue("AS_CURRENT_SETTING", typeof(string));
            ItemShowedIndex = (int)info.GetValue("AS_ItemShowedIndex", typeof(int));
            ConfirmMode = (bool)info.GetValue("AS_ConfirmMode", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AS_SettingFileTime", SettingFileTime);
            info.AddValue("AS_GeneratedOrder", GeneratedOrder);
            info.AddValue("AS_ShowTimeInterval", ShowTimeInterval);
            info.AddValue("AS_AppearTimeInterval", AppearTimeInterval);
            info.AddValue("AS_ResourceFilePath", ResourceFilePath);
            info.AddValue("AS_PlayRepeat", PlayRepeat);
            info.AddValue("AS_NoBackground", NoBackground);
            info.AddValue("AS_Opacity", Opacity);
            info.AddValue("AS_RandomSort", RandomSort);
            info.AddValue("AS_TopMost", TopMost);
            info.AddValue("AS_IncludedImage", IncludedImage);
            info.AddValue("AS_TermWidth", TermWidth);
            info.AddValue("AS_StartPosition", StartPosition);
            info.AddValue("AS_Term1Font", Term1Font);
            info.AddValue("AS_Term2Font", Term2Font);
            info.AddValue("AS_Term1Color", Term1Color);
            info.AddValue("AS_Term2Color", Term2Color);
            info.AddValue("AS_IsLoadFromQuizlet", IsLoadFromQuizlet);
            info.AddValue("AS_QuizletPathList", QuizletPathList);
            info.AddValue("AS_ListOfLearnItem", ListOfLearnItem);
            info.AddValue("AS_ListOfRemovedLearnItem", ListOfRemovedLearnItem);
            info.AddValue("AS_CONFIG_RESOURCE", CONFIG_RESOURCE);
            info.AddValue("AS_CURRENT_SETTING", CURRENT_SETTING);
            info.AddValue("AS_ItemShowedIndex", ItemShowedIndex);
            info.AddValue("AS_ConfirmMode", ConfirmMode);
        }

        private void LoadSetting()
        {
            //generate order
            GeneratedOrder = 0;
            ItemShowedIndex = -1;
            ListOfRemovedLearnItem = new List<LearnItem>();
            XmlDocument config = new XmlDocument();
            if (File.Exists(CONFIG_RESOURCE) == true)
            {
                try
                {
                config.Load(CONFIG_RESOURCE);
                SettingFileTime = File.GetLastWriteTime(CONFIG_RESOURCE);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Load Setting File Content is fail. \n" + e.Message);
                }

                try
                {

                    //ShowTimeInterval
                    ShowTimeInterval = GetIntegerValue(config, "/AppConfig/ShowTimeInterval");

                    //AppearTimeInterval
                    AppearTimeInterval = GetIntegerValue(config, "/AppConfig/AppearTimeInterval");

                    //ResourceFilePath
                    ResourceFilePath = ConvertToLink(config, "/AppConfig/ResourceFilePath");

                    //PlayRepeat
                    PlayRepeat = GetBoolValue(config, "/AppConfig/PlayRepeat");

                    //NoBackground
                    NoBackground = GetBoolValue(config, "/AppConfig/NoBackground");

                    //Opacity
                    Opacity = GetDoubleValue(config, "/AppConfig/Opacity");

                    //RandomSort
                    RandomSort = GetBoolValue(config, "/AppConfig/RandomSort");

                    //ConfirmMode
                    ConfirmMode = GetBoolValue(config, "/AppConfig/ConfirmMode");

                    //TopMost
                    TopMost = GetBoolValue(config, "/AppConfig/TopMost");

                    //IncludedImage
                    IncludedImage = GetBoolValue(config, "/AppConfig/IncludeImage");

                    //TearmWidth
                    TermWidth = GetIntegerValue(config, "/AppConfig/TermWidth");

                    //StartPosition
                    StartPosition = GetIntegerValue(config, "/AppConfig/StartPosition");

                    //TermFont
                    Term1Font = GetFontValue(config, "/AppConfig/Term1Font");
                    Term1Color = GetFontColorValue(config, "/AppConfig/Term1Font");
                    Term2Font = GetFontValue(config, "/AppConfig/Term2Font");
                    Term2Color = GetFontColorValue(config, "/AppConfig/Term2Font");

                    //LoadQuizletSetting
                    GetQuizletSetting(config);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private bool GetBoolValue(XmlDocument config, string xpath)
        {
            string stringvalue = config.DocumentElement.SelectSingleNode(xpath).InnerText;
            if (stringvalue.CompareTo("1") == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetIntegerValue(XmlDocument config, string xpath)
        {
            string stringvalue = config.DocumentElement.SelectSingleNode(xpath).InnerText;
            if (stringvalue.Trim().Length > 0)
            {
                return Int32.Parse(stringvalue);
            }
            else
            {
                return Int32.MinValue;
            }
        }

        private double GetDoubleValue(XmlDocument config, string xpath)
        {
            string stringvalue = config.DocumentElement.SelectSingleNode(xpath).InnerText;
            if (stringvalue.Trim().Length > 0)
            {
                return Double.Parse(stringvalue);
            }
            else
            {
                return Double.MinValue;
            }
        }

        private string GetStringValue(XmlDocument config, string xpath)
        {
            return config.DocumentElement.SelectSingleNode(xpath).InnerText;
        }

        private Font GetFontValue(XmlDocument config, string xpath)
        {
            XmlNode node = config.DocumentElement.SelectSingleNode(xpath);
            string fname = node.InnerText;
            int fSize = Int32.Parse(node.Attributes["size"].Value);
            bool isBold = Boolean.Parse(node.Attributes["isBold"].Value);
            if (isBold)
            {
                return new Font(fname, fSize, FontStyle.Bold);
            }
            else
            {
                return new Font(fname, fSize);
            }
        }

        private Color GetFontColorValue(XmlDocument config, string xpath)
        {
            XmlNode node = config.DocumentElement.SelectSingleNode(xpath);
            string termcolor = node.Attributes["RGB"].Value;
            string[] rgb = termcolor.Split(',');
            return Color.FromArgb(
                Int16.Parse(rgb[0]), 
                Int16.Parse(rgb[1]),
                Int16.Parse(rgb[2])
            );
        }

        private void GetQuizletSetting(XmlDocument config)
        {
            XmlNode node = config.DocumentElement.SelectSingleNode("/AppConfig/DataFromQuizlet");
            IsLoadFromQuizlet = Boolean.Parse(node.Attributes["isUse"].Value);
            QuizletPathList = new List<ResourceLink>();
            if (IsLoadFromQuizlet && node.HasChildNodes)
            {
                foreach (XmlNode linknode in node.ChildNodes)
                {
                    if (linknode.Name.CompareTo("SetLink") == 0)
                    {
                        QuizletPathList.Add(ConvertToLink(linknode));
                    }
                    else if (linknode.Name.CompareTo("ClassLink") == 0)
                    {
                        GetQuizletLinkByClassLink(linknode.InnerText);
                    }
                }
            }
         }

        private void GetQuizletLinkByClassLink(string quizSetLink)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(quizSetLink);
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                string pattern = @"\<article class\=\""feed\-preview set\-preview\"" data\-type\=\""1\"" data-id\=\""(?<id>[0-9]{8})\""\>";
                Regex regex = new Regex(pattern);
                MatchCollection matchs = regex.Matches(result);
                foreach (Match match in matchs)
                {
                    ResourceLink link = new ResourceLink();
                    link.path = string.Format(@"http://quizlet.com/{0}/export", match.Groups["id"].Value);
                    link.Term1Lang = LearningLanguage.JP;
                    link.Term2Lang = LearningLanguage.VN;
                    QuizletPathList.Add(link);
                }
            }
            catch
            {

            }
        }

        public void ShuffleRandomListItem()
        {
            List<LearnItem> randomList = new List<LearnItem>();

            Random r = new Random();
            int randomIndex = 0;
            while (ListOfLearnItem.Count > 0)
            {
                randomIndex = r.Next(0, ListOfLearnItem.Count); //Choose a random object in the list
                randomList.Add(ListOfLearnItem[randomIndex]); //add it to the new, random list
                ListOfLearnItem.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            for (int i = 1; i <= randomList.Count; i++)
            {
                randomList[i - 1].DisplayOrder = i;
            }

            ListOfLearnItem = randomList; //return the new random list
        }

        private LearningLanguage ConvertToLanguage(string langCode)
        {
            switch (langCode)
            {
                case "EN":
                    return LearningLanguage.EN;
                case "JP":
                    return LearningLanguage.JP;
                case "TH":
                    return LearningLanguage.TH;
                case "VN":
                    return LearningLanguage.VN;
                default:
                    MessageBox.Show("Language is not support, converted to English.");
                    return LearningLanguage.EN;
            }
        }

        private ResourceLink ConvertToLink(XmlDocument config, string xpath)
        {
            XmlNode linknode = config.DocumentElement.SelectSingleNode(xpath);
            return ConvertToLink(linknode);
        }

        private ResourceLink ConvertToLink(XmlNode linknode)
        {
            ResourceLink quiz = new ResourceLink();

            if (linknode != null)
            {
                quiz.path = linknode.InnerText;

                if (linknode.Attributes["Lang1"] != null)
                {
                    quiz.Term1Lang = ConvertToLanguage(linknode.Attributes["Lang1"].Value);
                }

                if (linknode.Attributes["Lang2"] != null)
                {
                    quiz.Term2Lang = ConvertToLanguage(linknode.Attributes["Lang2"].Value);
                }
            }
            return quiz;
        }

        public void RemoveItem(int CurrentDisplayedIndex)
        {
            ListOfRemovedLearnItem.Add(ListOfLearnItem[CurrentDisplayedIndex]);
            ListOfLearnItem.RemoveAt(CurrentDisplayedIndex);
            ItemShowedIndex--;
        }


    }

}
