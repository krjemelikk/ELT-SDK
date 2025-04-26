using System;
using ELTSDK.Source.Services.Interfaces;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorGameplayMarkupService : IGameplayMarkupService
   {
      public event Action<bool> VisibilityChanged;

      public void GameReady()
      {
      }
   }
}