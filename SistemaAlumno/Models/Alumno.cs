using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SistemaAlumno.Models
{
    public class Alumno {   //valido con datanottation 
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Rut es obligatorio")]
        [MaxLength(12,ErrorMessage ="Maximo 12 caracteres")]
        public string Rut { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellidos es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Edad es obligatoria")]
        [Range(16,109,ErrorMessage ="La edad debe ser entre 16 y 109")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Sexo es obligatoria")]
        [Range(1,2,ErrorMessage = "Ingrese 1 masculino 2 femenino ")]
        public int Sexo{ get; set; }

    }
}