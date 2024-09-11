using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayThreeClose : MonoBehaviour
{
    int index = 1;
    public GameObject endPanel;
    public Text txtEnd;
    public GameObject btnClose;
    public GameObject giftAnimationPanel;
    public void ShowCloseBtn()
    {
        btnClose.SetActive(true);
    }
    public void CloseAnimation()
    {

        PlayerDataManager.Instance.isUIShow=false;
        giftAnimationPanel.SetActive(false);
        SceneDataManager.Instance.isGameOver=true;
    }

    public void SHowEnd()
    {
        endPanel.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            index++;
            if(index==3)
            {
                txtEnd.text = "……是吗，你从来没认为那是痛苦吗。";
            }
            if(index==5)
            {
                txtEnd.text = "END";
            }
        }
    }
}
