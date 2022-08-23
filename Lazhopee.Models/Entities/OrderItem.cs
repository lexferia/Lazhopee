using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lazhopee.Models.Entities
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(1.00, double.MaxValue)]
        public double Price { get; set; }

        public Product Product { get; set; }
    }
}
