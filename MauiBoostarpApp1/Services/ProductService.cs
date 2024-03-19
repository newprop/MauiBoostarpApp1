using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiBoostarpApp1.Services
{
  public class ProductService
    {
        private readonly HttpClient http;

        private string apiLink = "/api/ProductCategories";

        public ProductService(HttpClient http)
        {
            http.BaseAddress = new Uri("https://localhost:7115/");
            this.http = http;
        }

        public async Task<IList<ProductCategory>?> GetAll()
        {
            var data = await this.http.GetFromJsonAsync<IList<ProductCategory>>(apiLink);
            return data;
        }
        public async Task<ProductCategory?> GetById(int id)
        {
            return await this.http.GetFromJsonAsync<ProductCategory>(apiLink + $"/{id}");
        }
        public async Task<HttpResponseMessage?> Save(ProductCategory data)
        {
            return await this.http.PostAsJsonAsync<ProductCategory>(apiLink, data);
        }
        public async Task<HttpResponseMessage?> Update(ProductCategory data)
        {
            return await this.http.PutAsJsonAsync<ProductCategory>(apiLink + $"/{data.ProductCategoryID}", data);
        }

        public async Task<HttpResponseMessage?> Delete(int id)
        {
            return await this.http.DeleteAsync(apiLink + $"/{id}");
        }

    }
}
