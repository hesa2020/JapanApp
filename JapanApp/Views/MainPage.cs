using Xamarin.Forms;

namespace JapanApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page hiraganaListPage, katakanListPage, kanjiListPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                {
                    hiraganaListPage = new NavigationPage(new HiraganaListPage())
                    {
                        Title = "1. Hiragana"
                    };
                    katakanListPage = new NavigationPage(new KatakanListPage())
                    {
                        Title = "2. Katakan"
                    };
                    kanjiListPage = new NavigationPage(new KanjiListPage())
                    {
                        Title = "3. Kanji"
                    };
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    hiraganaListPage.Icon = "tab_feed.png";
                    katakanListPage.Icon = "tab_feed.png";
                    kanjiListPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                }
                break;
                default:
                {
                    hiraganaListPage = new HiraganaListPage()
                    {
                        Title = "1. Hiragana"
                    };
                    katakanListPage = new KatakanListPage()
                    {
                        Title = "2. Katakan"
                    };
                    kanjiListPage = new KanjiListPage()
                    {
                        Title = "3. Kanji"
                    };
                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                }
                break;
            }

            Children.Add(hiraganaListPage);
            Children.Add(katakanListPage);
            Children.Add(kanjiListPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
