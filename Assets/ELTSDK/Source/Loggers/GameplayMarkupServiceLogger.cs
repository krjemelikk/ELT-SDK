using System;
using ELTSDK.Source.Services.Interfaces;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class GameplayMarkupServiceLogger : IGameplayMarkupService, IDisposable
   {
      private const string Label = "<color=yellow><b>[Gameplay Markup]</b></color>";
      private readonly IGameplayMarkupService _service;

      public GameplayMarkupServiceLogger(IGameplayMarkupService service)
      {
         _service = service;
         VisibilityChanged += OnVisibilityChanged;
      }

      public event Action<bool> VisibilityChanged
      {
         add => _service.VisibilityChanged += value;
         remove => _service.VisibilityChanged -= value;
      }
      
      public void GameReady()
      {
         _service.GameReady();
         Debug.Log($"{Label} - Game Ready");
      }
      
      public void Dispose() =>
         VisibilityChanged -= OnVisibilityChanged;

      private void OnVisibilityChanged(bool visibility)
      {
         Debug.Log($"{Label} - Visibility status - {visibility}");
      }
   }
}