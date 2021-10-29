using A2_final.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A2_final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCell : ViewCell
    {
        public static readonly BindableProperty FoodItemProperty = BindableProperty.Create("FoodItem", typeof(Food), typeof(ProductCell));

        public ProductCell()
        {
            InitializeComponent();
        }

        public Food FoodItem
        {
            get => GetValue(FoodItemProperty) as Food;
            set => SetValue(FoodItemProperty, value);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                cellLayout.BindingContext = FoodItem;
            }
        }
    }
}