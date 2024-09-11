using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwoGameThree : MonoBehaviour
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
        dragObj = GameObject.FindGameObjectsWithTag("drag");
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectAtMousePosition())
            {
                audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
                audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
                audioSource.Play();
                Clik(ObjectAtMousePosition().gameObject);
            }
        }
        Check();


    }

    private void Clik(GameObject clikObj)
    {
        if (!clikObj.gameObject.CompareTag("drag"))
        {
            return;
        }

        for (int i = 0; i < dropObj.Length; i++)
        {
            if (dropObj[i].GetComponent<LianDropFlag>().dropFlag ==
                clikObj.GetComponent<LianDragFlag>().dragFlog)
            {
                Color color = dropObj[i].GetComponent<SpriteRenderer>().color;
                dropObj[i].GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 255);
                dragObj[0].SetActive(false);
            }
        }
    }

    public void Check()
    {
        DayTwoGamePanel.threeFinsh = true;
        for (int i = 0; i < dropObj.Length; i++)
        {
            if (dropObj[i].GetComponent<SpriteRenderer>().color.a != 255)
            {
                DayTwoGamePanel.threeFinsh = false;
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
