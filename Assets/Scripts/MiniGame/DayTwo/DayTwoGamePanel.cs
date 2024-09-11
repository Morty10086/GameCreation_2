using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTwoGamePanel : MonoBehaviour
{
    public string sceneFrom;
    public string sceneToGO;
    Vector3 cameraPos;


    public AudioSource audioSource;

    public Button btnLeft;
    public Button btnRight;
    public Button btnUp;
    public Button btnDown;
    public GameObject[] game=new GameObject[3];
    public int index = 0;

    public GameObject[] game3= new GameObject[2];
    public int indexV = 0;

    public static bool oneFinsh;
    public static bool twoFinsh;
    public static bool threeFinsh;
    void Start()
    {
        btnRight.onClick.AddListener(() =>
        {
            audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
            audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
            audioSource.Play();
            if (index < 2)
            {
                switch(index)
                {
                    case 0:
                        if (oneFinsh)
                        {
                            game[index].SetActive(false);
                            game[index + 1].SetActive(true);
                            index++;
                        }
                        break;
                    case 1:
                        if(twoFinsh)
                        {
                            game[index].SetActive(false);
                            game[index + 1].SetActive(true);
                            index++;
                        }
                        break;
                }
                
            }            
        });

        btnLeft.onClick.AddListener(() =>
        {
            audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
            audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
            audioSource.Play();
            if (index>0)
            {
                game[index].SetActive(false);
                game[index-1].SetActive(true);
                index--;
            }
        });

        btnUp.onClick.AddListener(() =>
        {
            audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
            audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
            audioSource.Play();
            if (indexV==1)
            {
                game3[indexV].SetActive(false);
                game3[indexV-1].SetActive(true);
                indexV = 0;
            }
        });

        btnDown.onClick.AddListener(() =>
        {
            audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
            audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
            audioSource.Play();
            if (indexV==0)
            {
                game3[indexV].SetActive(false);
                game3[indexV + 1].SetActive(true);
                indexV = 1;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (threeFinsh)
        {
            SceneDataManager.Instance.isWork2Done = true;
            TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGO, this.cameraPos);
        }
    }
}
