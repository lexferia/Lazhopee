namespace Lazhopee.Models.DTOs
{
    public class OrderItemReadDTO
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductStatusId { get; set; }

        public string ProductStatusDesc { get; set; }

        public bool IsProductDeleted { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
