using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window3 : MonoBehaviour
{

    public static bool  isFinish;
    //��ǩ
    public string myTag;
    //��¼���Ը����ļ���ͼ
    public GameObject[] swapObj;
    //��ǰ��ʾ���������еڼ���
    public int index = 0;
    //���λ�õ���������
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



    //�����������ײ��Ϣ
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
