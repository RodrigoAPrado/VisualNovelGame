using System;
namespace Csharp.Service.Super
{
    public abstract class SingletonService<T> where T : new()
    {
        private static T instance;

        public static T GetInstance() {
            if(instance == null) {
                instance = new T();
            }
            return instance;
        } 

        protected static void ValidateSingleton() {
            if(instance != null) {
                throw new InvalidOperationException();
            }   
        }
    }
}