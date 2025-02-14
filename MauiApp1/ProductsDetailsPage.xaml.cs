using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage(Product product)
        {
            InitializeComponent();

            // Set the ingredient details for the product
            ingredientDetailsLabel.Text = product.IngredientDetails;
        }
    }
}
