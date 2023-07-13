using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatManager : MonoBehaviour
{
    public GameObject[] State; // ���� ������
    public Text ActionNumText; // ���� �ؽ�Ʈ
    public GameObject StatQuestion; // ���� ����
    private int CurrentNum; // ���� ȣ����
    private int StatNum;
    public Text QuestionText;

    Dictionary<int, string> StatOrder = new Dictionary<int, string>(); // ���� ��ųʸ�

    private string[] StatText = { "Ȱ����", "��ȸ��", "�����", "ȣ���", "����ǥ��",
        "������", "������", "������", "������", "������"};

    private void Start()
    {
        StatOrder.Add(0, "Energy");
        StatOrder.Add(1, "Sociality");
        StatOrder.Add(2, "Deliberation");
        StatOrder.Add(3, "Curiosoty");
        StatOrder.Add(4, "Love");

        OnEnable();
    } // ��ųʸ� �ʱ�ȭ
    
    private void OnEnable()
    {
        for(int i=0;i<5;i++)
        {
            RectTransform rectTransform = State[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(PlayerPrefs.GetFloat(StatOrder[i] + "X"), PlayerPrefs.GetFloat(StatOrder[i]+"Y"));
        }
    } // ���� ���� �ݿ�

    public void Increase(int index)
    {
            if (index == 0 && StatManager.Instance.Energy < 4 && CurrentNum >= 100)
            {
                StatManager.Instance.Energy++;
                PlayerPrefs.SetInt("Energy", StatManager.Instance.Energy);
                StatMove(index, -111);
            DecreaseNum();
        }
            else if (index == 1 && StatManager.Instance.Sociality < 4 && CurrentNum >= 100)
            {
                StatManager.Instance.Sociality++;
                PlayerPrefs.SetInt("Sociality", StatManager.Instance.Sociality);
                StatMove(index, -111);
            DecreaseNum();
        }
            else if (index == 2 && StatManager.Instance.Deliberation < 4 && CurrentNum >= 100)
            {
                StatManager.Instance.Deliberation++;
                PlayerPrefs.SetInt("Deliberation", StatManager.Instance.Deliberation);
                StatMove(index, -111);
            DecreaseNum();
        }
            else if (index == 3 && StatManager.Instance.Curiosoty < 4 && CurrentNum >= 100)
            {
                StatManager.Instance.Curiosoty++;
                PlayerPrefs.SetInt("Curiosoty", StatManager.Instance.Curiosoty);
                StatMove(index, -111);
            DecreaseNum();
        }
            else if (index == 4 && StatManager.Instance.Love < 4 && CurrentNum >= 100)
            {
                StatManager.Instance.Love++;
                PlayerPrefs.SetInt("Love", StatManager.Instance.Love);
                StatMove(index, -111);
            DecreaseNum();
        }
    } // ���� ��ư ������ �� ���� ����, ���ʺ��� �Ʒ����� 0 ~ 4��°

    public void Decrease(int index)
    {
        if (CurrentNum >= 100)
        {
            if (index == 0 && StatManager.Instance.Energy > -4 && CurrentNum >= 100)
            {
                
                StatManager.Instance.Energy--;
                PlayerPrefs.SetInt("Energy", StatManager.Instance.Energy);
                StatMove(index, 111);
                DecreaseNum();
            }
            else if (index == 1 && StatManager.Instance.Sociality > -4 && CurrentNum >= 100)
            {
                StatManager.Instance.Sociality--;
                PlayerPrefs.SetInt("Sociality", StatManager.Instance.Sociality);
                StatMove(index, 111);
                DecreaseNum();
            }
            else if (index == 2 && StatManager.Instance.Deliberation > -4 && CurrentNum >= 100)
            {
                StatManager.Instance.Deliberation--;
                PlayerPrefs.SetInt("Deliberation", StatManager.Instance.Deliberation);
                StatMove(index, 111);
                DecreaseNum();
            }
            else if (index == 3 && StatManager.Instance.Curiosoty > -4 && CurrentNum >= 100)
            {
                StatManager.Instance.Curiosoty--;
                PlayerPrefs.SetInt("Curiosoty", StatManager.Instance.Curiosoty);
                StatMove(index, 111);
                DecreaseNum();
            }
            else if (index == 4 && StatManager.Instance.Love > -4 && CurrentNum >= 100)
            {
                StatManager.Instance.Love--;
                PlayerPrefs.SetInt("Love", StatManager.Instance.Love);
                StatMove(index, 111);
                DecreaseNum();
            }

        }
    } // ������ ��ư ������ �� ���� ����, ���ʺ��� �Ʒ����� 0 ~ 4��°

    private void StatMove(int index, int move)
    {
        RectTransform rectTransform = State[index].GetComponent<RectTransform>();
        rectTransform.anchoredPosition += new Vector2(move, 0f);
        PlayerPrefs.SetFloat(StatOrder[index] + "X", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat(StatOrder[index] + "Y", rectTransform.anchoredPosition.y);
    } // ���ȹ� �����̱�

    public void OnClick_CloseButton()
    {
        gameObject.SetActive(false);
    } // �˾�â ����

    private void Update()
    {
        CurrentNum = PlayerPrefs.GetInt("ActionNum");
        ActionNumText.text = PlayerPrefs.GetInt("ActionNum").ToString();

        for (int i = 0; i < 5; i++)
        {
            RectTransform rectTransform = State[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(PlayerPrefs.GetFloat(StatOrder[i] + "X"), PlayerPrefs.GetFloat(StatOrder[i] + "Y"));
        }
    } // �ǽð� ȣ���� �ݿ�

    private void DecreaseNum()
    {
        int ChangeNum = PlayerPrefs.GetInt("ActionNum") - 100;
        PlayerPrefs.SetInt("ActionNum", ChangeNum);
    } // ȣ���� ����

    public void OnClick_StatButton(int index)
    {
        StatNum = index;
        StatQuestion.SetActive(true);
        QuestionText.text = "'"+StatText[index]+"'" + "�� �����ϰڽ��ϱ�?";
    }
    public void OnClick_QuestionButton(bool valiable)
    {
        if(valiable && StatNum>=0 && StatNum<=4)
        {
            Increase(StatNum);
            StatQuestion.SetActive(false);
        }
        else if(valiable && StatNum >= 5 && StatNum <= 9)
        {
            Decrease(StatNum - 5);
            StatQuestion.SetActive(false);
        }
        else if(!valiable)
        {
            StatQuestion.SetActive(false);
        }
    }
}
