using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpbringingTutorialInventory : MonoBehaviour
{
    private int order = 0;
    private int Day;
    private int TutorialDay;
    private bool IsClick = false;

    public Text ChatText;
    public GameObject ChatSet;
    public GameObject[] TutorialEat;
    public GameObject ShopButton;
    public GameObject TutorialInventory;
    public GameObject ItemTutorial;
    public GameObject UseTutorial;
    public GameObject Stat;
    public GameObject IconImage;
    public RectTransform ChatTransform;

    private string[] Chat = { "������ ������ �̰����� Ȯ���� �� �ֽ��ϴ�.", "��� ������ ������ ���� ���̳׿�. �� �� Ȯ���غ��ðھ��?",
    "������ ���Ŀ� ���� ������ ���⼭ Ȯ���� �� �ֽ��ϴ�.","������ �Ϸ翡 �� ������ ���� �� ������, ������ �ϳ��ۿ� ������ ���ɿ��� �� ������ �Կ����ô�.",
    "�̷��� ������ �Կ��� �� �̰����� ������ ������ ���ϴ� ���� Ȯ���� �� �ֽ��ϴ�."};

    private void Awake()
    {
        Day = PlayerPrefs.GetInt("Day");
        PlayerPrefs.SetInt("Day", Day);
        TutorialDay = PlayerPrefs.GetInt("TutorialDay", 0);
        PlayerPrefs.SetInt("TutorialDay", TutorialDay);
        ItemTutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && order == 3 && IsClick)
        {
            ChatDisplay();
            UseTutorial.SetActive(true);
        }
        else if(Input.GetMouseButtonDown(0) && order == Chat.Length)
        {
            IconImage.SetActive(false);
            Stat.SetActive(false);
            gameObject.SetActive(false);
            // ȣ���� gameObject�� �ø�
        }
    }

    public void Onclick_Cancel()
    {
        ShopButton.SetActive(false);
        TutorialEat[0].SetActive(true);
        TutorialEat[1].SetActive(true);
        ChatSet.SetActive(true);
        IsClick = false;
        ChatDisplay();
        order--;
    }

    public void Onclick_TutorialInventory()
    {
        TutorialEat[0].SetActive(false);
        TutorialEat[1].SetActive(false);
        TutorialInventory.SetActive(true);
        ItemTutorial.SetActive(true);
        order++;
        ChatDisplay();
        ChatTransform.anchoredPosition = new Vector2(0, 180);
    }

    public void Onclick_ItemTutorial()
    {
        ChatDisplay();
        IsClick = true;
        ChatTransform.anchoredPosition = new Vector2(0, -296);
    }

    public void Onclick_Use()
    {
        UseTutorial.SetActive(false);
        ChatSet.SetActive(false);
    }
    void ChatDisplay()
    {
        ChatText.text = Chat[order];
        order++;
    }
    public void Onclick_Yes()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        TutorialInventory.SetActive(false);
        Stat.SetActive(true);
        yield return new WaitForSeconds(2f);
        ChatSet.SetActive(true);
        ChatText.text = Chat[Chat.Length - 1];
        order = Chat.Length;
    }
}
