using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace JapanApp
{
    public partial class HiraganaListPage : ContentPage
    {
        HiraganaListViewModel viewModel;
        public static HiraganaListPage Instance;

        public HiraganaListPage()
        {
            InitializeComponent();
            Instance = this;

            BindingContext = viewModel = new HiraganaListViewModel();
            Progress.ProgressTo(1, 2000, Easing.BounceIn);
            viewModel.LoadItemsCommand.Execute(null);
            Task.Factory.StartNew(async () =>
            {
                while (IsBusy)
                    await Task.Delay(1);
                ItemsListView.HeightRequest = (85 * viewModel.Items.Count) + 9;
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            if (item.State == "Locked")
            {
                ItemsListView.SelectedItem = null;
                return;
            }

            if(item.Id == "Hiragana_Theory_1")
            {
                await Navigation.PushAsync(new HiraganaTheory1());
            }else if(item.Id.StartsWith("Hiragana_Course_"))
            {
                //Course
                await Navigation.PushAsync(new HiraganaCoursePage(new HiraganaCourseViewModel(item)));
            }else{
                //Exam
                await Navigation.PushAsync(new HiraganaExamPage(new HiraganaExamViewModel(item)));
            }
            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        public void CloseCurrentView()
        {
            Navigation.PopModalAsync();
        }

        public void RefreshList()
        {
            viewModel.DataStore.RefreshHiraganaList();
            ItemsListView.RefreshCommand.Execute(null);
        }
    }
}
