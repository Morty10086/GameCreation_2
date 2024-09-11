using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataManager:MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static SceneDataManager instance;
    private SceneDataManager() { }
    public static SceneDataManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public bool isWork1Done;
    public bool isWork2Done;
    public bool isPinTuDone;
    public bool isWindowDone;
    public bool isGameOver;
}
