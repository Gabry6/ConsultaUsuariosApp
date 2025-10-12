using System.ComponentModel.DataAnnotations;

namespace ConsultaUsuariosApp.ViewModels
{
    // ViewModel para Login
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    // ViewModel para Consulta
    public class QueryViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
        public string Status { get; set; }
        public int? idEstatus { get; set; }
    }

    // ViewModel para Agregar Usuario
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(90)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El usuario es requerido")]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(50)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email no válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        [Range(1, 120, ErrorMessage = "Edad debe estar entre 1 y 120")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El estatus es requerido")]
        [Display(Name = "Estatus")]
        public int idEstatus { get; set; }
    }

    // ViewModel para Editar Usuario
    public class EditUserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(90)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El usuario es requerido")]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email no válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        [Range(1, 120, ErrorMessage = "Edad debe estar entre 1 y 120")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El estatus es requerido")]
        [Display(Name = "Estatus")]
        public int idEstatus { get; set; }
    }

    // ViewModel para Borrar Usuario
    public class DeleteUserViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
        public string Status { get; set; }
    }
}