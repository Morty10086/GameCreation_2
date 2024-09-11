using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayThreeAni : MonoBehaviour
{
    public GameObject giftAnimationPanel;
    //���λ�õ���������
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (ObjectAtMousePosition()!=null&& ObjectAtMousePosition().gameObject.CompareTag("Click"))
            {
                //CrashManager.Instance.isUIShow=true;
                PlayerDataManager.Instance.isUIShow = true;
                giftAnimationPanel.SetActive(true);
            }
        }       
    }

    //�����������ײ��Ϣ
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
