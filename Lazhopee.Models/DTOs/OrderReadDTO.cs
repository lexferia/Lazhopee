namespace Lazhopee.Models.DTOs
{
    public class OrderReadDTO
    {
        public Guid Id { get; set; }

        public IEnumerable<OrderItemReadDTO> Items { get; set; }

        public int StatusId { get; set; }

        public string StatusDesc { get; set; }

        public string CouponCode { get; set; }

        public double SubTotal { get; set; }

        public double DiscountAmount { get; set; }

        public double TaxAmount { get; set; }

        public double ShippingAmount { get; set; }

        public double TotalAmount { get; set; }

        public string ShippingAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
