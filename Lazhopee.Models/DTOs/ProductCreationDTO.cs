using System.ComponentModel.DataAnnotations;

namespace Lazhopee.Models.DTOs
{
    public class ProductCreationDTO
    {
        [Required(ErrorMessage = "Please enter a product name")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string ProductName { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Please enter a product status")]
        public int Status { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(1.00, double.MaxValue, ErrorMessage = "Please enter a value greater than 1.00")]
        public double DefaultPrice { get; set; }
    }
}
