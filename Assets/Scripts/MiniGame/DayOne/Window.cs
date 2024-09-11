using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Window : MonoBehaviour
{
    private static Window instance;
    public static Window Instance=>instance;
    private void Awake()
    {
        instance = this;
    }
    public string sceneFrom;
    public string sceneToGo;
    Vector3 cameraPos;
    public bool isFinishi1;
    public bool isFinishi2;
    public bool isFinishi3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isFinishi1 = Window1.isFinish;
        //isFinishi2 = Window2.isFinish;
        //isFinishi3 = Window3.isFinish;

        if(isFinishi1&&isFinishi2&&isFinishi3)
        {
            SceneDataManager.Instance.isWindowDone = true;
            TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGo, this.cameraPos);
            //SceneManager.LoadScene("DayOne");
        }
    }
}
