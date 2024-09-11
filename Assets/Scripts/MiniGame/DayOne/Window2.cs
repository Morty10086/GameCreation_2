using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window3 : MonoBehaviour
{

    public static bool  isFinish;
    //标签
    public string myTag;
    //记录可以更换的几张图
    public GameObject[] swapObj;
    //当前显示的是数组中第几个
    public int index = 0;
    //鼠标位置的世界坐标
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    void Start()
    {
        
    }

    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            if(ObjectAtMousePosition()!=null&&ObjectAtMousePosition().gameObject.CompareTag(myTag))
            {
                if (index >= swapObj.Length - 1)
                {
                    swapObj[index].SetActive(false);
                    swapObj[0].SetActive(true);
                    index = 0;
                }
                else
                {
                    swapObj[index].SetActive(false);
                    swapObj[index + 1].SetActive(true);
                    index++;
                }

            }
        }

        if (swapObj[swapObj.Length-1].activeSelf)
        {
            Window.Instance.isFinishi2=true;
        }
        else
        {
            Window.Instance.isFinishi2 = false;
        }
    }



    //返回鼠标点击碰撞信息
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
