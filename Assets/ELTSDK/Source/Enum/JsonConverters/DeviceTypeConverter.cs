using System;
using Newtonsoft.Json;

namespace ELTSDK.Source.Enum.JsonConverters
{
   public class DeviceTypeConverter : JsonConverter<DeviceType>
   {
      public override DeviceType ReadJson(
         JsonReader reader, 
         Type objectType, 
         DeviceType existingValue, 
         bool hasExistingValue, 
         JsonSerializer serializer)
      {
         string value = reader.Value.ToString().ToLower();
         
         return value switch
         {
            "desktop" => DeviceType.Desktop,
            "mobile" => DeviceType.Mobile,
            "tablet" => DeviceType.Tablet,
            "tv" => DeviceType.TV,
            _ => DeviceType.Mobile
         };
      }

      public override void WriteJson(JsonWriter writer, DeviceType value, JsonSerializer serializer)
      {
         string deviceString = value switch
         {
            DeviceType.Desktop => "desktop",
            DeviceType.Mobile => "mobile",
            DeviceType.Tablet => "tablet",
            DeviceType.TV => "tv",
            _ => "mobile"
         };

         writer.WriteValue(deviceString);
      }
   }
}