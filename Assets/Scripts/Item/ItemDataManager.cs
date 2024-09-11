using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    #region 单例
    //声明为单例
    private static ItemDataManager instance;
    private ItemDataManager() { }
    public static ItemDataManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //记录已经交互过的物体
    public List<Item> itemList = new List<Item>();

    //与物品交互完后，添加到物品列表
    public void AddItem(Item item)
    {
        if(!itemList.Contains(item))
        {
            this.itemList.Add(item);
        }
    }
}
