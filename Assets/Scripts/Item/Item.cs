using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{

    //��ʾ����
    public GameObject tipObj;
    //��Ʒ��
    public string itemName;
    //�ж��Ƿ��Ѿ�������
    public bool talkDone;
    //�Ƿ����ڽ���
    private bool isTalking;
    //��¼�����������ʱ̽���ı�
    public List<string> clueText=new List<string>();
    //��¼δ���ǿ��������ʱ����Ʒ������ʾ
    public List<string> workNotDoneText = new List<string>();
    //��������ջ�ֱ�洢�����������Ʒ�Ľ�����ʾ��Ϣ
    private Stack<string> workDoneStack;
    private Stack<string> workNotDoneStack;
   

    private void Awake()
    {
        this.FillTalkStack();
    }
  
    //����Ѿ���ɽ��������Լ���ӵ���Ʒ�б���
    public void AddToList()
    {
        ItemDataManager.Instance.AddItem(this);
        this.talkDone = true;
    }

    //������ջ���ݵĳ�ʼ��
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

    //�������ʱ��Ʒ������Ϣ��ʾ����
    public void WorkDoneTalk()
    {
        if(!isTalking)
        {
            StartCoroutine(TalkRoutine(workDoneStack));
        }
    }
    //����δ���ʱ��Ʒ������Ϣ��ʾ����
    public void WorkNotDoneTalk()
    {
        if (!isTalking)
        {
            StartCoroutine(TalkRoutine(workNotDoneStack));
        }
    }
    
    //Э�̺��������ڷֲ���������Ϣ���ݶ�ȡ�����������ݸ�UI�������е���ʾ����
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
