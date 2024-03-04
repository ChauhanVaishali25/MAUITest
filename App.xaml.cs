using TestMaui.Helpers;
using TestMaui.Views;

namespace TestMaui
{
    public partial class App : Application
    {
        public static DBHelpers db;

        public App()
        {
            InitializeComponent();

            db = new DBHelpers();

            MainPage = new NavigationPage(new EmployeesPage());
        }
    }
}
