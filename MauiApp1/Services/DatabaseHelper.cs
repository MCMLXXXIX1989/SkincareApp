using SQLite;

namespace MauiApp1

public class DatabaseHelper
{
    private static SQLiteConnection _database;

    public static SQLiteConnection Database
    {
        get
        {
            if (_database == null)
            {
                // Initialize the database connection
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skincare.db3");
                _database = new SQLiteConnection(databasePath);
                _database.CreateTable<SkincareGoal>(); // Create the table if it doesn't exist
            }
            return _database;
        }
    }

    // Add a new skincare goal
    public static void AddGoal(SkincareGoal goal)
    {
        Database.Insert(goal);
    }

    // Get all skincare goals
    public static List<SkincareGoal> GetGoals()
    {
        return Database.Table<SkincareGoal>().ToList();
    }

    // Delete a skincare goal
    public static void DeleteGoal(int id)
    {
        Database.Delete<SkincareGoal>(id);
    }
}