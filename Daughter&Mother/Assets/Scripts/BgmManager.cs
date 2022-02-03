using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    static public BgmManager instance;  //싱글톤화시킴=>이건 씬이 넘어가도 파괴되면 안되기 때문

    public AudioClip[] clips; // 배경음악들

    private AudioSource source;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(int _playMusicTrack)
    { //_playMusicTrack 오디오를 베열에 넣기 때문에 몇번째 곡을 진행할 건지
        source.volume = 1f;
        source.clip = clips[_playMusicTrack];
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
}
