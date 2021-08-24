using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_UTN.Modelos
{
    public class Categoria
    {
        [Key] //DAte anotation
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(15,ErrorMessage ="{0} El nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; } // puede ser nullo

    }
}
