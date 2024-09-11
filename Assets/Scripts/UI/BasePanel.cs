using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:BasePanel<T>
{
    private static BasePanel<T> instance;
    public static BasePanel<T> Instance => instance as T;

    protected virtual void Awake()
    {
        instance = this;
    }
    
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
}
