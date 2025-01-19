using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [MaxLength(10)]
        public string? OrderNumber { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? TotalAmount { get; set; }

        // Navigation properties
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
