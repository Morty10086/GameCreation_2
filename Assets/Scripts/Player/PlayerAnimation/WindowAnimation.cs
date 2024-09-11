using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindowAnimation : MonoBehaviour
{
    public string sceneFrom;
    public string sceneToGo;
    Vector3 cameraPos;
    // Start is called before the first frame update
    public GameObject player;
    public GameObject windowP;
    private Animator winPAnimator;
    private AnimatorStateInfo stateInfo;
    public static bool isAnimationFinish;
    private AudioSource audioSource;

    public GameObject window;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        winPAnimator = windowP.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            stateInfo = winPAnimator.GetCurrentAnimatorStateInfo(0);

            if (!winPAnimator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f)
            {
                isAnimationFinish=true;
                player.SetActive(true);
                windowP.SetActive(false);
                this.gameObject.SetActive(false);               
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            windowP.transform.position = other.transform.position;
            player.SetActive(false);
            windowP.SetActive(true);
            if(windowP.activeSelf)
            {
                windowP.GetComponent<Animator>().SetTrigger("WindowP");
            }
            this.GetComponent<Animator>().SetBool("isWindow",true);
        }
    }

    public void PlayAudio()
    {
        audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
        audioSource.Play();
    }
    public void ToDayTwo()
    {
        TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGo, this.cameraPos);
    }
    public void StopAnimation()
    {
        window.SetActive(false);
    }
}
