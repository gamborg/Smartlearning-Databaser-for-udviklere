using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; } = 0;

        [Column(TypeName = "decimal(12, 2)")]
        public decimal UnitPrice { get; set; } = 0;

        // Navigation properties

        public virtual Product? Product { get; set; }

        public virtual Order? Order { get; set; }
    }
}
