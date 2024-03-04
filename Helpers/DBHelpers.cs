using SQLite;
using TestMaui.Models;
using TestMaui.ViewModels;

namespace TestMaui.Helpers
{
    public class DBHelpers
    {
        SQLiteAsyncConnection Database;
        public DBHelpers()
        {
            Init();
        }
        public async void Init()
        {
            try
            {
                if (Database is not null)
                    return;

                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                var result = await Database.CreateTableAsync<EmpModel>();
            }
            catch (Exception ex)
            {
                BaseViewModel.SendErrorLogs(ex);
            }
        }
        public async Task<List<EmpModel>> GetAllAsync()
        {
            try
            {
                return await Database.Table<EmpModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                BaseViewModel.SendErrorLogs(ex);
            }
            return null;
        }
        public async Task<int> SaveAsync(EmpModel item)
        {
            try
            {
                return await Database.InsertAsync(item);
            }
            catch (Exception ex)
            {
                BaseViewModel.SendErrorLogs(ex);
            }
            return 0;
        }

        public async Task<int> DeleteAsync(int empId)
        {
            try
            {
                return await Database.Table<EmpModel>().Where(e => e.ID == empId).DeleteAsync();
            }
            catch (Exception ex)
            {
                BaseViewModel.SendErrorLogs(ex);
            }
            return 0;
        }
    }
}
