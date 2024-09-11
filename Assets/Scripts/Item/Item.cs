using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{

    //提示物体
    public GameObject tipObj;
    //物品名
    public string itemName;
    //判断是否已经交互过
    public bool talkDone;
    //是否正在交互
    private bool isTalking;
    //记录当日任务完成时探索文本
    public List<string> clueText=new List<string>();
    //记录未完成强引导任务时的物品交互提示
    public List<string> workNotDoneText = new List<string>();
    //声明两个栈分别存储两种情况下物品的交互显示信息
    private Stack<string> workDoneStack;
    private Stack<string> workNotDoneStack;
   

    private void Awake()
    {
        this.FillTalkStack();
    }
  
    //如果已经完成交互，将自己添加到物品列表中
    public void AddToList()
    {
        ItemDataManager.Instance.AddItem(this);
        this.talkDone = true;
    }

    //两个堆栈数据的初始化
    private void FillTalkStack()
    {
        workDoneStack = new Stack<string>();
        workNotDoneStack= new Stack<string>();
        
        for(int i=clueText.Count-1;i>-1;i--)
        {
            workDoneStack.Push(clueText[i]);
        }
        for (int i = workNotDoneText.Count - 1; i > -1; i--)
        {
            workNotDoneStack.Push(workNotDoneText[i]);
        }
    }

    //工作完成时物品互动信息显示函数
    public void WorkDoneTalk()
    {
        if(!isTalking)
        {
            StartCoroutine(TalkRoutine(workDoneStack));
        }
    }
    //工作未完成时物品互动信息显示函数
    public void WorkNotDoneTalk()
    {
        if (!isTalking)
        {
            StartCoroutine(TalkRoutine(workNotDoneStack));
        }
    }
    
    //协程函数，用于分步分条将信息内容读取出来，并传递给UI管理类中的显示函数
    private IEnumerator TalkRoutine(Stack<string> data)
    {
        isTalking = true;
        if(data.TryPop(out string info))
        {
            ItemTalkUIManager.Instance.ShowTalk(info/*,this.transform.position*/);
            yield return null;
            isTalking=false;
        }
        else
        {
            ItemTalkUIManager.Instance.ShowTalk(string.Empty/*, this.transform.position*/);
            this.FillTalkStack();
            isTalking = false;
        }
    }
}
