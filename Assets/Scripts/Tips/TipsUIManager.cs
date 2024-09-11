using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsUIManager : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static TipsUIManager instance;
    private TipsUIManager() { }
    public static TipsUIManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject tipsPanel;
    public Text tipsText;
    public bool isShowTips;

    //��ʾ������ʾ��庯��
    public void ShowTips(Transform textPos,Transform showPos)
    {
        this.isShowTips = true;
        this.tipsText.text = textPos.GetComponent<Tips>().tip;
        this.tipsPanel.SetActive(true);
        this.tipsPanel.transform.position=Camera.main.WorldToScreenPoint(showPos.position);
    }

    //���ؽ�����ʾ��庯��
    public void HideTips()
    {
        this.isShowTips = false;
        this.tipsPanel.SetActive(false);
    }
}

