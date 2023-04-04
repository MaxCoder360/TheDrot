using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class Observable<T> where T : class
    {
        public void notify(Result<T> result, string tag)
        {
            ObservableStorage storage = ObservableStorage.storage;
            storage.notifyObservers(tag, result);
        }
        public void addObserver(Observer observer, string tag)
        {
            ObservableStorage storage = ObservableStorage.storage;
            storage.addObserver(tag, observer);
        }
    }

    public interface Observer
    {
        void handleResult<ResultT>(Result<ResultT> result) where ResultT : class;
    }

    public class ObservableStorage
    { 
        private Dictionary<string, List<Observer>> observers = new Dictionary<string, List<Observer>>();
        public static ObservableStorage storage = null;

        public static void initialize()
        {
            if (storage == null)
            {
                storage = new ObservableStorage();
            }
        }

        public void addObserver(string observableTag, Observer observer)
        {
            if (!observers.ContainsKey(observableTag))
            {
                observers.Add(observableTag, new List<Observer>());
            }

            observers[observableTag].Add(observer);
        }

        public void removeObserver(string observableTag, Observer observer)
        {
            int observerPosition = -1;
            for (int i = 0; i < observers[observableTag].Count; i++)
            {
                Observer curObserver = observers[observableTag][i];
                if (curObserver == observer)
                {
                    observerPosition = i;
                }
            }

            if (observerPosition == -1)
            {
                Logger.println("Given object is not observer of observable");
            }

            observers[observableTag].RemoveAt(observerPosition);
        }

        public void notifyObservers<T>(string observableTag, Result<T> result) where T : class
        {
            foreach (Observer observer in observers[observableTag])
            {
                observer.handleResult(result);
            }
        }

        private ObservableStorage()
        {

        }
    }
}
