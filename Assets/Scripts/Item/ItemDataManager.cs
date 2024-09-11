using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static ItemDataManager instance;
    private ItemDataManager() { }
    public static ItemDataManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //��¼�Ѿ�������������
    public List<Item> itemList = new List<Item>();

    //����Ʒ���������ӵ���Ʒ�б�
    public void AddItem(Item item)
    {
        if(!itemList.Contains(item))
        {
            this.itemList.Add(item);
        }
    }
}
