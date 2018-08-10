using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using JapanApp.Services;
using AudioManager;

namespace JapanApp
{
    public class HiraganaCourseViewModel : BaseViewModel
    {
        public HiraganaCoursePage Page;
        public Item Item { get; set; }
        List<HiraganaCourseDataItem> Data = new List<HiraganaCourseDataItem>();
        HiraganaCourseDataItem CurrentItem = null;
        string NextStep = "";
        int DataCount = 0;
        int LearnedCount = 0;

        string japaneseCharacter = "";
        public string JapaneseCharacterText
        {
            get
            {
                return japaneseCharacter;
            }
            private set {
                japaneseCharacter = value;
                OnPropertyChanged("JapaneseCharacterText");
            }
        }

        string englishCharacter = "";
        public string EnglishCharacterText
        {
            get
            {
                return englishCharacter;
            }
            private set
            {
                englishCharacter = value;
                OnPropertyChanged("EnglishCharacterText");
            }
        }

        float progress = 0;
        public float Progress
        {
            get
            {
                return progress;
            }
            private set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }

        string progressText = "0%";
        public string ProgressText
        {
            get
            {
                return progressText;
            }
            private set
            {
                progressText = value;
                OnPropertyChanged("ProgressText");
            }
        }

        public HiraganaCourseViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;

            NextCommand = new Command(() => Next());

            var temp = HiraganaCoursesData.Courses[Item.Id];
            if (temp != null)
            {
                NextStep = temp.Next;
                foreach (var data in temp.Items)
                {
                    Data.Add(data);
                }
            }
            if (Data.Count > 0)
            {
                DataCount = Data.Count;
                int index = new Random().Next(0, Data.Count - 1);
                CurrentItem = Data[index];
                JapaneseCharacterText = CurrentItem.JapanCharacter;
                EnglishCharacterText = CurrentItem.EnglishCharacter;
                Data.Remove(CurrentItem);
                PlaySound();
            }
        }

        public void PlaySound()
        {
            if(!string.IsNullOrEmpty(CurrentItem.SoundName))
            {
                Audio.Manager.MusicOn = true;
                Audio.Manager.BackgroundMusicVolume = 1f;
                Audio.Manager.StopBackgroundMusic();
                Audio.Manager.PlayBackgroundMusic(CurrentItem.SoundName);
            }
        }

        void Next()
        {
            if (IsBusy) return;
            IsBusy = true;
            LearnedCount++;
            if (LearnedCount > DataCount) LearnedCount = DataCount;

            float currentProgress = ((float)LearnedCount / (float)DataCount) * 100f;
            if (currentProgress > 100) currentProgress = 100;
            Progress = currentProgress / 100;
            ProgressText = ((int)currentProgress) + "%";

            //TODO - Set has learned: CurrentItem
            if (Data.Count > 0)
            {
                int index = new Random().Next(0, Data.Count - 1);
                CurrentItem = Data[index];
                JapaneseCharacterText = CurrentItem.JapanCharacter;
                EnglishCharacterText = CurrentItem.EnglishCharacter;
                Data.Remove(CurrentItem);
                PlaySound();
            }
            else
            {
                Settings.SetHiraganaProgression(Item.Id, LearningProgression.Learned);
                if(!string.IsNullOrEmpty(NextStep))
                {
                    if(NextStep.StartsWith("Hiragana_Course_"))
                    {
                        //Course
                        if(Settings.GetHiraganaProgression(NextStep) == LearningProgression.Locked)
                            Settings.SetHiraganaProgression(NextStep, LearningProgression.NotLearned);
                    }else{
                        //Exam
                        if (Settings.GetHiraganaExamProgression(NextStep) == ExamProgression.Locked)
                            Settings.SetHiraganaExamProgression(NextStep, ExamProgression.NotYetDone);
                    }
                }
                Settings.SaveSettings();
                Audio.Manager.StopBackgroundMusic();
                HiraganaListPage.Instance.RefreshList();
                Page?.Close();
            }
            IsBusy = false;
        }

        public ICommand NextCommand { get; }
    }
}
