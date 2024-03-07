using System.Collections;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.EditorServices
{
   internal class EditorProducts : IProductDataService
   {
      public IEnumerator LoadProductData()
      {
         YandexSDKData.Instance.ProductData.Products =
            YandexSDKData.Instance.ProductData.EditorProducts.ToDictionary();

         yield return null;
      }
   }
}