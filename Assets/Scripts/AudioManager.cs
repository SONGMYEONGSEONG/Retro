using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get 
        { 
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if(instance == null)
                {
                    GameObject Obj = new GameObject();
                    Obj.name = typeof(AudioManager).Name;
                    instance = Obj.AddComponent<AudioManager>();
                }
            }

            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    [SerializeField] AudioClip[] bgm;
    [SerializeField] AudioClip[] sfx;

    public void PlayBgm(string bgmName)
    {
        for(int i =0; i< bgm.Length; i++)
        {
            if (bgm[i].name == bgmName)
            {
                bgmPlayer.clip = bgm[i];
                bgmPlayer.Play();
                return;
            }
        }

        Debug.Log(bgmName + "의 bgm 파일이 존재하지 않음");
    }

    public void StopBgm()
    {
        bgmPlayer.Stop();
    }

    public void PlaySfx(string sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfx[i].name == sfxName)
            {
                sfxPlayer.PlayOneShot(sfx[i]);
                return;
            }
        }

        Debug.Log(sfxName + "의 sfx 파일이 존재하지 않음");
    }
}
