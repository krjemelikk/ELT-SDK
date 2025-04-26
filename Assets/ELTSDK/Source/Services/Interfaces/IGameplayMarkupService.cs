using System;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IGameplayMarkupService
   {
      event Action<bool> VisibilityChanged;
      void GameReady();
   }
}