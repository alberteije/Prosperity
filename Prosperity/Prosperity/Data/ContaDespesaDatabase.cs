using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Models;

namespace Data
{
	public class ContaDespesaDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ContaDespesaDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ContaDespesa>().Wait();

            Task<List<ContaDespesa>> contas = GetItemsAsync();
            if (contas.Result.Count <= 0)
            {
                /**
                 * Se o usuário estiver carregando o sistema pela primeira vez
                 * ou se a tabela conta de despesa estiver vazia,
                 * os dados padrões das contas de despesa serão inseridos
                 */

                /// EXERCICIO: Melhore esse código
                ContaDespesa c = new ContaDespesa { Codigo = "2001", Descricao = "Educação" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2002", Descricao = "Saúde" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2003", Descricao = "Alimentação" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2004", Descricao = "Moradia" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2005", Descricao = "Carro" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2006", Descricao = "Diversão" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2007", Descricao = "Doações" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2008", Descricao = "Investimentos" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2009", Descricao = "Impostos" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2010", Descricao = "Seguros" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2011", Descricao = "Viagens" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2012", Descricao = "Empréstimos" };
                SaveItemAsync(c);
                c = new ContaDespesa { Codigo = "2013", Descricao = "Outras Despesas" };
                SaveItemAsync(c);
            }
        }

        public Task<List<ContaDespesa>> GetItemsAsync()
		{
			//return database.Table<ContaDespesa>().ToListAsync();
            return database.Table<ContaDespesa>().OrderBy(contaDespesa => contaDespesa.Codigo).ToListAsync();
        }

		public Task<ContaDespesa> GetItemAsync(int id)
		{
			return database.Table<ContaDespesa>().Where(item => item.ID == id).FirstOrDefaultAsync();
		}

        public Task<ContaDespesa> GetItemPorCodigoAsync(string codigo)
        {
            return database.Table<ContaDespesa>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ContaDespesa item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ContaDespesa item)
		{
			return database.DeleteAsync(item);
		}
	}
}

