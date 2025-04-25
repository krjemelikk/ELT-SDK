namespace ELTSDK.Source.Factory
{
   internal interface IServiceFactory
   {
      T Create<T>() where T : class;
   }
}