using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ELT_SDK.Source.Data;
using ELT_SDK.Source.SDK.Services.Interfaces;

namespace ELT_SDK.Source.SDK.Services.EditorServices
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