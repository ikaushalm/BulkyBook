using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Catergory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Description="Display Order") ]
        public int DisplayOrder { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}

