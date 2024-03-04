using TestMaui.ViewModels;

namespace TestMaui.Views;

public partial class EmployeesPage : ContentPage
{
    public EmployeesPage()
    {
        InitializeComponent();
        this.BindingContext = new EmployeeViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (this.BindingContext as EmployeeViewModel).BindEmployees();
    }
}