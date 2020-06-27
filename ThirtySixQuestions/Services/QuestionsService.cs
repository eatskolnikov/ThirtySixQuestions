using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ThirtySixQuestions.Resx;

namespace ThirtySixQuestions.Services
{
    public class QuestionsService : IQuestionsService
    {
        public static List<String> QuestionsTexts { get; set; }
        public static List<String> SetsTexts { get; set; }

        public void Initialize()
        {
            SetsTexts = new List<string>();
            QuestionsTexts = new List<string>
            {
                Questions.Question01Text,
                Questions.Question02Text,
                Questions.Question03Text,
                Questions.Question04Text,
                Questions.Question05Text,
                Questions.Question06Text,
                Questions.Question07Text,
                Questions.Question08Text,
                Questions.Question09Text,
                Questions.Question10Text,
                Questions.Question11Text,
                Questions.Question12Text,
                Questions.Question13Text,
                Questions.Question14Text,
                Questions.Question15Text,
                Questions.Question16Text,
                Questions.Question17Text,
                Questions.Question18Text,
                Questions.Question19Text,
                Questions.Question20Text,
                Questions.Question21Text,
                Questions.Question22Text,
                Questions.Question23Text,
                Questions.Question24Text,
                Questions.Question25Text,
                Questions.Question26Text,
                Questions.Question27Text,
                Questions.Question28Text,
                Questions.Question29Text,
                Questions.Question30Text,
                Questions.Question31Text,
                Questions.Question32Text,
                Questions.Question33Text,
                Questions.Question34Text,
                Questions.Question35Text,
                Questions.Question36Text
            };

            SetsTexts.Add(Questions.Set1Text);
            SetsTexts.Add(Questions.Set2Text);
            SetsTexts.Add(Questions.Set3Text);
        }
    }

    public interface IQuestionsService
    {
        void Initialize();
    }
}
