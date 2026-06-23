using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoSqlWorkshop.Models
{
    // Map this model to Course table in db
    // [Table("Courses", Schema = "adodb")] // Data annotations approach
    public class Course
    {

        // [Key] // Define primary key
        public int Id { get; set; }

        // [Required] // Not null
        // [StringLength(10)] // VARCHAR(10)
        public string Code { get; set; } = string.Empty;

        // [Required] // Not null
        // [StringLength(50)] // VARCHAR(50)
        public string Name { get; set; } = string.Empty;

        // [Required] // Not null
        // [StringLength(300)] // VARCHAR(300)
        public string Description { get; set; } = string.Empty;

        public Course() { }

        public Course(int Id, string Code, string Name, string Description)
        {
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
            this.Description = Description;
        }

    }

}
