using System;
using System.Collections.Generic;
using ELTSDK.Source.Services.EditorServices;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Services.YandexServices;
using UnityEngine;

namespace ELTSDK.Source.Factory
{
   internal class ServiceFactory : IServiceFactory
   {
      private readonly RuntimePlatform _platform;
      private readonly ELTSDKRoot _root;
      private readonly Dictionary<Type, Func<object>> _factories;

      public ServiceFactory(ELTSDKRoot root, RuntimePlatform platform)
      {
         _root = root;
         _platform = platform;

         _factories = new Dictionary<Type, Func<object>>()
         {
            {typeof(IAdvertisementService), CreateService<EditorAdvertisementService, YandexAdvertisementService>},
            {typeof(IEnvironmentService), CreateService<EditorEnvironmentService, YandexEnvironmentService>},
            {typeof(IFeedbackService), CreateService<EditorFeedbackService, YandexFeedbackService>},
            {typeof(IGameplayMarkupService), CreateService<EditorGameplayMarkupService, YandexGameplayMarkupService>},
            {typeof(ILeaderboardService), CreateService<EditorLeaderboardService, YandexLeaderboardService>},
            {typeof(IIAPService), CreateService<EditorIAPService, YandexIAPService>},
            {typeof(IRemoteConfigService), CreateService<EditorRemoteConfigService, YandexRemoteConfigService>},
            {typeof(ISaveLoadService), CreateService<EditorSaveLoadService, YandexSaveLoadService>},
         };
      }

      public T Create<T>() where T : class =>
         _factories[typeof(T)].Invoke() as T;

      private object CreateService<TEditor, TYandex>()
         where TEditor : class, new()
         where TYandex : Component
      {
         switch (_platform)
         {
            case RuntimePlatform.WebGLPlayer:
               return _root.gameObject.AddComponent<TYandex>();

            case RuntimePlatform.WindowsEditor:
            default:
               return new TEditor();
         }
      }
   }
}