using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Services
{
    public class InMemoryProductService : IProductService
    {
        private readonly IList<Product> _products;

        public InMemoryProductService(IEnumerable<Product> initialProducts)
        {
            _products = new List<Product>(initialProducts);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.ToArray();
        }

        public void AddRating(string productId, int rating)
        {
            var product = _products.First(x => x.Id == productId);

            if (product.Ratings == null)
            {
                product.Ratings = new int[] { rating };
            }
            else
            {
                product.Ratings = product.Ratings.Concat(new[] { rating }).ToArray();
            }
        }
    }
}
