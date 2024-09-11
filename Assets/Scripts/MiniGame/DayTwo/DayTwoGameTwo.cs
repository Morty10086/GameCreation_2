using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwoGameTwo : MonoBehaviour
{
    

    public AudioSource audioSource;
    //鼠标位置的世界坐标
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //记录当前选中拼图的放下位置
    private Vector3 nowDropPos;
    //选中拼图和落点的最小距离
    private float minDis = 5;
    //记录有无拼图被选中
    private GameObject selectedObj;
    //移动过程中的实时位置
    private Vector3 movePos;

    //拼图预制体
    GameObject[] dragObj;
    //记录拼图应该放的点
    GameObject[] dropObj;
    void Start()
    {
        dragObj = GameObject.FindGameObjectsWithTag("drag");
        dropObj = GameObject.FindGameObjectsWithTag("drop");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObj == null)
            {
                if (ObjectAtMousePosition())
                {
                    
                    Clik(ObjectAtMousePosition().gameObject);
                }
            }
            else
            {
                
                movePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObj.transform.position).z));
                Adsorb();
                selectedObj = null;
                Cursor.visible = true;
            }
        }
        if (selectedObj != null)
        {
            movePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObj.transform.position).z));
            selectedObj.transform.position = movePos;
            
        }

        Check();
    }

    //鼠标点击拾起拼图
    private void Clik(GameObject clikObj)
    {
        if (!clikObj.CompareTag("drag"))
        {
            return;
        }
        this.selectedObj = clikObj;
        Cursor.visible = false;
    }

    //返回鼠标点击碰撞信息
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    //吸附功能
    private void Adsorb()
    {
        foreach (var item in dropObj)
        {
            if (Vector3.Distance(item.transform.position, movePos) <= minDis)
            {
                minDis = Vector3.Distance(item.transform.position, movePos);
                nowDropPos = item.transform.position;
            }
        }
        if (minDis < 0.4f)
        {
            selectedObj.transform.position = nowDropPos;
            minDis = 5;
        }
        else
        {
            selectedObj.transform.position = movePos;
            minDis = 5;
        }
    }


    //检测拼图是否完成
    private void Check()
    {
        DayTwoGamePanel.twoFinsh = true;
        Vector3 dragPos;
        Vector3 dropPos;
        for (int i = 0; i < dropObj.Length; i++)
        {
            dragPos = dragObj[i].transform.position;
            dropPos = dropObj[i].transform.position;
            if (dragPos == dropPos)
            {
                //audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
                //audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
                //audioSource.Play();
                dragObj[i].SetActive(false);
                dropObj[i].SetActive(false);

            }
            else
            {
   
                DayTwoGamePanel.twoFinsh = false;
                break;
            }
        }
    }
}
