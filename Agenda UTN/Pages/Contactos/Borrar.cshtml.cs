using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_UTN.Datos;
using Agenda_UTN.Modelos;
using Agenda_UTN.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_UTN.Pages.Contactos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public BorrarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public CrearContactoVM ContactoVm { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVm = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)//si se cargo todo 
            {
                var ContactoDesdeDb = await _contexto.Contacto.FindAsync(ContactoVm.Contacto.Id);
                if (ContactoDesdeDb == null)
                {
                    return NotFound();
                }
                _contexto.Remove(ContactoDesdeDb);
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
