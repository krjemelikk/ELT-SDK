using System.Collections.Generic;
using ELT_SDK.Source.Data;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices.Utilities
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