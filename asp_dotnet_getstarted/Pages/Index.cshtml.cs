using asp_dotnet_getstarted.Models;
using asp_dotnet_getstarted.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_dotnet_getstarted.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonProductService _jsonProductService;
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonProductService jsonProductService
            
            )
        {
            _logger = logger;
            this._jsonProductService = jsonProductService;
        }

        public void OnGet()
        {
            this.Products = this._jsonProductService.GetProducts();   
        }
    }
}