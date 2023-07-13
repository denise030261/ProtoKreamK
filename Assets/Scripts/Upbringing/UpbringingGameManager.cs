using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpbringingGameManager : MonoBehaviour
{
    public int ActionNum; // ȣ����
    public Text ActionNumText;
    public Text DayText;
    public GameObject Stat;
    public GameObject[] StatValue; // ���� ����� 
    public GameObject[] BlockInteraction;

    public GameObject RandomQuestion;
    public GameObject InteractionQuestion;
    public GameObject NextDayQuestion;

    public Dictionary<int, string> StatOrder = new Dictionary<int, string>(); // ���� ��ųʸ�
    public int[] Cal = new int[2];


    public static UpbringingGameManager Instance { get; private set; } = null;
    private void Awake()
    {
        StatOrder.Add(0, "Energy");
        StatOrder.Add(1, "Sociality");
        StatOrder.Add(2, "Deliberation");
        StatOrder.Add(3, "Curiosoty");
        StatOrder.Add(4, "Love");

        Cal[0] = 1;
        Cal[1] = -1;

        ActionNum = PlayerPrefs.GetInt("ActionNum", 1000);
        PlayerPrefs.SetInt("ActionNum", ActionNum);
        Instance = this;
    }
    private void Start()
    {
        DayText.text = HeavenGameManager.Instance.Day.ToString()+"�� °";
        ActionNumText.text = ActionNum.ToString();

        //AudioManager.Instance.StopBGM();
        //AudioManager.Instance.playBGM("Upbringing");
    }

    private void Update()
    {
        ActionNumText.text = PlayerPrefs.GetInt("ActionNum", 1000).ToString();
    }

    public void OnClick_NextDay()
    {
        PlayerPrefs.SetInt("ActionNum", ActionNum);
        NextDayQuestion.SetActive(true);
    }
    public void OnClick_Random()
    {
        RandomQuestion.SetActive(true);
    } // '������ ���� +1' ��ư

    public void OnClick_Want()
    {
        Stat.SetActive(true);
    } // '���ϴ� ���� +1' ��ư

    public void OnClick_InteractiQuestion()
    {
        InteractionQuestion.SetActive(true);
    }

    public void NextDayAnswer(bool Yes)
    {
        NextDayQuestion.SetActive(false);
        if (Yes)
        {
            if (HeavenGameManager.Instance.Day < 20)
            {
                HeavenGameManager.Instance.Day++;
                PlayerPrefs.SetInt("Day", HeavenGameManager.Instance.Day);
                SceneManager.LoadScene("Heaven");

            } // 20�� ���� �ð��� õ�� ������ �Ѿ
            else
            {
                HeavenGameManager.Instance.Day = 0;
                PlayerPrefs.SetInt("Day", HeavenGameManager.Instance.Day);
            } // 20�� °���� ������ ������ ��ü�� �������� ����
        }
    }
}
