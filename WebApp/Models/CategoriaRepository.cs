namespace WebApp.Models
{
	public class CategoriaRepository
	{
		private static List<Categoria> categorias = new List<Categoria>()
		{
			new Categoria() { Id = 1, Nome = "Frutas", Descricao = "Seção de Frutas" },
			new Categoria() { Id = 2, Nome = "Carnes", Descricao = "Seção de Carnes" }
		};

		public static void AddCategoria(Categoria categoria)
		{
			if(GetCategorias().Count() > 0)
			{
                var maxId = categorias.Max(c => c.Id);
                categoria.Id = maxId + 1;
                categorias.Add(categoria);
            } else
			{
                categoria.Id = 1;
                categorias.Add(categoria);
            }
			
		}

		public static List<Categoria> GetCategorias() => categorias;

		public static Categoria? GetCategoriaById(int id)
		{
			var categoria = categorias.FirstOrDefault(x => x.Id == id);
			if(categoria != null)
			{
				return new Categoria
				{
					Id = categoria.Id,
					Nome = categoria.Nome,
					Descricao = categoria.Descricao
				};
			}
            return null;
		}

        public static void AtualizarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id) return;
            var categoriaAtualizada = categorias.FirstOrDefault(x => x.Id == id);
            if (categoriaAtualizada != null)
            {
                categoriaAtualizada.Nome = categoria.Nome;
                categoriaAtualizada.Descricao = categoria.Descricao;
            }
        }

        public static void DeletarCategoria(int id)
		{
			var categoria = categorias.FirstOrDefault(x =>  id == x.Id);
			if(categoria != null)
			{
				categorias.Remove(categoria);
			}
		}
	}
}
