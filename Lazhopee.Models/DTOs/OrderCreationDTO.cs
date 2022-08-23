using System.ComponentModel.DataAnnotations;

namespace Lazhopee.Models.DTOs
{
    public class OrderCreationDTO
    {
        [Required(ErrorMessage = "Please add atleast 1 item")]
        public IEnumerable<OrderItemCreationDTO> Items { get; set; }

        public string CouponCode { get; set; }

        [Required(ErrorMessage = "Please enter a discount amount")]
        public double DiscountAmount { get; set; }

        [Required(ErrorMessage = "Please enter a shipping amount")]
        public double ShippingAmount { get; set; }

        [Required(ErrorMessage = "Please enter a shipping address")]
        public string ShippingAddress { get; set; }
    }
}
