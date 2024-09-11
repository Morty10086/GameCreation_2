using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : MonoBehaviour
{
    private Vector3 cameraPos;
    public Button startBtn;
    public Button settingBtn;
    public Button exitBtn;
    public Button closeMusicBtn;
    public SettingPanel settingPanel;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        startBtn.onClick.AddListener(() =>
        {
            animator.SetTrigger("Start");
           
        });

        settingBtn.onClick.AddListener(() =>
        {
            CrashManager.Instance.isUIShow=true;
            PlayerDataManager.Instance.isUIShow=true;
            settingPanel.ShowMe();            
        });

        exitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });

    }

    public void StartGame()
    {
        TeleportManager.Instance.ToScene("BeginScene", "DayOne", this.cameraPos);
    }

    
}
