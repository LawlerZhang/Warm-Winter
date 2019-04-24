using UnityEngine;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    Dictionary<string, int> BGMDic = new Dictionary<string, int>();
    [SerializeField] AudioClip[] BGMClips;
    float[] PlayedTime;
    AudioSource audioSource;
    int nowPlayingIndex = 0;
    private void Awake()
    {
        PlayedTime = new float[BGMClips.Length];
        audioSource = GetComponent<AudioSource>();
        if (!BGMDic.ContainsKey("Main_background_music"))
            BGMDic.Add("Main_background_music", 0);
        if (!BGMDic.ContainsKey("YangHome"))
            BGMDic.Add("YangHome", 1);
        if (!BGMDic.ContainsKey("GirlHome"))
            BGMDic.Add("GirlHome", 2);
        if (!BGMDic.ContainsKey("ColdWind"))
            BGMDic.Add("ColdWind", 3);
        if (!BGMDic.ContainsKey("GuDeng"))
            BGMDic.Add("GuDeng", 4);
    }
    public void PlayBGM(string BGMName)
    {
        PlayedTime[nowPlayingIndex] = audioSource.time;
        nowPlayingIndex = BGMDic[BGMName];
        audioSource.clip = BGMClips[nowPlayingIndex];
        audioSource.time = PlayedTime[nowPlayingIndex];
        audioSource.Play();
    }
}
