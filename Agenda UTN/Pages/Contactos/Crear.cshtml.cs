using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_UTN.Datos;
using Agenda_UTN.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_UTN.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public CrearContactoVM ContactoVm { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ContactoVm = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = new Modelos.Contacto()
            };

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)//si se cargo todo 
            {
                await _contexto.Contacto.AddAsync(ContactoVm.Contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();// se queda en la misma pagina
            }
        }
    }//
}//
