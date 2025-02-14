namespace MauiApp1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            var app = builder.Build();
            app.Run();
        }
    }
}
