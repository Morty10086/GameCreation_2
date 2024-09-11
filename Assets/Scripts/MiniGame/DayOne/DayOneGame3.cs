using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOneGame3 : MonoBehaviour
{
    public AudioSource audioSource;

    //
    Vector3 cameraPos;
    //�Ƿ����
    public bool isFinish;
    //Ҫж�صĳ���
    public string sceneFrom;
    //Ҫ���صĳ���
    public string sceneToGO;
    //��¼�����ո�λ��
    public Transform leftPos;
    public Transform middlePos;
    public Transform rightPos;
    //��¼��ǰ����λ�õ�����
    private GameObject leftObj;
    private GameObject middleObj;
    private GameObject rightObj;
    //ƴͼԤ����
    GameObject[] dragObj;
    //��¼ƴͼӦ�÷ŵĵ�
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
