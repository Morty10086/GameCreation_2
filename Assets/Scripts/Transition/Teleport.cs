using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //切场景时应该设置的摄像机位置
    protected Vector3 cameraPos/*=new Vector3(0,0,-10)*/;
    //要卸载的场景
    public string sceneFrom;
    //要加载的场景
    public string sceneToGO;
    //切换场景，由按键检测管理类调用
    public virtual void TeleportTOScene()
    {
        TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
    }
}
