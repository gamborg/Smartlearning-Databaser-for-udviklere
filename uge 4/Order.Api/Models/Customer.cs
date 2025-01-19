using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string FirstName { get; set; } = "";

        [MaxLength(40)]
        public string LastName { get; set; } = "";

        [MaxLength(40)]
        public string? City { get; set; }

        [MaxLength(40)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        public virtual string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
