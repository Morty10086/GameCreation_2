using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashManager : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static CrashManager instance;
    private CrashManager() { }
    public static CrashManager Instance => instance;
    private void Awake()
    {
        //audioSource = this.GetComponent<AudioSource>();
        instance = this;
    }
    #endregion
    //��¼���λ�ã����ڷ�Χ���
    //private Vector3 playerPosition;
    //private Vector3 playerPosition = Player.Instance.gameObject.transform.position;

    public bool isGame1Done;



    //�Ƿ���԰�������(�ڼ�ⷶΧ�ڿɽ���)
    private bool canKeyBoard;
    //�Ƿ���Խ��з�Χ��⣬��Ҫ�����ʾUI���ʱ��������߼���Ȼִ�е�����
    public bool isUIShow=false;
    private Vector3 playerPosition => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    //private AudioSource audioSource;
    //private bool isPlayAudio = true;
    private void Update()
    {
        //if (Player.Instance != null)
        //{
        //    playerPosition = Player.Instance.playerRbody.transform.position;
        //}
        canKeyBoard = MouseAtPosition();
        if (!isUIShow)
        {
            if (canKeyBoard)
            {
                //�ж��Ƿ��½�����
                if (Input.GetMouseButtonDown(0))
                {
                    TipsUIManager.Instance.HideTips();
                    ClickActioin(MouseAtPosition().gameObject);
                }
            }
        }
       
    }

    //��ⰴ���������
    private void ClickActioin(GameObject clickObject)
    {

        switch(clickObject.tag)
        {
            case "Teleport":
                //if(isGame1Done)
                //{
                    var teleport = clickObject.GetComponent<Teleport>();
                    teleport?.TeleportTOScene();
                //}
               
                break;
            case "WorkTeleport":
                var workTeleport=clickObject.GetComponent<WorkTeleport>();
                var workTip = clickObject.GetComponentInChildren<Tips>();
                var audio = clickObject.GetComponent<AudioSource>();
                audio?.Play();
                audio.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
                audio.volume = MusicDataManager.Instance.musicData.soundValue;
                if (workTeleport==null)
                {
                    var workTeleport1 = clickObject.GetComponent<WorkTeleport1>();
                    if (workTip != null && workTip.isShowTips)
                    {
                        workTeleport1?.TeleportTOScene();
                    }
                }

                if (workTip != null && workTip.isShowTips)
                {
                    workTeleport?.TeleportTOScene();
                }
                break;
            case "PinTuTeleport":
                var pinTu=clickObject.GetComponent<PinTuTeleport>();
                if(SceneDataManager.Instance.isWork1Done)
                {
                    pinTu?.TeleportTOScene();
                }                   
                break;
            case "Item":              
                //if (isPlayAudio)
                //{
                //    this.audioSource?.Play();
                //    isPlayAudio = false;
                //}               
                var item=clickObject.GetComponent<Item>();
                var tip = clickObject.GetComponentInChildren<Tips>();
                if (tip != null&&tip.isShowTips)
                {
                    if (SceneDataManager.Instance.isWork1Done)
                    {
                        item?.AddToList();
                        item?.WorkDoneTalk();
                        
                    }
                    else
                    {

                        item?.WorkNotDoneTalk();
                        
                    }
                }
                break;
            case "Item2":
                var item2 = clickObject.GetComponent<Item>();
                var tip2 = clickObject.GetComponentInChildren<Tips>();
                if (tip2 != null && tip2.isShowTips)
                {
                    if (SceneDataManager.Instance.isWork2Done)
                    {
                        item2?.AddToList();
                        item2?.WorkDoneTalk();

                    }
                    else
                    {

                        item2?.WorkNotDoneTalk();

                    }
                }
                break;
        }
    }

    //�����ҷ�Χ�ڵ���ײ��
    private Collider2D MouseAtPosition()
    {

        return Physics2D.OverlapPoint(playerPosition);
    }
       
}
