using CompService.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompService.Data
{
    public class ComputerServiceDatabase
    {
        public static SQLiteAsyncConnection _database;

        public ComputerServiceDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PriceCatalog>().Wait();
            _database.CreateTableAsync<Repair>().Wait();
            _database.CreateTableAsync<Staff>().Wait();
            _database.CreateTableAsync<Magazine>().Wait();
        }

        public Task<Staff> Login_Async(string email, string password)
        {
            return _database.Table<Staff>()
                            .Where(i => i.Email == email && i.Password == password)
                            .FirstOrDefaultAsync();
        }

        #region PRICE_CATALOG
        public Task<List<PriceCatalog>> GetData_PriceCatalog_Async()
        {
            return _database.Table<PriceCatalog>().ToListAsync();
        }

        public Task<PriceCatalog> Get_PriceCatalogItem_Async(int id)
        {
            return _database.Table<PriceCatalog>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePriceCatalogAsync(PriceCatalog data)
        {
            if (data.ID != 0)
            {
                return _database.UpdateAsync(data);
            }
            else
            {
                return _database.InsertAsync(data);
            }
        }

        public Task<int> Delete_PriceCatalogItem_Async(PriceCatalog data)
        {
            return _database.DeleteAsync(data);
        }
        #endregion

        #region STAFF
        public Task<List<Staff>> GetData_Staff_Async()
        {
            return _database.Table<Staff>().ToListAsync();
        }

        public Task<Staff> GetData_Staff_Async(int id)
        {
            return _database.Table<Staff>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveStaffAsync(Staff data)
        {
            if (data.ID != 0)
            {
                return _database.UpdateAsync(data);
            }
            else
            {
                return _database.InsertAsync(data);
            }
        }

        public Task<int> Delete_Staff_Async(Staff data)
        {
            return _database.DeleteAsync(data);
        }
        #endregion

        #region MAGAZINE
        public Task<List<Magazine>> GetData_Magazine_Async()
        {
            return _database.Table<Magazine>().ToListAsync();
        }

        public Task<Magazine> GetData_Magazine_Async(int id)
        {
            return _database.Table<Magazine>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveMagazineAsync(Magazine data)
        {
            if (data.ID != 0)
            {
                return _database.UpdateAsync(data);
            }
            else
            {
                return _database.InsertAsync(data);
            }
        }

        public Task<int> Delete_Magazine_Async(Magazine data)
        {
            return _database.DeleteAsync(data);
        }
        #endregion

        #region REPAIR
        public Task<List<Repair>> GetData_Repair_Async()
        {
            return _database.Table<Repair>().ToListAsync();
        }

        public Task<Repair> GetData_Repair_Async(int id)
        {
            return _database.Table<Repair>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRepairAsync(Repair data)
        {
            if (data.ID != 0)
            {
                return _database.UpdateAsync(data);
            }
            else
            {
                return _database.InsertAsync(data);
            }
        }

        public Task<int> Delete_Repair_Async(Repair data)
        {
            return _database.DeleteAsync(data);
        }
        #endregion
    }
}
