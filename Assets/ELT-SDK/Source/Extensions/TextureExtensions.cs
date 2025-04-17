using UnityEngine;

namespace ELT_SDK.Source.Extensions
{
   public static class TextureExtensions
   {
      public static Sprite ToSprite(this Texture texture) =>
         Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
   }
}