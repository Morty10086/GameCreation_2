using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //�г���ʱӦ�����õ������λ��
    protected Vector3 cameraPos/*=new Vector3(0,0,-10)*/;
    //Ҫж�صĳ���
    public string sceneFrom;
    //Ҫ���صĳ���
    public string sceneToGO;
    //�л��������ɰ��������������
    public virtual void TeleportTOScene()
    {
        TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
    }
}
