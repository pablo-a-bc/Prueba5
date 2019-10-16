using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SistemaAlumno.Models
{
    public class Carreras
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Codigo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Codigo { get; set; }
        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string carrera { get; set; }
        [Display(Name = "Area de negocio")]
        [Required(ErrorMessage = "Area de negocio es obligatorio")]
        [MaxLength(500, ErrorMessage = "Maximo 500 caracteres")]
        public string Areadenegocio { get; set; }
        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set; } // se forza en duro 1. ok
        
    }

    public enum Area
    {
        Informática,
        Telecomunicaciones,
        Finanzas

    }
}