using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JapanApp
{
    public partial class HiraganaExamPage : ContentPage
    {
        HiraganaExamViewModel viewModel;

        public HiraganaExamPage()
        {
            InitializeComponent();
            MockDataStore DataStore = DependencyService.Get<MockDataStore>() ?? new MockDataStore();
            var item = DataStore.GetHiraganaCourseAsync("Hiragana_Exam_1").Result;
            viewModel = new HiraganaExamViewModel(item);
            viewModel.Page = this;
            BindingContext = viewModel;
        }

        public HiraganaExamPage(HiraganaExamViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Page = this;
            BindingContext = this.viewModel = viewModel;
            /*JapaneseCharacter.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => viewModel.PlaySound())
            });*/
        }

        public void Close()
        {
            Navigation.PopAsync();

        }
    }
}
