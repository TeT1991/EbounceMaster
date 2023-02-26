using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public bool IsDontDestroyOnLoad = false;

    public static T Instance
    { 
        get
        {
            if(_instance == null)
            {
                T[] instances = FindObjectsOfType<T>();

                if(instances.Length == 0)
                {
                    Debug.LogError("—»Õ√À“ŒÕ ÌÂ Ì‡È‰ÂÌ");
                }
                else
                {
                    _instance = instances[0];
                    return _instance;
                }
                if(_instance == null)
                {
                    GameObject singleton = new GameObject($"[SINGLETON] {nameof(T)}");
                    _instance = singleton.AddComponent<T>();
                    return _instance; 
                }
            }
            return _instance;
        } 
        private set
        {
            _instance=value;    
        }
    }

    public virtual void Awake()
    {
        if (_instance == null) _instance = this as T;
        else Destroy(gameObject);

        if (IsDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
    }
}
