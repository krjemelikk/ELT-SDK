using System.Collections;
using ELT_SDK.Source.SDK.Services.EditorServices;
using ELT_SDK.Source.SDK.Services.EditorServices.Utilities;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Unitilities;
using ELT_SDK.Source.Utilities;
using UnityEngine;

namespace ELT_SDK.Source.SDK
{
   public class ELTSDK : SingletonBehaviour<ELTSDK>
   {
#if UNITY_EDITOR
      [SerializeField] private EditorSDKSettings _editorSDKSettings;
#endif

      private IPurchaseHandler _purchaseHandler;
      public IGameReadyService GameReadyService { get; private set; }
      public IAdvertisementService AdvertisementService { get; private set; }
      public IEnvironmentService EnvironmentService { get; private set; }
      public ILeaderboardService LeaderboardService { get; private set; }
      public IPurchaseService PurchaseService { get; private set; }
      public IProgressService ProgressService { get; private set; }
      public IProductDataService ProductsService { get; private set; }

      private void Awake() =>
         DontDestroyOnLoad(this);

      public IEnumerator Initialize()
      {
#if UNITY_EDITOR
         GameReadyService = new EditorGameReady();
         AdvertisementService = new EditorAdvertisement();
         EnvironmentService = new EditorEnvironment(_editorSDKSettings.EnvironmentData);
         LeaderboardService = new EditorLeaderboard();
         PurchaseService = new EditorPurchases();
         ProgressService = new EditorProgress();
         ProductsService = new EditorProducts(_editorSDKSettings.Products);
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
         GameReadyService = gameObject.AddComponent<YandexSDKGameReadyAPI>();
         AdvertisementService = gameObject.AddComponent<YandexSDKAdvertisement>();
         EnvironmentService = gameObject.AddComponent<YandexSDKEnvironment>();
         LeaderboardService = gameObject.AddComponent<YandexSDKLeaderboard>();
         PurchaseService = gameObject.AddComponent<YandexSDKPurchases>();
         ProgressService = gameObject.AddComponent<YandexSDKProgress>();
         ProductsService = gameObject.AddComponent<YandexSDKProducts>();
#endif
         _purchaseHandler = new PurchaseHandler(PurchaseService);
         _purchaseHandler.Initialize();

         yield return LoadAllData();
      }

      public void PauseGame()
      {
         Time.timeScale = 0;
         AudioListener.pause = true;
      }

      public void UnPauseGame()
      {
         Time.timeScale = 1;
         AudioListener.pause = false;
      }

      private void OnDisable() =>
         _purchaseHandler.CleanUp();

      private IEnumerator LoadAllData()
      {
         yield return ProductsService.LoadProductData();
         yield return ProgressService.LoadProgress();
         yield return EnvironmentService.LoadEnvironmentData();
      }
   }
}