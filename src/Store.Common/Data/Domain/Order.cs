namespace Store.Common.Data.Domain
{
    public sealed class Order
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}