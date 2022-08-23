using Lazhopee.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lazhopee.Models.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string ProductDescription { get; set; }

        [Required]
        public int Status { get; set; } = (int)ProductStatus.InStock;

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(1.00, double.MaxValue)]
        public double DefaultPrice { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
