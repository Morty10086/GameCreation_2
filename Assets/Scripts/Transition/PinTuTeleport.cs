using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTuTeleport : Teleport
{
    //�����λ��
    //Vector3 cameraPos=new Vector3(0,0,-10);
    //Ҫж�صĳ���
    //public string sceneFrom;
    //Ҫ���صĳ���
    //public string sceneToGO;

    //ƴͼ���ʱ�л��ĳ���
    public string scenePinTuDone;

    private void Awake()
    {
        this.cameraPos = new Vector3(0, 0, -10);
    }

    //�л��������ɰ��������������
    public override void TeleportTOScene()
    {
        if (!SceneDataManager.Instance.isPinTuDone)
        {
            TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO,this.cameraPos);
        }
        else
        {
            TeleportManager.Instance.ToScene(this.sceneFrom, this.scenePinTuDone,this.cameraPos);
        }
    }

}
