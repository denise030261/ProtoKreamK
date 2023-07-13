using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InvenotrySlot : MonoBehaviour
{
    public GameObject[] SelectedBoundary;
    public Image[] SelectedImage;
    public Button[] buttons;
    public GameObject[] Icon;

    private int[] IsCheck = new int[18]; // �������� �� ��������
    private int SelectedNum; // ���õ� ����
    private Image EmptyImage; // �� ����

    public static UI_InvenotrySlot Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        Initialized();
    }
    public void Selected(Button button)
    {
        for (int i=0;i<18;i++)
        {
            if (buttons[i] == button)
            {
                if (IsCheck[i] == 0 && SelectedImage[i].GetComponent<Image>().sprite != null)
                {
                    IsCheck[i] = 1;
                    SelectedBoundary[i].SetActive(true);
                    UI_InventoryInformation.Instance.SwitchImage(SelectedImage[i]);
                    SelectedNum = i;
                } // ������ �� �̹����� �ִ� ���
                else if (IsCheck[i] == 0 && SelectedImage[i].GetComponent<Image>().sprite == null)
                {
                    UI_InventoryInformation.Instance.SwitchImageNull();
                } // ������ �� �̹����� ���� ���
                else if (IsCheck[i] == 1)
                {
                    IsCheck[i] = 0;
                    SelectedBoundary[i].SetActive(false);
                    UI_InventoryInformation.Instance.SwitchImageNull();
                } // ���� ��ҵ� �� �׵θ��� �̹��� ���� �����
            }
            else if (IsCheck[i] == 1)
            {
                IsCheck[i] = 0;
                SelectedBoundary[i].SetActive(false);
            } // ��ư ������ �ʴ� �͵��� ����
        }
    }
    public void Deleted()
    {
        SelectedImage[SelectedNum].GetComponent<Image>().sprite = null;
        Icon[SelectedNum].SetActive(false);
        SelectedBoundary[SelectedNum].SetActive(false);
        UI_InventoryInformation.Instance.SwitchImageNull();
    } // �κ��丮 �̹��� �� ū �̹��� ����
    private void Initialized()
    {
        for (int i = 0; i < 18; i++)
        {
            IsCheck[i] = 0;
            SelectedBoundary[i].SetActive(false);
            UI_InventoryInformation.Instance.SwitchImageNull();
        }
    } // �ʱ�ȭ ���·� �����.
}
