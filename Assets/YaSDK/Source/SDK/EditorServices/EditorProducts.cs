using System.Collections;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.EditorServices
{
   public class EditorProducts : IProductDataService
   {
      public IEnumerator LoadProductData()
      {
         YandexSDKData.Instance.ProductData.Products =
            YandexSDKData.Instance.ProductData.EditorProducts.ToDictionary();

         yield return null;
      }
   }
}