using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpbringingTutorial : MonoBehaviour
{
    public int Delay;
    public Text ChatText;
    public GameObject ChatSet;
    public GameObject BackGroundImage;
    public GameObject TutorialStat;
    public GameObject TutorialShop;
    public Image BlockImage;


    private int order;
    private int Day;
    private int TutorialDay;
    private bool IsClick = false;

    private string[] FirstChat = {  "������ ������ �Ⱓ�� 20���� �����ϰ� �ֽ��ϴ�.","�� ���ɵ��� 20�� ������ �Ⱓ���� ������ ���� ���� �Բ� ����� ��ã������.",
    "Ư��, � ������ �����Ŀ� ���� ����� �޶����� �� ���ҽ��ϴ�.", "���� �� ������ ����̶��, �������� �Ǹ��ϴ� Ư���� �������� ������ ����� �� ��Ȯ�ϰ� ã�� ���� �� ���� �̴ϴ�.",
        "���� ���� �迡 �ٷ� ������ �̿��غ��ô�."};

    private void Awake()
    {
        Day = PlayerPrefs.GetInt("Day");
        PlayerPrefs.SetInt("Day", Day);
        TutorialDay = PlayerPrefs.GetInt("TutorialDay", 0);
        PlayerPrefs.SetInt("TutorialDay", TutorialDay);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Day == 1 && TutorialDay == 1)
        {
            gameObject.SetActive(true);
            ChatSet.SetActive(false);
            BackGroundImage.SetActive(false);
            StartCoroutine(Wait());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 2 == order && IsClick)
        {
            TutorialStat.SetActive(true);
            FirstChatDisplay();
        }
        else if (Input.GetMouseButtonDown(0) && 4 == order && IsClick)
        {
            TutorialStat.SetActive(false);
            TutorialShop.SetActive(true);
            FirstChatDisplay();
        }
        else if (Input.GetMouseButtonDown(0) && FirstChat.Length > order && IsClick)
        {
            FirstChatDisplay();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        ChatSet.SetActive(true);
        BackGroundImage.SetActive(true);
        ChatText.text = FirstChat[0];
        order = 1;
        IsClick = true;
    } // ��ٸ��� ���� ���� ȭ�� �����ֱ�
    void FirstChatDisplay()
    {
        ChatText.text = FirstChat[order];
        order++;
    }
}
