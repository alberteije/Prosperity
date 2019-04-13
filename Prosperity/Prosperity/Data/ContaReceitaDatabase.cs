using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Models;
using System.Collections;

namespace Data
{
	public class ContaReceitaDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ContaReceitaDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ContaReceita>().Wait();

            Task<List<ContaReceita>> contas = GetItemsAsync();
            if (contas.Result.Count <= 0)
            {
                /**
                 * Se o usuário estiver carregando o sistema pela primeira vez
                 * ou se a tabela conta de receita estiver vazia,
                 * os dados padrões das contas de receita serão inseridos
                 */

                /// EXERCICIO: Melhore esse código
                ContaReceita c = new ContaReceita{Codigo= "1001", Descricao= "Saldo Anterior em Conta"};
                SaveItemAsync(c);
                c = new ContaReceita { Codigo = "1002", Descricao = "Salário" };
                SaveItemAsync(c);
                c = new ContaReceita { Codigo = "1003", Descricao = "Aluguéis" };
                SaveItemAsync(c);
                c = new ContaReceita { Codigo = "1004", Descricao = "Outras Receitas" };
                SaveItemAsync(c);
            }
        }

		public Task<List<ContaReceita>> GetItemsAsync()
		{
			return database.Table<ContaReceita>().OrderBy(contaReceita => contaReceita.Codigo).ToListAsync();
		}

		public Task<ContaReceita> GetItemAsync(int id)
		{
			return database.Table<ContaReceita>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

        public Task<ContaReceita> GetItemPorCodigoAsync(string codigo)
        {
            return database.Table<ContaReceita>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ContaReceita item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ContaReceita item)
		{
			return database.DeleteAsync(item);
		}
	}
}

