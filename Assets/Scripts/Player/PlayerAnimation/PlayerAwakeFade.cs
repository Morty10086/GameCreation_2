using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwakeFade : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    public static bool isFinish;

    public GameObject playerAwake;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isFinish)
        {
            StartCoroutine(ReallyFade());
        }
    }

    private IEnumerator ReallyFade()
    {
        isFinish = false;
        playerAwake.SetActive(false);
        yield return Fade(1);       
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

