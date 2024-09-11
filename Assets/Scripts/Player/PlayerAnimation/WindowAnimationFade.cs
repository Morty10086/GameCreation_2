using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnimationFade : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    public GameObject player;
    public GameObject windowP;
    public GameObject jingZiP;

    void Update()
    {
        if(windowP!=null)
        {
            if (WindowAnimation.isAnimationFinish)
            {
                StartCoroutine(ReallyFadeWindow());
            }
        }
        if(jingZiP!=null)
        {
            if (JingZiAnimation.isAnimationFinish)
            {
                StartCoroutine(ReallyFadeJingZi());
            }
        }
        
    }

    private IEnumerator ReallyFadeWindow()
    {
        WindowAnimation.isAnimationFinish = false;
        yield return Fade(1);
        windowP.SetActive(false);
        yield return Fade(0);
        player.SetActive(true);
    }

    private IEnumerator ReallyFadeJingZi()
    {
        JingZiAnimation.isAnimationFinish = false;
        yield return Fade(1);
        jingZiP.SetActive(false);
        yield return Fade(0);
        player.SetActive(true);
    }
    //¹ý¶ÉÐ§¹û
    private IEnumerator Fade(float targetAlpha)
    {
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;
    }
}
