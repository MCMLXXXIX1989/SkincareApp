MainPage = new AppShell();
using System;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

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

        private void OnGetTipsClicked(object sender, EventArgs e)
        {
            string skinType = SkinTypeEntry.Text.ToLower();
            string tips = "";

            switch (skinType)
            {
                case "oily":
                    tips = "Use a gentle cleanser and oil-free moisturizer. Avoid heavy creams.";
                    break;
                case "dry":
                    tips = "Use a hydrating cleanser and a rich moisturizer. Avoid harsh exfoliants.";
                    break;
                case "combination":
                    tips = "Use a balanced cleanser and moisturizer. Apply spot treatments as needed.";
                    break;
                case "sensitive":
                    tips = "Use fragrance-free products and patch-test new products.";
                    break;
                default:
                    tips = "Please enter a valid skin type (oily, dry, combination, sensitive).";
                    break;
            }

            TipsLabel.Text = tips;
        }
    }
}