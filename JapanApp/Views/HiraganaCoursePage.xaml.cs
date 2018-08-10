using Xamarin.Forms;
using System.Windows.Input;

namespace JapanApp
{
    public partial class HiraganaCoursePage : ContentPage
    {
        HiraganaCourseViewModel viewModel;
        public ICommand NextCommand { protected set; get; }

        public HiraganaCoursePage()
        {
            InitializeComponent();
            MockDataStore DataStore = DependencyService.Get<MockDataStore>() ?? new MockDataStore();
            var item = DataStore.GetHiraganaCourseAsync("Hiragana_Course_1").Result;
            viewModel = new HiraganaCourseViewModel(item);
            viewModel.Page = this;
            BindingContext = viewModel;
        }

        public HiraganaCoursePage(HiraganaCourseViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Page = this;
            BindingContext = this.viewModel = viewModel;
            JapaneseCharacter.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => viewModel.PlaySound())
            });
        }

        public void Close()
        {
            Navigation.PopAsync();

        }

    }
}
