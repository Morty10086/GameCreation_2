using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static PlayerDataManager instance;
    private PlayerDataManager() { }
    public static PlayerDataManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public bool isUIShow;
    //
    public Vector3 playerPos;
   //ת������֮ǰ�洢ж�س���������λ��
   public void SavePlayerPos()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    //ת������֮ǰ���ظ����³�������ҵ�λ�ã������ó���ǰ����һ��
    public void LoadPlayerPos()
    {
        if (playerPos != null) 
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = playerPos;
            }
        }
    }
}
