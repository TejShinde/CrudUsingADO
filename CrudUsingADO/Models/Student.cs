using System .ComponentModel .DataAnnotations;

namespace CrudUsingADO .Models
    {
    public class Student
        {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType .EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Student Grade")]
        [Required]
        public string? Grade { get; set; }
        }
    }
