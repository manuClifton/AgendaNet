using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_UTN.Modelos
{
    public class Contacto
    {
        [Key] //DAte anotation
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(15, ErrorMessage = "{0} El nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El TELÉFONO es obligatorio")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; } // puede ser nullo

        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
