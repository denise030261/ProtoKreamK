using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventorySetting : MonoBehaviour
{
    public GameObject ImageDesribe;
    public GameObject TextDescribe;
    public GameObject[] IsImage; // ���� ������ SetActive�� false ������ true�� ����
    public GameObject TrashQuestion;
    public GameObject UseQuestion;

    public static UI_InventorySetting Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public void OnClick_InventoryCancel()
    {
        gameObject.SetActive(false);
    } // 'X' ��ư 

    public void OnClick_Trash()
    {
        for(int i=0;i<20;i++)
        {
            if(UI_InvenotrySlot.Instance.SelectedBoundary[i].activeSelf == true)
            {
                TrashQuestion.SetActive(true);
            }
        } // ������ �Ǿ����� �ȵǾ�����
    } // '������' ��ư 

    public void OnClick_Use()
    {
        for (int i = 0; i < 20; i++)
        {
            if (UI_InvenotrySlot.Instance.SelectedBoundary[i].activeSelf == true)
            {
                UseQuestion.SetActive(true);
            }
        } // ������ �Ǿ����� �ȵǾ�����
    } // '���' ��ư

}
