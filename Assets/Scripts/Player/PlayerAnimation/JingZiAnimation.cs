using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.UI;
using UnityEngine;

public class JingZiAnimation : MonoBehaviour
{
    public string sceneFrom;
    public string sceneToGo;
    Vector3 cameraPos;

    public GameObject player;
    public GameObject jingZi;
    public GameObject hide2;
    private Animator jingAnimator;
    private AnimatorStateInfo stateInfo;
    public static bool isAnimationFinish;
    void Start()
    {
        jingAnimator = jingZi.GetComponent<Animator>();
    }

    void Update()
    {
        
            stateInfo = jingAnimator.GetCurrentAnimatorStateInfo(0);

            if (!jingAnimator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f)
            {
                isAnimationFinish = true;
                player.SetActive(true);
                //jingZi.SetActive(false);
                this.gameObject.SetActive(false);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetActive(false);
            hide2.SetActive(false);
            this.GetComponent<Animator>().SetBool("isJingZi", true);
        }
    }

    public void JingZiBreak()
    {
        this.jingZi.SetActive(true);
    }

    public void ToDayThree()
    {
        PlayerDataManager.Instance.playerPos=player.transform.position;
        TeleportManager.Instance.ToScene(this.sceneFrom, this.sceneToGo, this.cameraPos);
    }


}
