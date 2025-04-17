using ELTSDK.Source.Services;
using ELTSDK.Source.Services.EditorServices;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Services.YandexServices;
using ELTSDK.Source.Utilities;
using UnityEngine;

namespace ELTSDK.Source
{
   public class ELTSDKBootstrap : SingletonBehaviour<ELTSDKBootstrap>
   {
      public IAdvertisementService Advertisement { get; private set; }
      public IEnvironmentService Environment { get; private set; }
      public IFeedbackService FeedbackService { get; private set; }
      public IGameplayMarkupService GameplayMarkupService { get; private set; }
      public ILeaderboardService LeaderboardService { get; private set; }
      public IProductService ProductService { get; private set; }
      public IPurchaseService PurchaseService { get; private set; }
      public IRemoteConfigService RemoteConfigService { get; private set; }
      public ISaveLoadService SaveLoadService { get; private set; }

      private WebRequestService _webRequestService;

      public void Start()
      {
         RegisterServicesByPlatform();
      }

      private void RegisterServicesByPlatform()
      {
         switch (Application.platform)
         {
            case RuntimePlatform.WebGLPlayer:
               Advertisement = gameObject.AddComponent<YandexAdvertisementService>();
               Environment = gameObject.AddComponent<YandexEnvironmentService>();
               FeedbackService = gameObject.AddComponent<YandexFeedbackService>();
               GameplayMarkupService = gameObject.AddComponent<YandexGameplayMarkupService>();
               LeaderboardService = gameObject.AddComponent<YandexLeaderboardService>();
               ProductService = gameObject.AddComponent<YandexProductService>();
               PurchaseService = gameObject.AddComponent<YandexPurchaseService>();
               RemoteConfigService = gameObject.AddComponent<YandexRemoteConfigService>();
               SaveLoadService = gameObject.AddComponent<YandexSaveLoadService>();
               break;
            case RuntimePlatform.WindowsEditor:
               Advertisement = new EditorAdvertisementService();
               Environment = new EditorEnvironmentService();
               FeedbackService = new EditorFeedbackService();
               GameplayMarkupService = new EditorGameplayMarkupService();
               LeaderboardService = new EditorLeaderboardService();
               ProductService = new EditorProductsService();
               PurchaseService = new EditorPurchasesService();
               RemoteConfigService = new EditorRemoteConfigService();
               SaveLoadService = new EditorSaveLoadService();
               break;
         }

         _webRequestService = gameObject.AddComponent<WebRequestService>();
      }
   }
}