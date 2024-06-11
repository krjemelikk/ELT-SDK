using System.Collections.Generic;
using UnityEngine;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Services.EditorServices.Utilities
{
   public class EditorSDKSettings : MonoBehaviour
   {
      [SerializeField] private EnvironmentData _environmentData;
      
      [Space]
      [SerializeField] private List<ProductData> _products;
      
      public EnvironmentData EnvironmentData => _environmentData;
      public List<ProductData> Products => _products;
   }
}