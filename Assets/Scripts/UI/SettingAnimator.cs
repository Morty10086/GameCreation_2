using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kongJian;
    void Start()
    {
        kongJian.SetActive(false);
    }

    public void ShowKongJian()
    {
        kongJian.SetActive(true);
    }
}
