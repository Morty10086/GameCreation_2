using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    #region 单例
    //声明为单例
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
   //转换场景之前存储卸载场景里的玩家位置
   public void SavePlayerPos()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    //转换场景之前加载更新新场景里玩家的位置，与进入该场景前保持一致
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
