namespace Lazhopee.Models.DTOs
{
    public  class ProductReadDTO
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int StatusId { get; set; }

        public string StatusDesc { get; set; }

        public int Quantity { get; set; }

        public double DefaultPrice { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
