namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(NextPage));
            Routing.RegisterRoute(nameof(SkincareTrackerPage), typeof(SkincareTrackerPage));
        }
    }
}
