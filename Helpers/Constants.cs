using SQLite;

namespace TestMaui.Helpers
{
    public static class Constants
    {
        public const string DatabaseFilename = "Employees.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static async void Alert(string message)
        {
            await App.Current.MainPage.DisplayAlert("Info", message, "Ok");
        }
    }
}
