using System.Collections.ObjectModel;
using TestMaui.Models;
using TestMaui.Views;
using TestMaui.Helpers;

namespace TestMaui.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        #region Properties
        private ObservableCollection<EmpModel> allEmployees;
        public ObservableCollection<EmpModel> AllEmployees
        {
            set { SetProperty(ref allEmployees, value); }
            get { return allEmployees; }
        }
        private ObservableCollection<EmpModel> employees;
        public ObservableCollection<EmpModel> Employees
        {
            set { SetProperty(ref employees, value); }
            get { return employees; }
        }
        private double minimumValue;
        public double MinimumValue
        {
            set { SetProperty(ref minimumValue, value); }
            get { return minimumValue; }
        }
        private double maximumValue;
        public double MaximumValue
        {
            set { SetProperty(ref maximumValue, value); }
            get { return maximumValue; }
        }
        private double rangeValue;
        public double RangeValue
        {
            set { SetProperty(ref rangeValue, value); }
            get { return rangeValue; }
        }
        #endregion

        #region Commands
        public Command AddCommand { get; }
        public Command DeleteCommand { get; }
        #endregion

        #region Constructor
        public EmployeeViewModel()
        {
            AddCommand = new Command(AddCommandExc);
            DeleteCommand = new Command((obj) => DeleteCommandExc(obj));
        }
        #endregion

        #region Methods
        public async void BindEmployees()
        {
            try
            {
                Employees = new ObservableCollection<EmpModel>();

                var emp = await App.db.GetAllAsync();

                if (emp != null && emp.Count > 0)
                {
                    Employees = new ObservableCollection<EmpModel>(emp);
                    AllEmployees = Employees;

                    MinimumValue = Employees.Min(x => x.Salary);
                    MaximumValue = Employees.Max(x => x.Salary);
                }
            }
            catch (Exception ex)
            {
                SendErrorLogs(ex);
            }
        }
        public void AddCommandExc()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
            }
            catch (Exception ex)
            {
                SendErrorLogs(ex);
            }
        }
        public async void DeleteCommandExc(object model)
        {
            try
            {
                var isDelete = await App.Current.MainPage.DisplayAlert("Confirmation", "Are you sure you want to delete an employee?", "Yes", "No");
                if (isDelete)
                {
                    var data = model as EmpModel;
                    if (data != null)
                    {
                        var res = await App.db.DeleteAsync(data.ID);

                        if (res == 1)
                        {
                            Constants.Alert("Employee Deleted");
                        }
                        else
                        {
                            Constants.Alert("Error during employee deletion process");
                        }

                        BindEmployees();
                    }
                }
            }
            catch (Exception ex)
            {
                SendErrorLogs(ex);
            }
        }
        public void FilterEmployees()
        {
            try
            {
                var data = AllEmployees.Where(x => x.Salary >= RangeValue && x.Salary <= MaximumValue).ToList();
                Employees = new ObservableCollection<EmpModel>(data);
            }
            catch (Exception ex)
            {
                SendErrorLogs(ex);
            }
        }
        #endregion
    }
}
