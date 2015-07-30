using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VocabularyLearning
{
    [Serializable()]
    public class LearnItem :ISerializable
    {
        public int Id { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string ImageSource { get; set; }
        public int DisplayOrder { get; set; }
        public LearningLanguage Content1Lang { get; set; }
        public LearningLanguage Content2Lang { get; set; }

        public LearnItem()
        {
            Content1Lang = LearningLanguage.EN;
            Content2Lang = LearningLanguage.VN;
        }

        public LearnItem(string Content1, string Content2, string ImageResource)
        {
            this.Content1 = Content1;
            this.Content2 = Content2;
            this.ImageSource = ImageResource;
            this.Id = VocabularyFrm.AppConfig.GeneratedOrder++;
            Content1Lang = LearningLanguage.EN;
            Content2Lang = LearningLanguage.VN;
        }

        public LearnItem(int Order, string Content1, string Content2, 
                                    string ImageResource, int DispOrder, 
                                    LearningLanguage Term1Language, LearningLanguage Term2Language)
        {
            this.Content1 = Content1;
            this.Content2 = Content2;
            this.ImageSource = ImageResource;
            this.Id = Order;
            this.DisplayOrder = DispOrder;
            this.Content1Lang = Term1Language;
            this.Content2Lang = Term2Language;
        }

        //For Serialization
        public LearnItem(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("LI_Id", typeof(int));
            Content1 = (string)info.GetValue("LI_Content1", typeof(string));
            Content2 = (string)info.GetValue("LI_Content2", typeof(string));
            ImageSource = (string)info.GetValue("LI_ImageSource", typeof(string));
            DisplayOrder = (int)info.GetValue("LI_DisplayOrder", typeof(int));
            Content1Lang = (LearningLanguage)info.GetValue("LI_Content1Lang", typeof(LearningLanguage));
            Content2Lang = (LearningLanguage)info.GetValue("LI_Content2Lang", typeof(LearningLanguage));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LI_Id", Id);
            info.AddValue("LI_Content1", Content1);
            info.AddValue("LI_Content2", Content2);
            info.AddValue("LI_ImageSource", ImageSource);
            info.AddValue("LI_DisplayOrder", DisplayOrder);
            info.AddValue("LI_Content1Lang", Content1Lang);
            info.AddValue("LI_Content2Lang", Content2Lang);
        }
    }

    public enum LearningLanguage
    {
        EN,
        JP,
        VN,
        TH
    }
}
