using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = "";

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? UnitPrice { get; set; }

        public string? Package { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDiscontinued { get; set; } = false;

        // Navigation properties
        public virtual Supplier? Supplier { get; set; }

    }
}
