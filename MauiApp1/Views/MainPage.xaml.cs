using Android.Content.Res;
using MauiApp1.Services;
using MauiApp1.Theme;    // If using ThemeManager

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection _database;

        public MainPage()
        {
            InitializeComponent();

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skincareApp.db3");
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<Product>();
        }

        private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchQuery = e.NewTextValue;
            List<Product> filteredProducts = await DatabaseManager.SearchProducts(searchQuery);
            vaultListView.ItemsSource = filteredProducts;
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            await DatabaseManager.AddProductToVault("User123", 1);
            await DisplayAlert("Success", "Product added to The Vault!", "OK");
        }

        private async void OnViewVaultClicked(object sender, EventArgs e)
        {
            List<Product> products = await DatabaseManager.GetUserVault("User123");
            vaultListView.ItemsSource = products;
        }
    }
}
private async void OnProductTapped(object sender, ItemTappedEventArgs e)
{
    var selectedProduct = e.Item as Product;
    if (selectedProduct != null)
    {
        // Navigate to the product details page
        await Navigation.PushAsync(new ProductDetailsPage(selectedProduct));
    }
}
private async void OnSaveStartDateClicked(object sender, EventArgs e)
{
    var selectedProduct = vaultListView.SelectedItem as Product;
    if (selectedProduct != null)
    {
        selectedProduct.StartDate = startDatePicker.Date;
        await DatabaseManager.UpdateProductStartDate(selectedProduct);
    }
}
private void OnThemeChanged(object sender, EventArgs e)
{
    var selectedTheme = themePicker.SelectedItem.ToString();
    ThemeManager.ApplyTheme(selectedTheme);
}
public void ApplyTheme(string theme)
{
    switch (theme)
    {
        case "Reputation":
            Resources = new ResourceDictionary { Source = new Uri("ResourceDictionary/ReputationStyle.xaml", UriKind.Relative) };
            break;
        case "Lover":
            Resources = new ResourceDictionary { Source = new Uri("ResourceDictionary/LoverStyle.xaml", UriKind.Relative) };
            break;
            // Add other cases for other themes
    }
}

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Load themes into the picker
        ThemePicker.ItemsSource = ThemeManager.Themes;
    }

    private void OnThemeSelected(object sender, EventArgs e)
    {
        var selectedTheme = ThemePicker.SelectedItem as Theme;
        if (selectedTheme != null)
        {
            ThemeManager.ApplyTheme(selectedTheme, this);
        }
    }

    private void OnGetTipsClicked(object sender, EventArgs e)
    {
        // Your existing logic for skincare tips
    }
}
}
private void OnThemeSelected(object sender, EventArgs e)
{
    var selectedTheme = ThemePicker.SelectedItem as string;
    var resources = Application.Current.Resources;

    switch (selectedTheme)
    {
        case "Reputation":
            resources.MergedDictionaries.Clear();
            resources.MergedDictionaries.Add(new Dictionary1 { Source = "ReputationStyle" });
            break;
        case "Lover":
            resources.MergedDictionaries.Clear();
            resources.MergedDictionaries.Add(new Dictionary1 { Source = "LoverStyle" });
            break;
        case "Folklore":
            resources.MergedDictionaries.Clear();
            resources.MergedDictionaries.Add(new Dictionary1 { Source = "FolkloreStyle" });
            break;
        case "1989":
            resources.MergedDictionaries.Clear();
            resources.MergedDictionaries.Add(new Dictionary1 { Source = "NineteenEightyNineStyle" });
            break;
    }
}
< StackLayout Padding = "20" >
    < !--Theme Picker-- >
    < Picker x: Name = "ThemePicker"
            Title = "Choose a Theme"
            SelectedIndexChanged = "OnThemeSelected" >
        < Picker.Items >
            < x:String > Reputation </ x:String >
            < x:String > Lover </ x:String >
            < x:String > Folklore </ x:String >
            < x:String > 1989 </ x:String >
        </ Picker.Items >
    </ Picker >

    < !--Title-- >
    < Label Text = "Welcome to Skincare App!"
           FontSize = "Large"
           HorizontalOptions = "Center"
           VerticalOptions = "Start" />

    < !--Input field for skin type -->
    <Entry Placeholder="Enter your skin type (e.g., oily, dry)" 
           x:Name = "SkinTypeEntry" />

    < !--Button to get tips -->
    <Button Text="Get Skincare Tips" 
            Clicked="OnGetTipsClicked" 
            HorizontalOptions="Center"
            Style="{DynamicResource ButtonStyle}" />

    <!-- Label to display tips -->
    <Label x:Name = "TipsLabel"
           Text = ""
           FontSize = "Medium"
           HorizontalOptions = "Center"
           VerticalOptions = "CenterAndExpand" />
</ StackLayout >
private void OnThemeSelected(object sender, EventArgs e)
{
    var selectedTheme = ThemePicker.SelectedItem as string;
    var resources = Application.Current.Resources;

    switch (selectedTheme)
    {
        case "Reputation":
            resources.Clear();
            resources.Add("ButtonStyle", resources["ReputationStyle"]);
            break;
        case "Lover":
            resources.Clear();
            resources.Add("ButtonStyle", resources["LoverStyle"]);
            break;
        case "Folklore":
            resources.Clear();
            resources.Add("ButtonStyle", resources["FolkloreStyle"]);
            break;
        case "1989":
            resources.Clear();
            resources.Add("ButtonStyle", resources["NineteenEightyNineStyle"]);
            break;
    }
}