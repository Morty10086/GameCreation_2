using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region ����
    //����Ϊ����
    private static Player instance;
    private Player() { }
    public static Player Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //�Ƿ񴥷����߶���
    public bool isWindow;
    //���߶����Ƿ񲥷����
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
    //�ƶ���������ײ����
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

    //����Ƿ񵽴�ɽ�����Χ
    private void CheckInteract()
    {
        
    }

    //������Ч
    public void PlayerAudio()
    {
        audioSource.mute = !MusicDataManager.Instance.musicData.isSoundOpen;
        audioSource.volume = MusicDataManager.Instance.musicData.soundValue;
        this.audioSource?.Play();
    }

    //ֹͣ������Ч
    public void StopAudio()
    {
        this.audioSource?.Stop();
    }



}
