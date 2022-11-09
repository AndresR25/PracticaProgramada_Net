using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaProgramadaNo3.Models.ViewModel
{
    public class AlumnoModelo
    {
        [Display(Name = "carnet")]
        [Required(ErrorMessage = "Campo carnet es obligatorio")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo letras de la A a la Z")]
        [MaxLength(6, ErrorMessage = "El carnet tiene que tener maximo 6 caracteres")]
        [CarnetExiste]
        public string carnet { get; set; }

        [Display(Name = "nombre")]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre tiene que tener maximo 30 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "apellido")]
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(30, ErrorMessage = "El apellido tiene que tener maximo 30 caracteres")]
        public string apellido { get; set; }

        [Display(Name = "genero")]
        [Required(ErrorMessage = "Genero es obligatorio")]
        [MaxLength(1, ErrorMessage = "El genero tiene que tener maximo 1 caracter")]
        public string genero { get; set; }

        [EmailAddress(ErrorMessage = "Direccion de correo Electronico")]
        [Display(Name = "email")]
        [Required(ErrorMessage = "Email es obligatorio")]
        [MaxLength(50, ErrorMessage = "El email tiene que tener maximo 50 caracteres")]
        public string email { get; set; }

        
        [Display(Name = "telefono")]
        [Required(ErrorMessage = "Telefono es obligatorio")]
        [Phone(ErrorMessage ="Este campo es un telefono")]
        [MaxLength(40, ErrorMessage = "El telefono tiene que tener maximo 40 caracteres")]
        public string telefono { get; set; }

        [Display(Name = "FechaNacimiento")]
        [Required(ErrorMessage = "Fecha de nacimiento es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public class CarnetExiste : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using(PracticaNo3Entities db= new PracticaNo3Entities())
                {
                    string codigo = (string)value;
                    if (db.Alumno.Where(d => d.carnet == codigo).Count() > 0)
                        return new ValidationResult("Numero de carnet ya existe");
                }
                return ValidationResult.Success;
            }
        }
    }
}