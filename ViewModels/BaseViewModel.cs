using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestMaui.Helpers;

namespace TestMaui.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        #endregion

        #region Commands

        #endregion

        #region Constructor
        public BaseViewModel()
        {

        }
        #endregion

        #region Methods
        public static void SendErrorLogs(Exception ex)
        {
            try
            {
#if DEBUG
                Constants.Alert(ex.Message);
#endif
            }
            catch (Exception exc)
            {

            }
        }
        #endregion
    }
}
