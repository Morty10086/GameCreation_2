using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTalkUIManager : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static ItemTalkUIManager instance;
    private ItemTalkUIManager() { }
    public static ItemTalkUIManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject itemTalkPanel;
    public Text talkText;
    public RectTransform panelTransform;
    public Camera uiCamera;
    //����UI�����ʾ���ı�Ϊ��ʱ����
    public void ShowTalk(string info/*,Vector3 textPos*/)
    {
        if (info != string.Empty)
        {
            itemTalkPanel.SetActive(true);
            //itemTalkPanel.transform.position = Camera.main.WorldToScreenPoint(textPos + new Vector3(0, 2, 0));

            //this.itemTalkPanel.transform.position = Camera.main.WorldToScreenPoint(textPos);
            //Vector3 screenPos = Camera.main.WorldToScreenPoint(textPos);
            //itemTalkPanel.transform.position = textPos;
            //panelTransform.anchoredPosition = new Vector2(screenPos.x, screenPos.y);
            //Vector2 localPos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(panelTransform.GetComponent<RectTransform>(), screenPos, null, out localPos);
        }
        else
        {
            itemTalkPanel.SetActive(false);
        }
        talkText.text = info;
    }

    //�������
    public void HideTalk()
    {
        this.itemTalkPanel.SetActive(false);
    }
}
