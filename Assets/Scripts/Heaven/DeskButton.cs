using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskButton : MonoBehaviour
{
    private bool IsOpen=false; // ��ư ������ ����
    public bool IsExist; // �������� ���� ����

    private Vector2 originalPosition;
    public RectTransform rectTransform;

    private void Start()
    {
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnClick_Open()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            Vector2 newPosition = new Vector2(originalPosition.x -1300f, originalPosition.y);
            rectTransform.anchoredPosition = newPosition;
        } // ��ư ������
        else
        {
            IsOpen = false;
            Vector2 newPosition = new Vector2(originalPosition.x, originalPosition.y);
            rectTransform.anchoredPosition = newPosition;
        } // ��ư �ݱ�

    }
}
