using Xamarin.Forms;

namespace A2_final.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ClickedSearchButton(object sender, System.EventArgs e)
        {
            string searchFor = SearchTextbox.Text;

            await Navigation.PushAsync(new SearchListPage(searchFor));
        }

        private void UserInputedChanged(object sender, TextChangedEventArgs e)
        {
            Entry searchEntry = sender as Entry;
            SearchButton.IsEnabled = searchEntry.Text != string.Empty;

        }

        private async void FavouriteButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FavouritePage());
        }
    }
}
