using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaUsuariosApp.Models
{
    [Table("USERS")]
    public class USERS
    {
        [Key]
        public int ID { get; set; }

        [StringLength(90)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Edad { get; set; }

        public int? idEstatus { get; set; }

        [ForeignKey("idEstatus")]
        public virtual mSTATUS mSTATUS { get; set; }
    }

    [Table("mSTATUS")]
    public class mSTATUS
    {
        [Key]
        public int idStatus { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}