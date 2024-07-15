using System.Collections;
using System.Collections.Generic;
using ELT_SDK.Source.Data;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IProductDataService
   {
      IEnumerator LoadProductData();
      ProductData GetProduct(string id);
      List<ProductData> GetAllProducts();
   }
}