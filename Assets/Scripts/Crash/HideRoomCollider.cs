using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideRoomCollider : MonoBehaviour
{
    #region 单例
    //声明为单例
    private static HideRoomCollider instance;
    private HideRoomCollider() { }
    public static HideRoomCollider Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject hideSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hideSprite.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hideSprite.SetActive(true);
    }
}
