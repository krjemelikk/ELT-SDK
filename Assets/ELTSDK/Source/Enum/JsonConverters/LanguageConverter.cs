using System;
using Newtonsoft.Json;

namespace ELTSDK.Source.Enum.JsonConverters
{
   public class LanguageConverter : JsonConverter<Language>
   {
      public override Language ReadJson(
         JsonReader reader,
         Type objectType,
         Language existingValue,
         bool hasExistingValue,
         JsonSerializer serializer)
      {
         string value = reader.Value.ToString().ToLower();

         return value switch
         {
            "en" => Language.English,
            "ru" => Language.Russian,
            "be" => Language.Russian,
            
            "tr" => Language.Turkish,
            "de" => Language.German,
            "es" => Language.Spanish,
            "ja" => Language.Japan,
            _ => Language.English
         };
      }

      public override void WriteJson(JsonWriter writer, Language value, JsonSerializer serializer)
      {
         string languageString = value switch
         {
            Language.English => "en",
            Language.Russian => "ru",
            
            Language.Turkish => "tr",
            Language.German => "de",
            Language.Spanish => "es",
            Language.Japan => "ja",
            _ => "en"
         };

         writer.WriteRawValue(languageString);
      }
   }
}