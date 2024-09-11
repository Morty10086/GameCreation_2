using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class DayOneGame1 : MonoBehaviour
{
    public AudioSource audioSource;
    public Button btnNext;
    public GameObject gameTwo;

    //
    Vector3 cameraPos=new Vector3(0,0,-10);
    //�Ƿ����
    public  bool isFinish;
    //Ҫж�صĳ���
    public string sceneFrom;
    //Ҫ���صĳ���
    public string sceneToGO;
    //���λ�õ���������
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //��¼��ǰѡ��ƴͼ�ķ���λ��
    private Vector3 nowDropPos;
    //ѡ��ƴͼ��������С����
    private float minDis = 5;
    //��¼����ƴͼ��ѡ��
    private GameObject selectedObj;
    //�ƶ������е�ʵʱλ��
    private Vector3 movePos;

    //ƴͼԤ����
    GameObject[] dragObj;
    //��¼ƴͼӦ�÷ŵĵ�
    GameObject[] dropObj;
    // Start is called before the first frame update
    void Start()
    {
        //btnNext.onClick.AddListener(() =>
        //{
        //    if (isFinish)
        //    {
        //        Debug.Log("DayOneGame1Finished!");
        //        gameTwo.SetActive(true);
        //        this.gameObject.SetActive(false);
        //    }
        //});
        dragObj = GameObject.FindGameObjectsWithTag("drag");
        dropObj = GameObject.FindGameObjectsWithTag("drop");

    }

    // Update is called once per frame
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
            //if (Input.GetMouseButtonDown(1))
            //{
            //    selectedObj.transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);
            //}
        }
        //Check();
        //if (isFinish)
        //{
        //    Debug.Log("DayOneGame1Finished!");
        //    dragObj[0].GetComponent<SpriteRenderer>().color= Color.yellow;
        //}
    }
    //�����ʰ��ƴͼ
    private void Clik(GameObject clikObj)
    {
        if (!clikObj.CompareTag("drag"))
        {
            return;
        }
        this.selectedObj = clikObj;
        Cursor.visible = false;
    }

    //�����������ײ��Ϣ
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    //��������
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

    //���ƴͼ�Ƿ����
    public void Check()
    {
        //Window.Instance.isFinishi1 = true;
        int flag = 0;
        Vector3 dragPos;
        Vector3 dropPos;
        for (int i = 0; i < dropObj.Length; i++)
        {
            dragPos = dragObj[i].transform.position;
            dropPos = dropObj[i].transform.position;
            if (dragPos == dropPos)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
        }
        if (flag == 1)
        {
            DayOne.Instance.gameOneFinish = true;
        }
    }

    public void ToGameTwo()
    {

            if (DayOne.Instance.gameOneFinish)
            {
                DayOne.Instance.gameOne.SetActive(false);
                gameTwo.SetActive(true);


            }
    }
    public void ToScene()
    {
        if(isFinish)
        {
            Debug.Log("DayOneGame1Finished!");
            gameTwo.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void PlayAudio()
    {
        audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
        audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
        audioSource.Play();
    }
}