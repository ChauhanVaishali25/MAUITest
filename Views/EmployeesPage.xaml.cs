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

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        (this.BindingContext as EmployeeViewModel).FilterEmployees();
    }
}