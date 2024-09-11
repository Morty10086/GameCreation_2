using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOneGame3 : MonoBehaviour
{
    public AudioSource audioSource;

    //
    Vector3 cameraPos;
    //是否完成
    public bool isFinish;
    //要卸载的场景
    public string sceneFrom;
    //要加载的场景
    public string sceneToGO;
    //记录三个空格位置
    public Transform leftPos;
    public Transform middlePos;
    public Transform rightPos;
    //记录当前三个位置的物体
    private GameObject leftObj;
    private GameObject middleObj;
    private GameObject rightObj;
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
        this.Check();
    }

    public void LeftSwapPos()
    {
        foreach (GameObject obj in dragObj)
        {
            if(obj.transform.position==leftPos.position)
            {
                leftObj=obj;
            }
            if(obj.transform.position==middlePos.position)
            {
                middleObj=obj;
            }
        }
        Vector3 tmpPos=new Vector3();
        tmpPos=leftObj.transform.position;
        leftObj.transform.position=middleObj.transform.position;
        middleObj.transform.position=tmpPos;
    }

    public void RightSwapPos()
    {
        foreach (GameObject obj in dragObj)
        {
            if (obj.transform.position == rightPos.position)
            {
                rightObj=obj;
            }
            if (obj.transform.position == middlePos.position)
            {
                middleObj = obj;
            }
        }
        Vector3 tmpPos = new Vector3();
        tmpPos = rightObj.transform.position;
        rightObj.transform.position = middleObj.transform.position;
        middleObj.transform.position = tmpPos;
    }

    private void Check()
    {
        DayOne.Instance.gameThreeFinish = true;
        Vector3 dragPos;
        Vector3 dropPos;
        for (int i = 0; i < dropObj.Length; i++)
        {
            dragPos = dragObj[i].transform.position;
            dropPos = dropObj[i].transform.position;
            if (dragPos != dropPos)
            {
                DayOne.Instance.gameThreeFinish = false;
                break;
            }
        }

        //if(isFinish)
        //{
        //    TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
        //    SceneDataManager.Instance.isWork1Done = true;
        //}
    }

    public void PlayAudio()
    {
        audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
        audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
        audioSource.Play();
    }

}
