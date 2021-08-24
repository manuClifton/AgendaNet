using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_UTN.Datos;
using Agenda_UTN.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_UTN.Pages.Categorias
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public BorrarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public Categoria Categoria { get; set; }

        public async void OnGet(int id)
        {
            Categoria = await _contexto.Categoria.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)//si se cargo todo 
            {
                var CategoriaDesdeDb = await _contexto.Categoria.FindAsync(Categoria.Id);
                if (CategoriaDesdeDb == null)
                {
                    return NotFound();
                }
                _contexto.Remove(CategoriaDesdeDb);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();// se queda en la misma pagina
            }
        }
    }
}
