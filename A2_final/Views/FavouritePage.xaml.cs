using A2_final.Models;
using A2_final.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A2_final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritePage : ContentPage
    {
        private readonly ObservableCollection<Food> AllFoods = new ObservableCollection<Food>();
        private readonly DatabaseManager DbManager = DatabaseManager.Instance;

        public FavouritePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SavedResultsListView.ItemsSource = AllFoods;
            LoadDataFromDatabase();
        }

        private async void ClickedFoodItem(object sender, SelectedItemChangedEventArgs e)
        {
            Food currentSelectedItem = e.SelectedItem as Food;
            await Navigation.PushAsync(new SearchDetailsPage(currentSelectedItem, isSaved: true));
        }

        private async void LoadDataFromDatabase()
        {
            await Task.Run(async () =>
            {
                List<Food> foods = await DbManager.GetAllFoods();
                foods.ForEach(AllFoods.Add);
            });

            progressBarLayout.IsVisible = false;
            resultsLayout.IsVisible = true;
        }
    }
}