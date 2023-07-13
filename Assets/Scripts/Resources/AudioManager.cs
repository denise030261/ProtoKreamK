using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } = null;

    public AudioSource BGMSource;
    //public AudioSource SFXSource;
    private static AudioManager instance;

    private void Awake()
    {
        Instance = this; // �ν��Ͻ�ȭ

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // �� �ѱ� �� ���� �ձ�
    } 

    public void playBGM(string name)
    {
        AudioClip BGMClip = Resources.Load<AudioClip>("Music/BGM/" + name);
        if(BGMClip !=null)
        {
            if (BGMClip != null)
            {
                BGMSource.clip = BGMClip;
                BGMSource.volume = PlayerPrefs.GetFloat("BGM");
                BGMSource.Play();
            }
        }
    } // BGM Ʋ��

    public void StopBGM()
    {
        BGMSource.Stop();
    }
    /*public void playSFX(string name)
    {
        AudioClip SFXClip = Resources.Load<AudioClip>("SFX/" + name);
        if (SFXClip != null)
        {
            if (SFXClip != null)
            {
                SFXSource.clip = SFXClip;
                SFXSource.volume = PlayerPrefs.GetFloat("SFX");
                SFXSource.Play();
            }
        }
    } // SFX Ʋ��*/

    private void Update()
    {
        BGMSource.volume = PlayerPrefs.GetFloat("BGM",0.6f);
        //SFXSource.volume = PlayerPrefs.GetFloat("SFX");
    } // BGM, SFX�� �ٷ� �ݿ��ϱ�
}
