using asp_dotnet_getstarted.Models;
using System.Text.Json;

namespace asp_dotnet_getstarted.Services
{
    public class JsonProductService
    {
        public IWebHostEnvironment _webHostEnvironment { get; private set; }
        public string ProductsJsonDataFilePath { get; private set; }

        public JsonProductService(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Product> GetProducts()
        {
             ProductsJsonDataFilePath = Path.Combine(
                this._webHostEnvironment.WebRootPath,
                "data",
                "products.json"
                ).Normalize();

            string jsonDataAsString = File.ReadAllText(ProductsJsonDataFilePath);

            IEnumerable<Product>? products = JsonSerializer.Deserialize<IEnumerable<Product>>(jsonDataAsString, 
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }
                );

            if (null == products)
            {
                return new List<Product>();
            }
            else
            {
                return products;
            }
        }

        public void AddRating(string productId, int rating)
        {
            IEnumerable<Product> products = GetProducts();
            Product product = products.First(p => p.Id == productId);

            if(product != null)
            {
                int[] ratings = product.Ratings;

                if(ratings == null)
                {
                    int[] newRatings = new int[] { rating };
                    product.Ratings = newRatings;
                }
                else
                {
                    List<int> ratingsList = product.Ratings.ToList();
                    ratingsList.Add(rating);
                    product.Ratings = ratingsList.ToArray();
                }

            }

            using (var outputStream = File.OpenWrite(ProductsJsonDataFilePath))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                    );
            }

        }
    }
}
