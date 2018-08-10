using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using AudioManager;
using JapanApp.Services;

namespace JapanApp
{
    public class HiraganaExamViewModel : BaseViewModel
    {
        public HiraganaExamPage Page = null;
        public Item Item { get; set; }
        List<HiraganaExamsDataItem> Items = new List<HiraganaExamsDataItem>();
        List<HiraganaExamsDataItem> Data = new List<HiraganaExamsDataItem>();
        HiraganaExamsDataItem CurrentItem = null;
        string NextStep = "";
        int DataCount = 0;
        int Count = 0;

        List<HiraganaExamsDataItem> Errors = new List<HiraganaExamsDataItem>();

        public ICommand ValidateCommand { get; }
        public ICommand PlaySound1Command { get; }
        public ICommand PlaySound2Command { get; }
        public ICommand PlaySound3Command { get; }

        public ICommand Option1Command { get; }
        public ICommand Option2Command { get; }
        public ICommand Option3Command { get; }

        public ICommand PlaySampleCommand { get; }

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

        string japaneseCharacter = "";
        public string JapaneseCharacterText
        {
            get
            {
                return japaneseCharacter;
            }
            private set
            {
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

        bool showCorrectMessage = false;
        public bool ShowCorrectMessage
        {
            get
            {
                return showCorrectMessage;
            }
            private set
            {
                showCorrectMessage = value;
                OnPropertyChanged("ShowCorrectMessage");
            }
        }

        bool showIncorrectMessage = false;
        public bool ShowIncorrectMessage
        {
            get
            {
                return showIncorrectMessage;
            }
            private set
            {
                showIncorrectMessage = value;
                OnPropertyChanged("ShowIncorrectMessage");
            }
        }

        bool showValidateButton = true;
        public bool ShowValidateButton
        {
            get
            {
                return showValidateButton;
            }
            private set
            {
                showValidateButton = value;
                OnPropertyChanged("ShowValidateButton");
            }
        }

        bool showCharacterToSound = false;
        public bool ShowCharacterToSound
        {
            get
            {
                return showCharacterToSound;
            }
            private set
            {
                showCharacterToSound = value;
                OnPropertyChanged("ShowCharacterToSound");
            }
        }

        bool showEnglishToJapan = false;
        public bool ShowEnglishToJapan
        {
            get
            {
                return showEnglishToJapan;
            }
            private set
            {
                showEnglishToJapan = value;
                OnPropertyChanged("ShowEnglishToJapan");
            }
        }

        bool showJapanToEnglish = false;
        public bool ShowJapanToEnglish
        {
            get
            {
                return showJapanToEnglish;
            }
            private set
            {
                showJapanToEnglish = value;
                OnPropertyChanged("ShowJapanToEnglish");
            }
        }

        bool showShowSoundToCharacter = false;
        public bool ShowSoundToCharacter
        {
            get
            {
                return showShowSoundToCharacter;
            }
            private set
            {
                showShowSoundToCharacter = value;
                OnPropertyChanged("ShowSoundToCharacter");
            }
        }

        bool showResults = false;
        public bool ShowResults
        {
            get
            {
                return showResults;
            }
            private set
            {
                showResults = value;
                OnPropertyChanged("ShowResults");
            }
        }

        string sample1BackColor = "#262c36";
        public string ButtonOption1Color
        {
            get
            {
                return sample1BackColor;
            }
            private set
            {
                sample1BackColor = value;
                OnPropertyChanged("ButtonOption1Color");
            }
        }

        string sample2BackColor = "#262c36";
        public string ButtonOption2Color
        {
            get
            {
                return sample2BackColor;
            }
            private set
            {
                sample2BackColor = value;
                OnPropertyChanged("ButtonOption2Color");
            }
        }

        string sample3BackColor = "#262c36";
        public string ButtonOption3Color
        {
            get
            {
                return sample3BackColor;
            }
            private set
            {
                sample3BackColor = value;
                OnPropertyChanged("ButtonOption3Color");
            }
        }

        string option1Text = "";
        public string Option1Text
        {
            get
            {
                return option1Text;
            }
            private set
            {
                option1Text = value;
                OnPropertyChanged("Option1Text");
            }
        }

        string option2Text = "";
        public string Option2Text
        {
            get
            {
                return option2Text;
            }
            private set
            {
                option2Text = value;
                OnPropertyChanged("Option2Text");
            }
        }

        string option3Text = "";
        public string Option3Text
        {
            get
            {
                return option3Text;
            }
            private set
            {
                option3Text = value;
                OnPropertyChanged("Option3Text");
            }
        }

        string totalPercent = "0%";
        public string TotalPercent
        {
            get
            {
                return totalPercent;
            }
            private set
            {
                totalPercent = value;
                OnPropertyChanged("TotalPercent");
            }
        }

        string identifySymbolPercent = "0%";
        public string IdentifySymbolPercent
        {
            get
            {
                return identifySymbolPercent;
            }
            private set
            {
                identifySymbolPercent = value;
                OnPropertyChanged("IdentifySymbolPercent");
            }
        }

        string findSymbolPercent = "0%";
        public string FindSymbolPercent
        {
            get
            {
                return findSymbolPercent;
            }
            private set
            {
                findSymbolPercent = value;
                OnPropertyChanged("FindSymbolPercent");
            }
        }

        string associateSymbolPercent = "0%";
        public string AssociateSymbolPercent
        {
            get
            {
                return associateSymbolPercent;
            }
            private set
            {
                associateSymbolPercent = value;
                OnPropertyChanged("AssociateSymbolPercent");
            }
        }

        string identifySamplePercent = "0%";
        public string IdentifySamplePercent
        {
            get
            {
                return identifySamplePercent;
            }
            private set
            {
                identifySamplePercent = value;
                OnPropertyChanged("IdentifySamplePercent");
            }
        }

        string errorsLeft = "";
        public string ErrorsLeft
        {
            get
            {
                return errorsLeft;
            }
            private set
            {
                errorsLeft = value;
                OnPropertyChanged("ErrorsLeft");
            }
        }

        string errorsRight = "";
        public string ErrorsRight
        {
            get
            {
                return errorsRight;
            }
            private set
            {
                errorsRight = value;
                OnPropertyChanged("ErrorsRight");
            }
        }

        HiraganaExamsDataItem Option1Item = null;
        HiraganaExamsDataItem Option2Item = null;
        HiraganaExamsDataItem Option3Item = null;
        HiraganaExamsDataItem SelectedOptionItem = null;

        public HiraganaExamViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            ValidateCommand = new Command(async () => await Validate());
            PlaySound1Command = new Command(() => PlaySound1());
            PlaySound2Command = new Command(() => PlaySound2());
            PlaySound3Command = new Command(() => PlaySound3());

            Option1Command = new Command(() => Option1Clicked());
            Option2Command = new Command(() => Option2Clicked());
            Option3Command = new Command(() => Option3Clicked());

            PlaySampleCommand = new Command(() => PlaySample());

            var temp = HiraganaExamsData.Exams[item.Id];
            if(temp != null)
            {
                NextStep = temp.Next;
                Items = temp.Items;
                foreach(var data in Items)
                {
                    Data.Add(new HiraganaExamsDataItem(data) { Type = HiraganaExamType.CharacterToSound });
                    Data.Add(new HiraganaExamsDataItem(data) { Type = HiraganaExamType.EnglishToJapan });
                    Data.Add(new HiraganaExamsDataItem(data) { Type = HiraganaExamType.JapanToEnglish });
                    Data.Add(new HiraganaExamsDataItem(data) { Type = HiraganaExamType.SoundToCharacter });
                }
                if(Data.Count > 0)
                {
                    Data.Shuffle();
                    DataCount = Data.Count;
                    ShowNextItem();
                }
            }
        }

        void ShowNextItem()
        {
            //TODO - Prepare to show it!
            CurrentItem = Data[0];
            switch (CurrentItem.Type)
            {
                case HiraganaExamType.CharacterToSound:
                {
                    JapaneseCharacterText = CurrentItem.JapanCharacter;
                    ShowEnglishToJapan = false;
                    ShowJapanToEnglish = false;
                    ShowSoundToCharacter = false;
                    ShowCharacterToSound = true;
                    int rightSample = new Random().Next(1, 10000);//Just to generate more chances.
                    if (rightSample < 3333) rightSample = 1;
                    else if (rightSample < 6666) rightSample = 2;
                    else rightSample = 3;
                    switch(rightSample)
                    {
                        case 1:
                        {
                            Option1Item = CurrentItem;
                            Option2Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option3Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option2Item.JapanCharacter);
                        }
                        break;
                        case 2:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option2Item = CurrentItem;
                            Option3Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option1Item.JapanCharacter);
                        }
                        break;
                        case 3:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option2Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option1Item.JapanCharacter);
                            Option3Item = CurrentItem;
                        }
                        break;
                    }
                    SelectedOptionItem = null;
                    ButtonOption1Color = "#262c36";
                    ButtonOption2Color = "#262c36";
                    ButtonOption3Color = "#262c36";
                }
                break;
                case HiraganaExamType.EnglishToJapan:
                {
                    EnglishCharacterText = CurrentItem.EnglishCharacter;
                    ShowCharacterToSound = false;
                    ShowJapanToEnglish = false;
                    ShowSoundToCharacter = false;
                    ShowEnglishToJapan = true;
                    int rightSample = new Random().Next(1, 10000);//Just to generate more chances.
                    if (rightSample < 3333) rightSample = 1;
                    else if (rightSample < 6666) rightSample = 2;
                    else rightSample = 3;
                    switch(rightSample)
                    {
                        case 1:
                        {
                            Option1Item = CurrentItem;
                            Option2Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option3Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option2Item.JapanCharacter);
                        }
                        break;
                        case 2:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option2Item = CurrentItem;
                            Option3Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option1Item.JapanCharacter);
                        }
                        break;
                        case 3:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter);
                            Option2Item = Items.RandomOrDefault(x => x.JapanCharacter != CurrentItem.JapanCharacter && x.JapanCharacter != Option1Item.JapanCharacter);
                            Option3Item = CurrentItem;
                        }
                        break;
                    }
                    Option1Text = Option1Item.JapanCharacter;
                    Option2Text = Option2Item.JapanCharacter;
                    Option3Text = Option3Item.JapanCharacter;
                    SelectedOptionItem = null;
                    ButtonOption1Color = "#262c36";
                    ButtonOption2Color = "#262c36";
                    ButtonOption3Color = "#262c36";
                }
                break;
                case HiraganaExamType.JapanToEnglish:
                {
                    JapaneseCharacterText = CurrentItem.JapanCharacter;
                    ShowCharacterToSound = false;
                    ShowEnglishToJapan = false;
                    ShowSoundToCharacter = false;
                    ShowJapanToEnglish = true;
                    int rightSample = new Random().Next(1, 10000);//Just to generate more chances.
                    if (rightSample < 3333) rightSample = 1;
                    else if (rightSample < 6666) rightSample = 2;
                    else rightSample = 3;
                    switch(rightSample)
                    {
                        case 1:
                        {
                            Option1Item = CurrentItem;
                            Option2Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option3Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option2Item.EnglishCharacter);
                        }
                        break;
                        case 2:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option2Item = CurrentItem;
                            Option3Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option1Item.EnglishCharacter);
                        }
                        break;
                        case 3:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option2Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option1Item.EnglishCharacter);
                            Option3Item = CurrentItem;
                        }
                        break;
                    }
                    Option1Text = Option1Item.EnglishCharacter;
                    Option2Text = Option2Item.EnglishCharacter;
                    Option3Text = Option3Item.EnglishCharacter;
                    SelectedOptionItem = null;
                    ButtonOption1Color = "#262c36";
                    ButtonOption2Color = "#262c36";
                    ButtonOption3Color = "#262c36";
                }
                break;
                case HiraganaExamType.SoundToCharacter:
                {
                    ShowCharacterToSound = false;
                    ShowEnglishToJapan = false;
                    ShowJapanToEnglish = false;
                    ShowSoundToCharacter = true;
                    int rightSample = new Random().Next(1, 10000);//Just to generate more chances.
                    if (rightSample < 3333) rightSample = 1;
                    else if (rightSample < 6666) rightSample = 2;
                    else rightSample = 3;
                    switch(rightSample)
                    {
                        case 1:
                        {
                            Option1Item = CurrentItem;
                            Option2Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option3Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option2Item.EnglishCharacter);
                        }
                        break;
                        case 2:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option2Item = CurrentItem;
                            Option3Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option1Item.EnglishCharacter);
                        }
                        break;
                        case 3:
                        {
                            Option1Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter);
                            Option2Item = Items.RandomOrDefault(x => x.EnglishCharacter != CurrentItem.EnglishCharacter && x.EnglishCharacter != Option1Item.EnglishCharacter);
                            Option3Item = CurrentItem;
                        }
                        break;
                    }
                    Option1Text = Option1Item.EnglishCharacter;
                    Option2Text = Option2Item.EnglishCharacter;
                    Option3Text = Option3Item.EnglishCharacter;
                    SelectedOptionItem = null;
                    ButtonOption1Color = "#262c36";
                    ButtonOption2Color = "#262c36";
                    ButtonOption3Color = "#262c36";
                    PlaySound(CurrentItem.SoundName);
                }
                break;
            }
            Data.Remove(CurrentItem);
        }

        void PlaySound1()
        {
            ButtonOption1Color = "#0594d6";
            ButtonOption2Color = "#262c36";
            ButtonOption3Color = "#262c36";
            SelectedOptionItem = Option1Item;
            PlaySound(SelectedOptionItem.SoundName);
        }

        void PlaySound2()
        {
            ButtonOption1Color = "#262c36";
            ButtonOption2Color = "#0594d6";
            ButtonOption3Color = "#262c36";
            SelectedOptionItem = Option2Item;
            PlaySound(SelectedOptionItem.SoundName);
        }

        void PlaySound3()
        {
            ButtonOption1Color = "#262c36";
            ButtonOption2Color = "#262c36";
            ButtonOption3Color = "#0594d6";
            SelectedOptionItem = Option3Item;
            PlaySound(SelectedOptionItem.SoundName);
        }

        void Option1Clicked()
        {
            ButtonOption1Color = "#0594d6";
            ButtonOption2Color = "#262c36";
            ButtonOption3Color = "#262c36";
            SelectedOptionItem = Option1Item;
        }

        void Option2Clicked()
        {
            ButtonOption1Color = "#262c36";
            ButtonOption2Color = "#0594d6";
            ButtonOption3Color = "#262c36";
            SelectedOptionItem = Option2Item;
        }

        void Option3Clicked()
        {
            ButtonOption1Color = "#262c36";
            ButtonOption2Color = "#262c36";
            ButtonOption3Color = "#0594d6";
            SelectedOptionItem = Option3Item;
        }

        void PlaySample()
        {
            PlaySound(CurrentItem.SoundName);
        }

        public void PlaySound(string soundName)
        {
            if (!string.IsNullOrEmpty(soundName))
            {
                Audio.Manager.MusicOn = true;
                Audio.Manager.BackgroundMusicVolume = 1f;
                Audio.Manager.StopBackgroundMusic();
                Audio.Manager.PlayBackgroundMusic(soundName);
            }
        }

        int TotalErrorCount = 0;
        int CharacterToSoundErrorCount = 0;
        int EnglishToJapanErrorCount = 0;
        int JapanToEnglishErrorCount = 0;
        int SoundToCharacterErrorCount = 0;

        async Task Validate()
        {
            if (IsBusy) return;
            IsBusy = true;
            Count++;
            ShowValidateButton = false;

            try
            {
                switch (CurrentItem.Type)
                {
                    case HiraganaExamType.CharacterToSound:
                    {
                        if(SelectedOptionItem == null)
                        {
                            Count--;
                            ShowValidateButton = true;
                            IsBusy = false;
                            return;
                        }else{
                            if(SelectedOptionItem.JapanCharacter == CurrentItem.JapanCharacter)
                            {
                                ShowCorrectMessage = true;
                                PlaySound(CurrentItem.SoundName);
                            }else{
                                ShowIncorrectMessage = true;
                                Audio.Manager.StopBackgroundMusic();
                                Errors.Add(SelectedOptionItem);
                                Errors.Add(CurrentItem);
                                TotalErrorCount++;
                                CharacterToSoundErrorCount++;

                            }
                        }
                    }
                    break;
                    case HiraganaExamType.EnglishToJapan:
                    {
                        if(SelectedOptionItem == null)
                        {
                            Count--;
                            ShowValidateButton = true;
                            IsBusy = false;
                            return;
                        }else{
                            if (SelectedOptionItem.JapanCharacter == CurrentItem.JapanCharacter)
                            {
                                ShowCorrectMessage = true;
                                PlaySound(CurrentItem.SoundName);
                            }else{
                                ShowIncorrectMessage = true;
                                Audio.Manager.StopBackgroundMusic();
                                Errors.Add(SelectedOptionItem);
                                Errors.Add(CurrentItem);
                                TotalErrorCount++;
                                EnglishToJapanErrorCount++;
                            }
                        }
                    }
                    break;
                    case HiraganaExamType.JapanToEnglish:
                    {
                        if(SelectedOptionItem == null)
                        {
                            Count--;
                            ShowValidateButton = true;
                            IsBusy = false;
                            return;
                        }else{
                            if (SelectedOptionItem.EnglishCharacter == CurrentItem.EnglishCharacter)
                            {
                                ShowCorrectMessage = true;
                                PlaySound(CurrentItem.SoundName);
                            }else{
                                ShowIncorrectMessage = true;
                                Audio.Manager.StopBackgroundMusic();
                                Errors.Add(SelectedOptionItem);
                                Errors.Add(CurrentItem);
                                TotalErrorCount++;
                                JapanToEnglishErrorCount++;
                            }
                        }
                    }
                    break;
                    case HiraganaExamType.SoundToCharacter:
                    {
                        if (SelectedOptionItem == null)
                        {
                            Count--;
                            ShowValidateButton = true;
                            IsBusy = false;
                            return;
                        }
                        else
                        {
                            if (SelectedOptionItem.EnglishCharacter == CurrentItem.EnglishCharacter)
                            {
                                ShowCorrectMessage = true;
                                PlaySound(CurrentItem.SoundName);
                            }
                            else
                            {
                                ShowIncorrectMessage = true;
                                Audio.Manager.StopBackgroundMusic();
                                Errors.Add(SelectedOptionItem);
                                Errors.Add(CurrentItem);
                                TotalErrorCount++;
                                SoundToCharacterErrorCount++;
                            }
                        }
                    }
                    break;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            await Task.Delay(1500);
            Audio.Manager.StopBackgroundMusic();

            ShowCorrectMessage = false;
            ShowIncorrectMessage = false;
            ShowValidateButton = true;

            float currentProgress = ((float)Count / (float)DataCount) * 100f;
            if (currentProgress > 100) currentProgress = 100;
            Progress = currentProgress / 100;
            ProgressText = ((int)currentProgress) + "%";

            if(Count >= DataCount)
            {
                if(Errors.Count() == 0)
                {
                    Settings.SetHiraganaExamProgression(Item.Id, ExamProgression.Passed);
                    if(Settings.GetHiraganaProgression(NextStep) == LearningProgression.Locked)
                        Settings.SetHiraganaProgression(NextStep, LearningProgression.NotLearned);
                }else{
                    Settings.SetHiraganaExamProgression(Item.Id, ExamProgression.Failed);
                    ErrorsLeft = "Errors:" + Environment.NewLine;
                    ErrorsRight = Environment.NewLine;

                    List<string> erroralreadydone = new List<string>();

                    foreach (var errorItem in Errors)
                    {
                        if(!erroralreadydone.Contains(errorItem.JapanCharacter))
                        {
                            erroralreadydone.Add(errorItem.JapanCharacter);
                            ErrorsLeft += errorItem.JapanCharacter + " (" + errorItem.EnglishCharacter + ")" + Environment.NewLine;
                            ErrorsRight += Errors.Count(x => x.JapanCharacter == errorItem.JapanCharacter) + "x" + Environment.NewLine;
                        }
                        try
                        {
                            var course = HiraganaCoursesData.Courses.FirstOrDefault(x => x.Value.Items.Any(y => y.JapanCharacter == errorItem.JapanCharacter));
                            if (!string.IsNullOrEmpty(course.Key))
                            {
                                Settings.SetHiraganaProgression(course.Key, LearningProgression.MustReview);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    float itemsCount = (float) Items.Count();
                    TotalPercent = ((int)(100f - (((float)TotalErrorCount / ((float)DataCount)) * 100f))) + "%";
                    IdentifySymbolPercent = ((int)(100f - (((float)CharacterToSoundErrorCount / itemsCount) * 100f))) + "%";
                    FindSymbolPercent = ((int)(100f - (((float)JapanToEnglishErrorCount / itemsCount) * 100f))) + "%";
                    AssociateSymbolPercent = ((int)(100f - (((float)EnglishToJapanErrorCount / itemsCount) * 100f))) + "%";
                    IdentifySamplePercent = ((int)(100f - (((float)SoundToCharacterErrorCount / itemsCount) * 100f))) + "%";
                }
                Settings.SaveSettings();
                //Page?.Close();
                HiraganaListPage.Instance.RefreshList();
                ShowCorrectMessage = false;
                ShowIncorrectMessage = false;
                ShowEnglishToJapan = false;
                ShowJapanToEnglish = false;
                ShowCharacterToSound = false;
                ShowSoundToCharacter = false;
                ShowValidateButton = false;
                ShowResults = true;
            }else{
                ShowNextItem();
            }

            IsBusy = false;
        }

    }
}
