﻿using asp_dotnet_getstarted.Models;
using System.Text.Json;

namespace asp_dotnet_getstarted.Services
{
    public class JsonProductService
    {
        public IWebHostEnvironment _webHostEnvironment { get; private set; }

        public JsonProductService(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Product> GetProducts()
        {
            string productsJsonDataFilePath = Path.Combine(
                this._webHostEnvironment.WebRootPath,
                "data",
                "products.json"
                ).Normalize();

            string jsonDataAsString = File.ReadAllText(productsJsonDataFilePath);

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
    }
}