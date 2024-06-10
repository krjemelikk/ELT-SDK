using System.Collections;
using System.Collections.Generic;
using YaSDK.Source.Data;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.EditorServices
{
   internal class EditorProducts : IProductDataService
   {
      public IEnumerator LoadProductData()
      {
         yield return null;
      }

      public ProductData GetProduct(string id)
      {
         throw new System.NotImplementedException();
      }

      public List<ProductData> GetAllProducts()
      {
         throw new System.NotImplementedException();
      }
   }
}