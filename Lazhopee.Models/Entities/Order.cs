using Lazhopee.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lazhopee.Models.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        [Required]
        public IEnumerable<OrderItem> Items { get; set; }

        [Required]
        public int Status { get; set; } = (int)OrderStatus.Pending;

        public string CouponCode { get; set; }

        [Required]
        [Range(1.00, double.MaxValue)]
        public double SubTotal { get; set; }

        [Required]
        public double DiscountAmount { get; set; }

        [Required]
        public double TaxAmount { get; set; }

        [Required]
        public double ShippingAmount { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        [Required]
        public string ShippingAddress { get; set; }
    }
}
