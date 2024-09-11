using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LianDragFlag : MonoBehaviour
{
    public int dragFlog;
    //ÆðÊ¼Î»ÖÃ
    public Vector3 startPos;
    void Start()
    {
        startPos = this.transform.position;
    }



}
