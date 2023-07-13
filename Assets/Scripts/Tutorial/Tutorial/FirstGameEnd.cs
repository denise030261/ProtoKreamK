using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstGameEnd : MonoBehaviour
{
    public Text ChatText;
    private int order;
    private int Day;
    private int TutorialDay;

    private string[] Chat = {  "�����ϼ̽��ϴ�! �������� ������ ������ �� ������!",
        "(�����Ҹ� ������ ���̰� ���� ���ɰ� �Բ� ���� ��ٸ��� �ִ�.)",
    "������ζ�� �������� ���� ���⼭ ���Դϴٸ�,�߰��� ���ּž� �� ���� �־� ��ٸ��� �־����ϴ�.",
        "�ٸ��� �ƴ϶� �ֱ� �� ����� �Ҿ� ������ ���¸� ��� �������� ���� ���� �߰ߵǰ� �ֽ��ϴ�.",
        "�׷��� ���� ������ �������� ���ɵ��� ����� ã�� �� �ְ� ������ ���� �ϰ� �ֽ��ϴ�.",
    "��� ������ ���� �˷��帱 �״� �ϴ� ������ �̵��Ͻ���."};

    private void Awake()
    {
        Day = PlayerPrefs.GetInt("Day");
        PlayerPrefs.SetInt("Day", Day);
        TutorialDay = PlayerPrefs.GetInt("TutorialDay", 0);
        PlayerPrefs.SetInt("TutorialDay", TutorialDay);
    }

    private void Start()
    {
        if (Day == 1 && TutorialDay==1)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
        ChatText.text = Chat[0];
        order = 1;
    }

    void Update()
    {
        if (order == Chat.Length && Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Upbringing");
        }
        if (Input.GetMouseButtonDown(0) && Chat.Length > order)
        {
            ChatText.text = Chat[order];
            order++;
        }
    }
}
