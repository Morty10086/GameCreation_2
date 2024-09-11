using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsUIManager : MonoBehaviour
{
    #region 单例
    //声明为单例
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

    //显示交互提示面板函数
    public void ShowTips(Transform textPos,Transform showPos)
    {
        this.isShowTips = true;
        this.tipsText.text = textPos.GetComponent<Tips>().tip;
        this.tipsPanel.SetActive(true);
        this.tipsPanel.transform.position=Camera.main.WorldToScreenPoint(showPos.position);
    }

    //隐藏交互提示面板函数
    public void HideTips()
    {
        this.isShowTips = false;
        this.tipsPanel.SetActive(false);
    }
}

