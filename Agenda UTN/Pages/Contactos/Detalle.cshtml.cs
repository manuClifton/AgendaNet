using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_UTN.Datos;
using Agenda_UTN.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_UTN.Pages.Contactos
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public DetalleModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [BindProperty]
        public Contacto Contacto { get; set; }

        public async void OnGet(int id)
         {
            Contacto = await _contexto.Contacto
                                        .Where(c => c.Id == id)
                                        .Include(c => c.Categoria)
                                        .FirstOrDefaultAsync();
        }
    }
}
