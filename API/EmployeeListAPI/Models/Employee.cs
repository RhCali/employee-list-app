using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EmployeeListAPI.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        
        [Required]
        public int age { get; set; }

        [Required]
        [MaxLength(15)]
        public string phone_number { get; set; }

        [Required]
        public DateOnly date_of_birth { get; set; }

        [Required]
        [MaxLength(255)]
        public string address { get; set; }

        [Required]
        [MaxLength(100)]
        public string job_title { get; set; }

        [Required]
        public decimal salary { get; set; }

        [Required]
        public bool isActive { get; set; }

        internal SqlDbType ToDateTime(TimeOnly minValue)
        {
            throw new NotImplementedException();
        }
    }
}
