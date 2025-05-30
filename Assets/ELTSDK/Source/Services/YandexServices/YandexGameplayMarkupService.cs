﻿using System;
using System.Runtime.InteropServices;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;

namespace ELTSDK.Source.Services.YandexServices
{
   internal class YandexGameplayMarkupService : SingletonBehaviour<YandexGameplayMarkupService>, IGameplayMarkupService
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();

      public void GameReady() =>
         GameReadyExtern();

      public event Action<bool> VisibilityChanged;

      public void OnVisibilityChanged(string visibility)
      {
         if (bool.TryParse(visibility, out var value))
            VisibilityChanged?.Invoke(value);
      }
   }
}