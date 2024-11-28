using System;

namespace CarWashManager.BuisnessLogic.Singleton
{
    public class SingletonInstance // Змінено на public для глобального доступу
    {
        private static SingletonInstance? _instance;

        public SingletonInstance() { }

        public static SingletonInstance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonInstance();
                }
                return _instance;
            }
        }

        public void ExecuteAction()
        {
            Console.WriteLine("Executing an action in Singleton instance.");
        }
    }
}
