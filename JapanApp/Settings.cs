using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JapanApp
{
    public enum LearningProgression
    {
        Locked = 0,
        NotLearned = 1,
        MustReview = 2,
        Learned = 3
    }

    public enum ExamProgression
    {
        Locked = 0,
        NotYetDone = 1,
        Failed = 2,
        MustRepass = 3,
        Passed = 4
    }

    public class DefaultSettings
    {
        public Dictionary<string, LearningProgression> Hiragana = new Dictionary<string, LearningProgression>()
        {
            { "Hiragana_Course_1" , LearningProgression.NotLearned},
            { "Hiragana_Course_2" , LearningProgression.NotLearned}
        };

        public Dictionary<string, ExamProgression> HiraganaExams = new Dictionary<string, ExamProgression>();

        public Dictionary<string, LearningProgression> Katakan = new Dictionary<string, LearningProgression>()
        {
            {"", LearningProgression.NotLearned}
        };
        public Dictionary<string, LearningProgression> Kanji = new Dictionary<string, LearningProgression>()
        {
            {"", LearningProgression.NotLearned}
        };
    }

    public class CurrentSettings
    {
        public Dictionary<string, LearningProgression> Hiragana = new Dictionary<string, LearningProgression>();
        public Dictionary<string, ExamProgression> HiraganaExams = new Dictionary<string, ExamProgression>();

        public Dictionary<string, LearningProgression> Katakan = new Dictionary<string, LearningProgression>();
        public Dictionary<string, LearningProgression> Kanji = new Dictionary<string, LearningProgression>();
    }

    public static class Settings
    {
        static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        static DefaultSettings Default = new DefaultSettings();
        public static CurrentSettings Current = new CurrentSettings();

        #region Setting Constants
        static readonly string SettingsDefault = JsonConvert.SerializeObject(Default);
        #endregion

        public static string GeneralSettings
        {
            get { return AppSettings.GetValueOrDefault(nameof(GeneralSettings), SettingsDefault); }
            set { AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value); }
        }

        public static void SaveSettings()
        {
            GeneralSettings = JsonConvert.SerializeObject(Current);
        }

        public static void LoadSettings()
        {
            Current = JsonConvert.DeserializeObject<CurrentSettings>(GeneralSettings);
        }

        public static LearningProgression GetHiraganaProgression(string id)
        {
            try
            {
                if (Current.Hiragana.ContainsKey(id))
                {
                    return Current.Hiragana[id];
                }
                else
                {
                    Current.Hiragana.Add(id, LearningProgression.Locked);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LearningProgression.Locked;
        }

        public static void SetHiraganaProgression(string id, LearningProgression progression)
        {
            try
            {
                if (Current.Hiragana.ContainsKey(id))
                    Current.Hiragana[id] = progression;
                else
                    Current.Hiragana.Add(id, progression);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static ExamProgression GetHiraganaExamProgression(string id)
        {
            try
            {
                if (Current.HiraganaExams.ContainsKey(id))
                {
                    return Current.HiraganaExams[id];
                }
                else
                {
                    Current.HiraganaExams.Add(id, ExamProgression.Locked);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ExamProgression.Locked;
        }

        public static void SetHiraganaExamProgression(string id, ExamProgression progression)
        {
            try
            {
                if (Current.HiraganaExams.ContainsKey(id))
                    Current.HiraganaExams[id] = progression;
                else
                    Current.HiraganaExams.Add(id, progression);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //
        public static string ProgressionToState(LearningProgression progression)
        {
            switch(progression)
            {
                case LearningProgression.Learned: return "Learned";
                case LearningProgression.NotLearned: return "Not yet learned";
                case LearningProgression.MustReview: return "Must review";
            }
            return "Locked";
        }

        public static Color ProgressionToColor(LearningProgression progression)
        {
            switch (progression)
            {
                case LearningProgression.Learned: return Color.FromHex("#41a54d");
                case LearningProgression.NotLearned: return Color.FromHex("#D53F3E");
                case LearningProgression.MustReview: return Color.FromHex("#D9AD41");
            }
            return Color.FromHex("#AAA");
        }

        public static string ProgressionExamToState(ExamProgression progression)
        {
            switch (progression)
            {
                case ExamProgression.Passed: return "Passed";
                case ExamProgression.Failed: return "Failed";
                case ExamProgression.MustRepass: return "Must retake";
                case ExamProgression.NotYetDone: return "Not yet taken";
            }
            return "Locked";
        }

        public static Color ProgressionExamToColor(ExamProgression progression)
        {
            switch (progression)
            {
                case ExamProgression.Passed: return Color.FromHex("#41a54d");
                case ExamProgression.Failed: return Color.FromHex("#D53F3E");
                case ExamProgression.MustRepass: return Color.FromHex("#D9AD41");
                case ExamProgression.NotYetDone: return Color.FromHex("#FFFFFF");
            }
            return Color.FromHex("#AAA");
        }

    }
}
