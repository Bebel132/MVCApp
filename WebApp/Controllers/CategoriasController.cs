using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            var categorias = CategoriaRepository.GetCategorias();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            CategoriaRepository.AddCategoria(categoria);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var categoria = CategoriaRepository.GetCategoriaById(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            CategoriaRepository.AtualizarCategoria(categoria.Id, categoria);
            //return this.Index();
            return RedirectToAction(nameof(Index));
        }

		public IActionResult Delete(int id)
        {
            CategoriaRepository.DeletarCategoria(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
