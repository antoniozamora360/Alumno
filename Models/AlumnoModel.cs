using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alumno.Models
{
    public class AlumnoModel
    {
        [Key]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [Display(Name = "Apellido Paterno")]
        [MaxLength(50, ErrorMessage = "El apellido paterno no puede ser mayor a 50 caracteres")]
        public string Apellido_Paterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [MaxLength(50, ErrorMessage = "El apellido materno no puede ser mayor a 50 caracteres")]
        public string Apellido_Materno { get; set; }
        [Range(typeof(DateTime), "1/1/1966", "1/1/2019")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required(ErrorMessage = "El genero es obligatorio")]
        public string Genero { get; set; }
        [Range(typeof(DateTime), "1/1/1966", "1/1/2021")]
        [Required(ErrorMessage = "La fecha de ingreso es obligatorio")]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }
        public bool Activo { get; set; }
        [Required(ErrorMessage = "El RFC es obligatorio")]
        //[RegularExpression(@"/^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$/")]
        public string RFC { get; set; }

        public List<SelectListItem> Generos { get; set; }
    }
}
