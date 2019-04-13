using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Models;

namespace Data
{
	public class ExtratoBancoDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ExtratoBancoDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ExtratoBanco>().Wait();
		}

		public Task<List<ExtratoBanco>> GetItemsAsync()
		{
			return database.Table<ExtratoBanco>().ToListAsync();
		}

        public Task<List<ExtratoBanco>> GetItemsAsyncFilter(string filtro)
        {
            return database.QueryAsync<ExtratoBanco>("SELECT * FROM [ExtratoBanco] WHERE " + filtro);
        }

		public Task<ExtratoBanco> GetItemAsync(int id)
		{
			return database.Table<ExtratoBanco>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(ExtratoBanco item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ExtratoBanco item)
		{
			return database.DeleteAsync(item);
		}

        public Task<int> DeleteAsyncFilter(string filtro)
        {
            return database.ExecuteAsync("DELETE FROM [ExtratoBanco] WHERE " + filtro);
        }

    }
}

