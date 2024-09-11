using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDayThree : MonoBehaviour
{
    public GameObject jingZiCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneDataManager.Instance.isWork2Done)
        {
            jingZiCollider.SetActive(true);
        }
    }
}
