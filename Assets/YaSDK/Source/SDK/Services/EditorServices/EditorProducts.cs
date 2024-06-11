using System.Collections;
using System.Collections.Generic;
using System.Linq;
using YaSDK.Source.Data;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.EditorServices
{
   internal class EditorProducts : IProductDataService
   {
      private readonly Dictionary<string, ProductData> _products;

      public EditorProducts(List<ProductData> products) =>
         _products = products.ToDictionary(product => product.Id, product => product);

      public IEnumerator LoadProductData()
      {
         yield return null;
      }

      public ProductData GetProduct(string id) =>
         _products.GetValueOrDefault(id);

      public List<ProductData> GetAllProducts() =>
         _products.Values.ToList();
   }
}