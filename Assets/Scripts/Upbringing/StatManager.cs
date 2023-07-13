using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int Energy;
    public float EnergyX;
    public float EnergyY;

    public int Sociality;
    public float SocialityX;
    public float SocialityY;

    public int Deliberation;
    public float DeliberationX;
    public float DeliberationY;

    public int Curiosoty;
    public float CuriosotyX;
    public float CuriosotyY;

    public int Love;
    public float LoveX;
    public float LoveY;

    public static StatManager Instance { get; private set; } = null;
    private void Awake()
    {
        Energy = PlayerPrefs.GetInt("Energy", 0);
        EnergyX = PlayerPrefs.GetFloat("EnergyX", 0f);
        EnergyY = PlayerPrefs.GetFloat("EnergyY", 0);
        PlayerPrefs.SetInt("Energy", Energy);
        PlayerPrefs.SetFloat("EnergyX", EnergyX);
        PlayerPrefs.SetFloat("EnergyY", EnergyY);
        // Ȱ����, ������ ������ �ε�, ����

        Sociality = PlayerPrefs.GetInt("Sociality", 0);
        SocialityX = PlayerPrefs.GetFloat("SocialityX", 0);
        SocialityY = PlayerPrefs.GetFloat("SocialityY", 0);
        PlayerPrefs.SetInt("Sociality", Sociality);
        PlayerPrefs.SetFloat("SocialityX", SocialityX);
        PlayerPrefs.SetFloat("SocialityY", SocialityY);
        // ��ȸ��, ������ ������ �ε�, ����

        Deliberation = PlayerPrefs.GetInt("Deliberation", 0);
        DeliberationX = PlayerPrefs.GetFloat("DeliberationX", 0);
        DeliberationY = PlayerPrefs.GetFloat("DeliberationY", 0);
        PlayerPrefs.SetInt("Deliberation", Deliberation);
        PlayerPrefs.SetFloat("DeliberationX", DeliberationX);
        PlayerPrefs.SetFloat("DeliberationY", DeliberationY);
        // �����, ������ ������ �ε�, ����

        Curiosoty = PlayerPrefs.GetInt("Curiosoty", 0);
        CuriosotyX = PlayerPrefs.GetFloat("CuriosotyX", 0);
        CuriosotyY = PlayerPrefs.GetFloat("CuriosotyY", 0);
        PlayerPrefs.SetInt("Curiosoty", Curiosoty);
        PlayerPrefs.SetFloat("CuriosotyX", CuriosotyX);
        PlayerPrefs.SetFloat("CuriosotyY", CuriosotyY);
        // ȣ���, ������ ������ �ε�, ����

        Love = PlayerPrefs.GetInt("Love", 0);
        LoveX = PlayerPrefs.GetFloat("LoveX", 0);
        LoveY = PlayerPrefs.GetFloat("LoveY", 0);
        PlayerPrefs.SetInt("Love", Love);
        PlayerPrefs.SetFloat("LoveX", LoveX);
        PlayerPrefs.SetFloat("LoveY", LoveY);
        // ����ǥ��, ������ ������ �ε�, ����

        Instance = this;
    }
}
