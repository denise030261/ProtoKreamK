using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour
{
    public GameObject MusicSetting;
    public GameObject EndQuestion;

    public void OnClick_Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    } // ��ư X�� ���� �� ������ ����
    public void OnClick_MusicSetting()
    {
        MusicSetting.SetActive(true);
    } // 'ȯ�漳��' Ű��
    public void OnClick_Exit()
    {
        EndQuestion.SetActive(true);
    } // �� ����
    public void OnClick_EndYes()
    {
        Application.Quit();
    }
    public void OnClick_EndNo()
    {
        EndQuestion.SetActive(false);
    }
}
