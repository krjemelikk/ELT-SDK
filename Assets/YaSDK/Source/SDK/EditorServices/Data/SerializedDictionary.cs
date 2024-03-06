using System;
using System.Collections.Generic;
using System.Linq;

namespace YaSDK.Source.SDK.EditorServices.Data
{
   [Serializable]
   public class SerializedDictionary<TKey, TValue>
   {
      public List<SerializedDictionaryItem<TKey, TValue>> Dictionary;

      public Dictionary<TKey, TValue> ToDictionary() =>
         Dictionary.ToDictionary(item => item.Key, item => item.Value);
   }

   [Serializable]
   public class SerializedDictionaryItem<TKey, TValue>
   {
      public TKey Key { get; set; }
      public TValue Value { get; set; }
   }
}