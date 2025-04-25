using ELTSDK.Source.Factory;
using ELTSDK.Source.Loggers;
using ELTSDK.Source.Services;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;
using UnityEngine;

namespace ELTSDK.Source
{
   public class ELTSDKRoot : SingletonBehaviour<ELTSDKRoot>
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

      public void Initialize()
      {
         var serviceFactory = new ServiceFactory(this, Application.platform);

         Advertisement = new AdvertisementServiceLogger(serviceFactory.Create<IAdvertisementService>());
         Environment = new EnvironmentServiceLogger(serviceFactory.Create<IEnvironmentService>());
         FeedbackService = new FeedbackServiceLogger(serviceFactory.Create<IFeedbackService>());
         GameplayMarkupService = new GameplayMarkupServiceLogger(serviceFactory.Create<IGameplayMarkupService>());
         LeaderboardService = new LeaderboardServiceLogger(serviceFactory.Create<ILeaderboardService>());
         ProductService = new ProductServiceLogger(serviceFactory.Create<IProductService>());
         PurchaseService = new PurchaseServiceLogger(serviceFactory.Create<IPurchaseService>());
         RemoteConfigService = new RemoteConfigServiceLogger(serviceFactory.Create<IRemoteConfigService>());
         SaveLoadService = new SaveLoadServiceLogger(serviceFactory.Create<ISaveLoadService>());

         _webRequestService = gameObject.AddComponent<WebRequestService>();
      }
   }
}