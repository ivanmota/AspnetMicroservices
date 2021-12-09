namespace Shopping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; } = string.Empty;
        public BasketModel? BasketWithProducts { get; set; } = null!;
        public IEnumerable<OrderResponseModel>? Orders { get; set; } = null!;
    }
}
