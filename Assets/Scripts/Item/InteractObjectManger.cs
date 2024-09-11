using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectManger : MonoBehaviour
{
    #region 单例
    //声明为单例
    private static InteractObjectManger instance;
    private InteractObjectManger() { }
    public static InteractObjectManger Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
