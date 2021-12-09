using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System.Net;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService,
            IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            // iterate basket items and consume products with basket item productId number
            // map product related members into baskettime dto with extended columns
            // consume ordering microservices in order to retrieve order list
            // return root ShoppingModel dto class which including all responses

            var basket = await _basketService.GetBasketAsync(userName);
            if (basket != null)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _catalogService.GetCatalogByIdAsync(item.ProductId);

                    if (product != null)
                    {
                        // set additional produc fields onto basket item
                        item.ProductName = product.Name;
                        item.Category = product.Category;
                        item.Summary = product.Summary;
                        item.Description = product.Description;
                        item.ImageFile = product.ImageFile;
                    }
                }
            }

            var orders = await _orderService.GetOrderByUserNameAsync(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}
