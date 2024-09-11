using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwake : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    public  static bool isAnimationFinish;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneDataManager.Instance.isWork1Done)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            player.SetActive(false);
        }
        
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (!animator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f)
        {
            isAnimationFinish = true;
            PlayerAwakeFade.isFinish = true;
            //player.SetActive(true);
            //this.gameObject.SetActive(false);
        }
    }
}   
