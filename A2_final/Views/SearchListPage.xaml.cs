using A2_final.Data;
using A2_final.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace A2_final.Views
{
    public partial class SearchListPage : ContentPage
    {
        private readonly ObservableCollection<Food> AllFoods = new ObservableCollection<Food>();
        private readonly NetworkingManager NetworkManager = NetworkingManager.Instance;

        public SearchListPage(string searchValue)
        {
            InitializeComponent();

            Title = searchValue.ToUpperInvariant();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SearchResultsListView.ItemsSource = AllFoods;
            FetchData();
        }

        private async void ClickedFoodItem(object sender, SelectedItemChangedEventArgs e)
        {
            Food currentSelectedItem = e.SelectedItem as Food;
            await Navigation.PushAsync(new SearchDetailsPage(currentSelectedItem));
        }

        private async void FetchData()
        {
            await Task.Run(async () =>
            {
                List<Food> foods = await NetworkManager.GetFoodList(Title);
                foods.ForEach(AllFoods.Add);
            });

            progressBarLayout.IsVisible = false;
            resultsLayout.IsVisible = true;
        }
    }
}
