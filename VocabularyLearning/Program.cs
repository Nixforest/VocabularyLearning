using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VocabularyLearning
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VocabularyFrm frm = new VocabularyFrm();
            try
            {
                Application.Run(frm);
            }
            catch
            {
            }
        }
    }
}
