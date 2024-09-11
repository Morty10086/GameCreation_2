using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTeleport :Teleport
{
    //�����λ��
    //Vector3 cameraPos=new Vector3(0,0,-10);
    //Ҫж�صĳ���
    //public string sceneFrom;
    //Ҫ���صĳ���
    //public string sceneToGO;

    //�������ʱ�л��ĳ���
    public string sceneWorkDone;

    private void Awake()
    {
        this.cameraPos = new Vector3(0, 0, -10);
    }

    //�л��������ɰ��������������

    public override void TeleportTOScene()
    {
        if (!SceneDataManager.Instance.isWork1Done)
        {
            TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
        }
        //else
        //{
        //    TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneWorkDone, this.cameraPos);
        //}
    }

}
