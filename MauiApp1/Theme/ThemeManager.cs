using System.Collections.Generic;
using Newtonsoft.Json;

namespace MauiApp1
{
    public static class ThemeManager
    {
    public static List<Theme> Themes
	Themes { get; private set; }

	static ThemeManager()
	{
    	Themes = JsonHelper.LoadEmbeddedResource<List<Theme>>("SkincareApp.themes.json");
        }

        public static void ApplyTheme(Theme theme, ContentPage page)
        {
            page.BackgroundColor = theme.BackgroundColor;
            // Apply styles to all elements on the page
            foreach (var view in page.Content.GetVisualTreeDescendants())
            {
                if (view is Label label)
                {
                    label.TextColor = theme.TextColor;
                    label.FontFamily = theme.FontFamily;
                }
                else if (view is Button button)
                {
                    button.BackgroundColor = theme.ButtonColor;
                    button.TextColor = theme.TextColor;
                    button.FontFamily = theme.FontFamily;
                }
            }
        }
    }
}