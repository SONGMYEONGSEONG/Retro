using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource bgmPlayer;
    [SerializeField] private AudioSource sfxPlayer;

    [SerializeField] private AudioClip[] bgmSources;
    [SerializeField] private AudioClip[] sfxSources;
    //private Dictionary<int, AudioClip> bgms;
    //private Dictionary<int, AudioClip> sfxs;

    protected override void Awake()
    {
        base.Awake();

    }

    public void PlayBgm(string bgmName)
    {
        for (int i = 0; i < bgmSources.Length; i++)
        {
            if (bgmSources[i].name == bgmName)
            {
                bgmPlayer.clip = bgmSources[i];
                bgmPlayer.Play();
                return;
            }
        }
    }

    public void StopBgm()
    {
        bgmPlayer.Stop();
    }

    public void PlaySfx(string sfxName)
    {
        for (int i = 0; i < sfxSources.Length; i++)
        {
            if (sfxSources[i].name == sfxName)
            {
                sfxPlayer.PlayOneShot(sfxSources[i]);
                return;
            }
        }
    }
}
