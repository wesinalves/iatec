using System.ComponentModel.DataAnnotations;

namespace iatec.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Name { get; set; }

        [MaxLength(1024, ErrorMessage = "campo obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Place { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [DataType(DataType.DateTime)]
        public System.DateTime StartDate { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="categoria inválida")]
        public int UserId { get; set; }

        public User User { get; set; }

        
    }

}