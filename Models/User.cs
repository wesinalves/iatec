using System.ComponentModel.DataAnnotations;

namespace iatec.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string name { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string password { get; set; }
    }
}