using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDataManager 
{
    private static MusicDataManager instance=new MusicDataManager();
    public static MusicDataManager Instance=>instance;
    public MusicData musicData = new MusicData();
    

    public void IsOpenMusic(bool isOpen)
    {
        musicData.isMusicOpen=isOpen;
    }
    public void IsOpenSound(bool isOpen)
    {
        musicData.isSoundOpen=isOpen;
    }

    public void ChangeMusicValue(float value)
    {
        musicData.musicValue=value;
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
    }

}
