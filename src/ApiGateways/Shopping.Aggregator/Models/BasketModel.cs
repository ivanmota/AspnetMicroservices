namespace Shopping.Aggregator.Models
{
    public class BasketModel
    {
        public string UserName { get; set; } = string.Empty;
        public List<BasketItemExtendedModel> Items = new List<BasketItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}
