using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBeginScene : MonoBehaviour
{
    Vector3 v;
    private void Awake()
    {
        
    }
    void Start()
    {
        
        TeleportManager.Instance.ToScene(string.Empty, "BeginScene",v);
    }

  
}
