using System.ComponentModel.DataAnnotations;

namespace Lazhopee.Models.DTOs
{
    public class OrderUpdateDTO
    {
        [Required(ErrorMessage = "Please add atleast 1 item")]
        public IEnumerable<OrderItemUpdateDTO> Items { get; set; }

        [Required(ErrorMessage = "Please enter a order status")]
        public int Status { get; set; }

        public string CouponCode { get; set; }

        [Required(ErrorMessage = "Please enter a discount amount")]
        public double DiscountAmount { get; set; }

        [Required(ErrorMessage = "Please enter a shipping amount")]
        public double ShippingAmount { get; set; }

        [Required(ErrorMessage = "Please enter a shipping address")]
        public string ShippingAddress { get; set; }
    }
}
