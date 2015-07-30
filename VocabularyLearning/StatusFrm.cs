using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VocabularyLearning
{
    public partial class StatusFrm : Form
    {
        public static int ItemCount;
        public static int CurrentDisplayedItem;
        public static int ItemId;
        public static int ItemDisplayOrder;
        public static bool IsFavorite;
        
        public StatusFrm()
        {
            InitializeComponent();
            BackColor = Color.White;
            TransparencyKey = Color.White;
            this.TopMost = true;
        }

        private void StatusFrm_Load(object sender, EventArgs e)
        {
            ItemCount = VocabularyFrm.AppConfig.ListOfLearnItem.Count;
            CurrentDisplayedItem = VocabularyFrm.AppConfig.ItemShowedIndex;
            LearnItem currItem = VocabularyFrm.AppConfig.ListOfLearnItem[CurrentDisplayedItem];
            ItemId = currItem.Id;

            String msg = String.Format("Total Item: {0}\nDisplay at time: {1}\nItem ID: {2}\nDeleted Item:{3}", ItemCount, CurrentDisplayedItem, ItemId, VocabularyFrm.AppConfig.ListOfRemovedLearnItem.Count);
            this.lblStatus.Text = msg;

            Timer timer = new Timer();
            timer.Interval = 4000;
            timer.Tick += CloseApp;
            timer.Start();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
