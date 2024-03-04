using System.Collections.ObjectModel;
using TestMaui.Helpers;
using TestMaui.Models;

namespace TestMaui.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        #region Properties
        private EmpModel employee = new EmpModel();
        public EmpModel Employee
        {
            set { SetProperty(ref employee, value); }
            get { return employee; }
        }
        private ObservableCollection<string> departments;
        public ObservableCollection<string> Departments
        {
            set { SetProperty(ref departments, value); }
            get { return departments; }
        }
        private string selectedDepartment;
        public string SelectedDepartment
        {
            set { SetProperty(ref selectedDepartment, value); }
            get { return selectedDepartment; }
        }
        #endregion

        #region Commands
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Constructor
        public AddEmployeeViewModel()
        {
            SaveCommand = new Command(SaveCommandExc);
            CancelCommand = new Command(() => App.Current.MainPage.Navigation.PopAsync());

            Departments = new ObservableCollection<string>()
            {
                "Manager", "Developer", "DevOps", "QA"
            };
        }
        #endregion

        #region Methods
        public async void SaveCommandExc()
        {
            try
            {
                if (Employee == null)
                {
                    Employee = new EmpModel();
                }

                if (string.IsNullOrEmpty(Employee.Name) || string.IsNullOrWhiteSpace(Employee.Name))
                {
                    Constants.Alert("Please Enter Employee Name");
                    return;
                }
                if (Employee.Salary <= 0)
                {
                    Constants.Alert("Please Enter Salary");
                    return;
                }
                if (string.IsNullOrEmpty(SelectedDepartment) || string.IsNullOrWhiteSpace(SelectedDepartment))
                {
                    Constants.Alert("Please Select Department");
                    return;
                }

                Employee.Department = SelectedDepartment;


                var res = await App.db.SaveAsync(Employee);

                if (res == 1)
                {
                    Constants.Alert("Employee inserted");
                }
                else
                {
                    Constants.Alert("Error during employee insertion process");
                }

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                SendErrorLogs(ex);
            }
        }
        #endregion
    }
}
