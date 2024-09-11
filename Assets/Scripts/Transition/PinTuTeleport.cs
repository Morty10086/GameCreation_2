using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTuTeleport : Teleport
{
    //摄像机位置
    //Vector3 cameraPos=new Vector3(0,0,-10);
    //要卸载的场景
    //public string sceneFrom;
    //要加载的场景
    //public string sceneToGO;

    //拼图完成时切换的场景
    public string scenePinTuDone;

    private void Awake()
    {
        this.cameraPos = new Vector3(0, 0, -10);
    }

    //切换场景，由按键检测管理类调用
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
