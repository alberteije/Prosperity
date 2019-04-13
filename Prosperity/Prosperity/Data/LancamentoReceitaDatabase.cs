using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Models;
using System;

namespace Data
{
    public class LancamentoReceitaDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LancamentoReceitaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LancamentoReceita>().Wait();
        }

        public Task<List<LancamentoReceita>> GetItemsAsync()
        {
            return database.Table<LancamentoReceita>().ToListAsync();
        }

        public Task<List<LancamentoReceita>> GetItemsAsyncFilter(string filtro)
        {
            return database.QueryAsync<LancamentoReceita>("SELECT * FROM [LancamentoReceita] WHERE " + filtro);
        }

        public Task<List<LancamentoReceitaAgrupado>> GetItemsAsyncFilterAgrupado(string mesAno)
        {
            try
            {
                var query = "select L.[MesAno], L.[Codigo], C.[Descricao], SUM(L.[Valor]) as Valor FROM [LancamentoReceita] L" +
                    " INNER JOIN [ContaReceita] C ON (L.[Codigo]=C.[Codigo])" +
                    " where L.[MesAno] = '" + mesAno + "' GROUP BY L.[MesAno], L.[Codigo], C.[Descricao]";
                return database.QueryAsync<LancamentoReceitaAgrupado>(query);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<LancamentoReceita> GetItemAsync(int id)
        {
            return database.Table<LancamentoReceita>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LancamentoReceita item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(LancamentoReceita item)
        {
            return database.DeleteAsync(item);
        }
    }
}

