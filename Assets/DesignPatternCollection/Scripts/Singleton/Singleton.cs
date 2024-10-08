using UnityEngine;

namespace DesignPattern.SingletonPattern
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject gameObject = new GameObject();
                        gameObject.name = typeof(T).Name;
                        _instance = gameObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
