namespace MauiApp1
{
    public partial class SkincareTrackerPage : ContentPage
    {
        public SkincareTrackerPage()
        {
            InitializeComponent();
        }

        private void OnTrackProgressClicked(object sender, EventArgs e)
        {
            // Logic to track progress (e.g., open a new page or show a dialog)
            DisplayAlert("Progress Tracked", "Your progress has been recorded!", "OK");
        }
    }
}
private void OnEmojiClicked(object sender, EventArgs e)
{
    var button = sender as Button;
    string emoji = button.Text;

    // Create a new SkincareGoal object
    var goal = new SkincareGoal
    {
        Album = "Reputation", // Replace with the selected album
        Goal = "Oily Skin & Blackheads", // Replace with the selected goal
        Emoji = emoji,
        Date = DateTime.Now
    };

    // Save the goal to the database
    DatabaseHelper.AddGoal(goal);

    // Show a confirmation message
    DisplayAlert("Progress Tracked", $"You selected {emoji}", "OK");
}
protected override void OnAppearing()
{
    base.OnAppearing();
    GoalsListView.ItemsSource = DatabaseHelper.GetGoals();
}