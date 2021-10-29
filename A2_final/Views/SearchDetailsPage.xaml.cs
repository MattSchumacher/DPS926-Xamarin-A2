using A2_final.Models;
using A2_final.Persistance;
using Xamarin.Forms;
using A2_final.Data;
using System;
using System.Threading.Tasks;

namespace A2_final.Views
{
    public partial class SearchDetailsPage : ContentPage
    {
        //DBManager dbManager = new DBManager();

        private readonly NetworkingManager NetworkManager = NetworkingManager.Instance;
        private readonly DatabaseManager DbManager = DatabaseManager.Instance;

        private readonly Food SelectedFood;
        private FoodDetailedData SelectedFoodDetails;

        public SearchDetailsPage(Food selectedFood, bool isSaved = false)
        {
            InitializeComponent();

            Title = selectedFood.food_name;
            SelectedFood = selectedFood;

            if (isSaved)
            {
                favouriteSection.IsVisible = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FetchData();
        }

        private async void FetchData()
        {
            await Task.Run(async () =>
            {
                FoodDetailedData food = await NetworkManager.GetFoodDetails(SelectedFood.nix_item_id);
                SelectedFoodDetails = food;
            });

            foodDetailLayout.BindingContext = SelectedFoodDetails;
        }

        private void AddToFavourites(object sender, EventArgs e)
        {
            DbManager.InsertFood(SelectedFood);
            _ = Navigation.PopAsync();
        }
    }
}
