using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 单例
    //声明为单例
    private static Player instance;
    private Player() { }
    public static Player Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //是否触发窗边动画
    public bool isWindow;
    //窗边动画是否播放完成
    public bool isWindowFin;

    public SpriteRenderer sr;

    public float moveSpeed=5;
    public Rigidbody2D playerRbody;
    public Animator animator;

    private AudioSource audioSource;
    private void Start()
    {
        sr=this.GetComponent<SpriteRenderer>();
        playerRbody=this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!PlayerDataManager.Instance.isUIShow)
        {
            Vector3 moveMent = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            animator.SetFloat("Horizontal", moveMent.x);
            animator.SetFloat("Vertical", moveMent.y);
            animator.SetFloat("Magnitude", moveMent.magnitude);
            //transform.position =transform.position+ Time.deltaTime*moveSpeed*moveMent;

        }

    }
    //移动，消除碰撞抖动
    private void FixedUpdate()
    {
        if (!PlayerDataManager.Instance.isUIShow)
        {
            Vector2 playerPos = playerRbody.position;
            playerPos.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            playerPos.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            playerRbody.MovePosition(playerPos);
        }
       

    }

    //检测是否到达可交互范围
    private void CheckInteract()
    {
        
    }

    //播放音效
    public void PlayerAudio()
    {
        audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
        audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
        this.audioSource?.Play();
    }

    //停止播放音效
    public void StopAudio()
    {
        this.audioSource?.Stop();
    }



}
