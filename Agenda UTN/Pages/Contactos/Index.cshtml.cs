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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Contacto> Contactos { get; set; }
        public async Task OnGet()// void o TASK?
        {
            Contactos = await _contexto.Contacto.Include(c => c.Categoria).ToListAsync(); //incluir datos de la tabla categoria
        }
    }
}
