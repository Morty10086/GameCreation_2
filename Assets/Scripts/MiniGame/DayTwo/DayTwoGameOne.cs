using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwoGameOne : MonoBehaviour
{
    public AudioSource audioSource;
    //鼠标位置的世界坐标
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    //拼图预制体
    GameObject[] dragObj;
    //记录拼图应该放的点
    GameObject[] dropObj;
    // Start is called before the first frame update
    void Start()
    {
        dragObj = GameObject.FindGameObjectsWithTag("drag");
        dropObj = GameObject.FindGameObjectsWithTag("drop");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(ObjectAtMousePosition())
            {
                
                Clik(ObjectAtMousePosition().gameObject);
            }
        }
        Check();

        
    }

    private void Clik(GameObject clikObj)
    {
        if(!clikObj.gameObject.CompareTag("drag"))
        {
            return;
        }

        for(int i=0;i<dropObj.Length;i++)
        {
            if (dropObj[i].GetComponent<LianDropFlag>().dropFlag==
                clikObj.GetComponent<LianDragFlag>().dragFlog)
            {
                audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
                audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
                audioSource.Play();
                Color color = dropObj[i].GetComponent<SpriteRenderer>().color;
                dropObj[i].GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,255);
            }
        }
    }

    public void Check()
    {
        DayTwoGamePanel.oneFinsh = true;
        for (int i = 0; i < dropObj.Length; i++)
        {
            if (dropObj[i].GetComponent<SpriteRenderer>().color.a != 255)
            {
                DayTwoGamePanel.oneFinsh = false;
                break;
            }
        }
    }

    //返回鼠标点击碰撞信息
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
