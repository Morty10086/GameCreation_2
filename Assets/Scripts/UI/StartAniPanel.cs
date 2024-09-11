using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAniPanel :BasePanel<StartAniPanel>
{

    public GameObject beginPanel;
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (!animator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f)
        {
            beginPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
