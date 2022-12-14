using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>:GameBehaiour where T:MonoBehaviour
{
    public bool DontDestroy;
    private static T instance_;
    public static T instance
    
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake ()
    { 
        if (instance_ == null )
        {
            instance_ =this as T;
            if (DontDestroy == true)
            {
                DontDestroyOnLoad(gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


