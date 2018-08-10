using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JapanApp
{
    public partial class HiraganaTheory1 : ContentPage
    {
        public HiraganaTheory1()
        {
            InitializeComponent();
            Title = "Theory";
            ButtonIntro.Clicked += (sender, e) => {
                ShowIntroTab();
            };
            ButtonTenTen.Clicked += (sender, e) => {
                ShowTenTenTab();
            };
            ButtonMaru.Clicked += (sender, e) => {
                ShowMaruTab();
            };
            ButtonCombi.Clicked += (sender, e) => {
                ShowCombiTab();
            };
            ShowIntroTab();//Just in case :)
        }

        void ShowIntroTab()
        {
            TabTenTen.IsVisible = false;
            ButtonTenTen.BackgroundColor = Color.FromHex("#262c36");
            TabMaru.IsVisible = false;
            ButtonMaru.BackgroundColor = Color.FromHex("#262c36");
            TabCombi.IsVisible = false;
            ButtonCombi.BackgroundColor = Color.FromHex("#262c36");
            //
            TabIntro.IsVisible = true;
            ButtonIntro.BackgroundColor = Color.FromHex("#0594d6");
        }

        void ShowTenTenTab()
        {
            TabIntro.IsVisible = false;
            ButtonIntro.BackgroundColor = Color.FromHex("#262c36");
            TabMaru.IsVisible = false;
            ButtonMaru.BackgroundColor = Color.FromHex("#262c36");
            TabCombi.IsVisible = false;
            ButtonCombi.BackgroundColor = Color.FromHex("#262c36");
            //
            TabTenTen.IsVisible = true;
            ButtonTenTen.BackgroundColor = Color.FromHex("#0594d6");
        }

        void ShowMaruTab()
        {
            TabIntro.IsVisible = false;
            ButtonIntro.BackgroundColor = Color.FromHex("#262c36");
            TabTenTen.IsVisible = false;
            ButtonTenTen.BackgroundColor = Color.FromHex("#262c36");
            TabCombi.IsVisible = false;
            ButtonCombi.BackgroundColor = Color.FromHex("#262c36");
            //
            TabMaru.IsVisible = true;
            ButtonMaru.BackgroundColor = Color.FromHex("#0594d6");
        }

        void ShowCombiTab()
        {
            TabIntro.IsVisible = false;
            ButtonIntro.BackgroundColor = Color.FromHex("#262c36");
            TabTenTen.IsVisible = false;
            ButtonTenTen.BackgroundColor = Color.FromHex("#262c36");
            TabMaru.IsVisible = false;
            ButtonMaru.BackgroundColor = Color.FromHex("#262c36");
            //
            TabCombi.IsVisible = true;
            ButtonCombi.BackgroundColor = Color.FromHex("#0594d6");
        }

    }
}
