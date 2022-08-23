using System.ComponentModel.DataAnnotations;

namespace Lazhopee.Models.DTOs
{
    public class OrderItemUpdateDTO
    {
        [Required(ErrorMessage = "Please enter a product id")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
