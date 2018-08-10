using System;
using Xamarin.Forms;

namespace JapanApp
{
    public partial class KatakanListPage : ContentPage
    {
        KatakanViewModel viewModel;

        public KatakanListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new KatakanViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
