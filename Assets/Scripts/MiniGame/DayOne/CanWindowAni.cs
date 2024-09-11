using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanWindowAni : MonoBehaviour
{
    
    public GameObject windowCollider;
    public GameObject windowTip;
    public bool flag=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (SceneDataManager.Instance.isWindowDone)
            {
                windowTip.SetActive(false);
                windowCollider.SetActive(true);
                
            }
      
       

    }
}
