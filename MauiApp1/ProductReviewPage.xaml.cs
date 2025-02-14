private async void OnSubmitReviewClicked(object sender, EventArgs e)
{
    var selectedProduct = vaultListView.SelectedItem as Product;
    if (selectedProduct != null)
    {
        selectedProduct.Rating = ratingSlider.Value;
        selectedProduct.Review = reviewEditor.Text;
        await DatabaseManager.SaveReview(selectedProduct);
        await DisplayAlert("Success", "Review submitted!", "OK");
    }
}
