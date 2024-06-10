using System.Collections;
using System.Collections.Generic;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Services.Interfaces
{
   public interface IProductDataService
   {
      IEnumerator LoadProductData();
      ProductData GetProduct(string id);
      List<ProductData> GetAllProducts();
   }
}