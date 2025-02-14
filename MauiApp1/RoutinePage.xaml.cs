private async void OnAddToRoutineClicked(object sender, EventArgs e)
{
    var selectedProduct = vaultListView.SelectedItem as Product;
    if (selectedProduct != null)
    {
        await DatabaseManager.AddToRoutine(selectedProduct);
        await DisplayAlert("Success", "Product added to your routine!", "OK");
    }
}
