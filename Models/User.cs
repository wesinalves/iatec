using System.ComponentModel.DataAnnotations;

namespace iatec.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Password { get; set; }
    }
}