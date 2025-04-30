mergeInto(LibraryManager.library, {

   // Advertisement
   ShowInterstitialAdExtern: function () {
      ysdk.adv.showFullscreenAdv({
         callbacks: {
            onOpen: () => {
               gameInstance.SendMessage("ELTSDK", "OnAdOpen");
            },

            onClose: (wasShown) => {
               gameInstance.SendMessage("ELTSDK", "OnAdClose");
            },
         }
      })
   },

   ShowRewardedAdExtern: function () {
      ysdk.adv.showRewardedVideo({
         callbacks: {
            onOpen: () => {
               gameInstance.SendMessage("ELTSDK", "OnAdOpen");
            },

            onRewarded: () => {
               gameInstance.SendMessage("ELTSDK", "OnRewardedAdShown");
            },

            onClose: () => {
               gameInstance.SendMessage("ELTSDK", "OnAdClose");
            },
         }
      })
   },

   ShowAdBannerExtern: function () {
      ysdk.adv.showBannerAdv();
   },

   HideAdBannerExtern: function () {
      ysdk.adv.hideBannerAdv();
   },

   // Environment
   LoadEnvironmentDataExtern: function () {
      var environmentData = {
         DeviceType: ysdk.deviceInfo.type,
         Language: ysdk.environment.i18n.lang,
      };

      var json = JSON.stringify(environmentData);
      gameInstance.SendMessage("ELTSDK", "OnEnvironmentDataLoaded", json);
   },

   // Feedback
   ReviewRequestExtern: function () {
      ysdk.feedback.canReview()
         .then(({value, reason}) => {
            if (value) {
               ysdk.feedback.requestReview()
                  .then(({feedbackSent}) => {
                     gameInstance.SendMessage("ELTSDK", "OnFeedbackSent");
                  })
            } else {
               console.log(reason)
            }
         })
   },

   // Gameplay markup
   GameReadyExtern: function () {
      ysdk.features.LoadingAPI.ready();
   },

   // Leaderboards
   SetScoreToLeaderboardExtern: function (leaderboardName, value) {
      var lbName = UTF8ToString(leaderboardName);

      ysdk.isAvailableMethod('leaderboards.setLeaderboardScore').then(isAvailable => {
         if (isAvailable) {
            ysdk.getLeaderboards().then(lb => {
               lb.setLeaderboardScore(lbName, value);
               gameInstance.SendMessage("ELTSDK", "OnLeaderboardScoreSet", JSON.stringify(lbName));
            });
         }
      });
   },

   LoadLeaderboardExtern: function (leaderboardName) {
      var lbName = UTF8ToString(leaderboardName);

      var isPlayerAuthorized = player.getMode() !== 'lite';
      var playerId = "undefined";

      if (isPlayerAuthorized === true) {
         playerId = player.getUniqueID();
      }

      ysdk.getLeaderboards().then(lb => {
         lb.getLeaderboardEntries(lbName, {quantityTop: 10, includeUser: isPlayerAuthorized, quantityAround: 0})
            .then(res => {
               var leaderboardEntries = [];
               for (i = 0; i < res.entries.length; i++) {

                  let leaderboardEntry = {
                     Rank: res.entries[i].rank,
                     Score: res.entries[i].score,
                     Name: res.entries[i].player.publicName,
                     IsPlayer: res.entries[i].player.uniqueID === playerId,
                  }
                  console.log(res.entries[i].player.uniqueID);
                  leaderboardEntries.push(leaderboardEntry);
               }

               var json = JSON.stringify({
                  Name: lbName,
                  Entries: leaderboardEntries,
               });

               gameInstance.SendMessage("ELTSDK", "OnLeaderboardLoaded", json);
            });
      });
   },

   // IAP
   LoadAllProductDataExtern: function () {
      var productList = [];
      payments.getCatalog().then(products => {
         for (i = 0; i < products.length; i++) {

            let product = {
               Id: products[i].id,
               Price: products[i].priceValue,
               Title: products[i].title,
               Description: products[i].description,
               CurrencyImageURL: products[i].getPriceCurrencyImage('medium'),
            }

            productList.push(product);
         }

         var json = JSON.stringify(productList);
         console.log(json)
         gameInstance.SendMessage("ELTSDK", "OnProductDataLoaded", json);
      });
   },
   
   PurchaseExtern: function (productId, withConsume) {
      payments.purchase(UTF8ToString(productId)).then(purchase => {
         var json = JSON.stringify({
            ProductId: purchase.productID,
            Token: purchase.purchaseToken,
            WithConsume: withConsume,
         });

         gameInstance.SendMessage("ELTSDK", "OnPurchaseComplete", json);
      }).catch(err => {
         console.log('Purchase Failed', err.message);
      })
   },

   CheckPurchaseExtern: function (productId, withConsume) {
      var purchaseId = UTF8ToString(productId);

      payments.getPurchases().then(purchases => {
         var purchase = purchases.find(purchase => purchase.productID === purchaseId);

         if (purchase) {
            var json = JSON.stringify({
               ProductId: purchase.productID,
               Token: purchase.purchaseToken,
               WithConsume: withConsume,
            });

            gameInstance.SendMessage("ELTSDK", "OnPurchaseComplete", json);
         }
      }).catch(err => {
         console.log('Check Purchase Failed', err.message);
      })
   },

   ConsumePurchaseExtern: function (token) {
      payments.consumePurchase(UTF8ToString(token));
   },

   // Configs
   LoadConfigsExtern: function () {
      ysdk.getFlags().then(flags => {
         gameInstance.SendMessage("ELTSDK", "OnConfigsLoaded", JSON.stringify(flags));
      });
   },

   // Save Load
   SaveExtern: function (data) {
      var json = JSON.stringify(UTF8ToString(data));
      player.setData(json).then(() => {
         console.log('Saved');
      });
   },

   LoadExtern: function () {
      player.getData().then(data => {
         gameInstance.SendMessage("ELTSDK", "OnLoaded", JSON.stringify(data));
      });
   },
});