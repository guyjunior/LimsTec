using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimsDetec.Models
{
    [Table("Samples")]
    public class Sample
    {
        [Key]
        public int Id { get; set; }

        public string Cod_Interno { get; set; }

        public DateTime Data_Cadastro { get; set; }
    }
}
