using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel<SettingPanel>
{
    public Button closeButton;
    public Button quitButton;
    public Toggle isMusicOpenTog;
    public Toggle isSoundOpenTog;
    public Slider musicValueSld;
    public Slider soundValueSld;
    public GameObject kongJian;

    protected override void Awake()
    {
        base.Awake();
        isMusicOpenTog.isOn = MusicDataManager.Instance.musicData.isMusicOpen;
        isSoundOpenTog.isOn=MusicDataManager.Instance.musicData.isSoundOpen;
        musicValueSld.value = MusicDataManager.Instance.musicData.musicValue;
        soundValueSld.value=MusicDataManager.Instance.musicData.soundValue;
    }
    void Start()
    {
        
        closeButton.onClick.AddListener(() =>
        {
            CrashManager.Instance.isUIShow=false;
            PlayerDataManager.Instance.isUIShow = false;
            Time.timeScale = 1.0f;
            kongJian.SetActive(false);
            this.HideMe();
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        isMusicOpenTog.onValueChanged.AddListener((isOpen) =>
        {
            MusicDataManager.Instance.musicData.isMusicOpen = isOpen;
        });

        isSoundOpenTog.onValueChanged.AddListener((isOpen) =>
        {
            MusicDataManager.Instance.musicData.isSoundOpen = isOpen;
        });

        musicValueSld.onValueChanged.AddListener((value) =>
        {
            MusicDataManager.Instance.musicData.musicValue=value;
        });
        soundValueSld.onValueChanged.AddListener((value) =>
        {
            MusicDataManager.Instance.musicData.soundValue = value;
        });
        this.HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
