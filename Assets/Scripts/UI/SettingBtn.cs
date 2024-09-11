using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    public Button btnSetting;
    public GameObject settingPanel;
    void Start()
    {
        btnSetting.onClick.AddListener(()=>
        {
            CrashManager.Instance.isUIShow=true;
            PlayerDataManager.Instance.isUIShow=true;
            settingPanel.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
