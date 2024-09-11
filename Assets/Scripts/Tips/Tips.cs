using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public bool isShowTips;
    public string tip = "ЪѓБъзѓМќ";

    public Transform tipTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShowTips = true;
            TipsUIManager.Instance.ShowTips(this.transform,this.tipTransform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShowTips = false;
            TipsUIManager.Instance.HideTips();
            ItemTalkUIManager.Instance.HideTalk();
        }
    }
}
