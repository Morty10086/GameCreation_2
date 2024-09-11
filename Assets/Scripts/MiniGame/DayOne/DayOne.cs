using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOne : MonoBehaviour
{
    private static DayOne instance;
    public static DayOne Instance=>instance;
    private void Awake()
    {
        instance = this;
    }

    public string sceneFrom;
    public string sceneToGO;
    Vector3 cameraPos;

    public GameObject gameOne;
    public GameObject gameTwo;
    public GameObject gameThree;

    public  bool gameOneFinish;
    public  bool gameTwoFinish;
    public  bool gameThreeFinish;
    public Button btnOne;
    public Button btnTwo;
    void Start()
    {
        btnOne.onClick.AddListener(() =>
        {

            gameOne.SetActive(false);
            gameTwo.SetActive(true);


        });

        btnTwo.onClick.AddListener(() =>
        {
            if(gameTwoFinish)
            {
                gameTwo.SetActive(false);
                gameThree.SetActive(true);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        //btnOne.onClick.AddListener(() =>
        //{
        //if (gameOneFinish)
        //{
        //    gameOne.SetActive(false);
        //    gameTwo.SetActive(true);


        //}
        //});
        if (gameThreeFinish)
        {
            SceneDataManager.Instance.isWork1Done = true;
            TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
        }
    }
}
