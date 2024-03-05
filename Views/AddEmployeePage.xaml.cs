using TestMaui.ViewModels;

namespace TestMaui.Views;

public partial class AddEmployeePage : ContentPage
{
    public AddEmployeePage()
    {
        InitializeComponent();
        this.BindingContext = new AddEmployeeViewModel();
    }
    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        try
        {
            if (((Entry)sender) != null)
            {
                if (decimal.TryParse(((Entry)sender).Text, out decimal salary) && salary > 0)
                {
                    ((Entry)sender).Text = salary.ToString("F2");
                }
                else
                {
                    ((Entry)sender).Text = "0.00";
                }
            }
        }
        catch (Exception ex)
        {
            BaseViewModel.SendErrorLogs(ex);
        }
    }
}