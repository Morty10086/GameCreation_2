using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LianDragFlag : MonoBehaviour
{
    public int dragFlog;
    //��ʼλ��
    public Vector3 startPos;
    void Start()
    {
        startPos = this.transform.position;
    }



}
