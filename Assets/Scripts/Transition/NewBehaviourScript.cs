using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneFrom;
    public string sceneToGO;
    Vector3 cameraPos=new Vector3(0,0,-10);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(DayOneGame1.isFinish)
        //{
        //    //TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
        //    SceneManager.LoadScene(sceneToGO);
        //}
    }



}
