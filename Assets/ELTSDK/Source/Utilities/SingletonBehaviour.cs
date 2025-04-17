using UnityEngine;

namespace ELTSDK.Source.Utilities
{
   public abstract class SingletonBehaviour<T> : MonoBehaviour where T : class
   {
      public static T Instance { get; private set; }

      private void Awake()
      {
         if (Instance == null)
         {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
         }

         else
            Destroy(this);
      }
   }
}