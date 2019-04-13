using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Models;
using System;

namespace Data
{
	public class LancamentoDespesaDatabase
	{
		readonly SQLiteAsyncConnection database;

		public LancamentoDespesaDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<LancamentoDespesa>().Wait();
		}

		public Task<List<LancamentoDespesa>> GetItemsAsync()
		{
			return database.Table<LancamentoDespesa>().ToListAsync();
		}

        public Task<List<LancamentoDespesa>> GetItemsAsyncFilter(string filtro)
        {
            return database.QueryAsync<LancamentoDespesa>("SELECT * FROM [LancamentoDespesa] WHERE " + filtro);
        }

        public Task<List<LancamentoDespesaAgrupado>> GetItemsAsyncFilterAgrupado(string mesAno)
        {
            try
            {
                var query = "select L.[MesAno], L.[Codigo], C.[Descricao], SUM(L.[Valor]) as Valor FROM [LancamentoDespesa] L" +
                    " INNER JOIN [ContaDespesa] C ON (L.[Codigo]=C.[Codigo])" +
                    " where L.[MesAno] = '" + mesAno + "' GROUP BY L.[MesAno], L.[Codigo], C.[Descricao]";
                return database.QueryAsync<LancamentoDespesaAgrupado>(query);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<LancamentoDespesa> GetItemAsync(int id)
		{
			return database.Table<LancamentoDespesa>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(LancamentoDespesa item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(LancamentoDespesa item)
		{
			return database.DeleteAsync(item);
		}
	}
}

