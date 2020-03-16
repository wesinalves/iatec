using System.ComponentModel.DataAnnotations;

namespace iatec.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string name { get; set; }

        [MaxLength(1024, ErrorMessage = "campo obrigatório")]
        public string description { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string place { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string type { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [DataType(DataType.DateTime)]
        public System.DateTime startDate { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="categoria inválida")]
        public int userId { get; set; }

        public User user { get; set; }

        
    }

}