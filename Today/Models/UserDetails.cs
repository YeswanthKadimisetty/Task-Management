using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Today.Models
{
    public class UserDetails
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }  
        [Required]

        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$",
            ErrorMessage = "Password Should contain one number, one lowercase, uppercase!!")]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
