using System.ComponentModel.DataAnnotations;

namespace HRWeb.Data.Entities
{
    public class Recruiter
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string FirstName { get; set; }
        [StringLength(500)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public long MobilePhone { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
    }
}
