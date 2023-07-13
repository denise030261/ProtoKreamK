using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionQuestion : MonoBehaviour
{
    private int InteractionNum;
    public void OnClick_Play(int index)
    {
        InteractionNum = 0;
    } // ����ֱ� ��ư
    public void OnClick_Walk(int index)
    {
        InteractionNum = 1;
    } // ��å�ϱ� ��ư
    public void OnClick_Gift(int index)
    {
        InteractionNum = 2;
    } // �����ϱ� ��ư

    private void BlockButton()
    {
        for (int i = 0; i < 3; i++)
        {
            UpbringingGameManager.Instance.BlockInteraction[i].SetActive(true);
        }
    } // ��ȣ�ۿ� ����

    public void OnClick_Button(bool Yes)
    {
        if (Yes)
        {
            if (InteractionNum == 0)
            {
                UpbringingGameManager.Instance.ActionNum++;
            }
            else if (InteractionNum == 1)
            {
                UpbringingGameManager.Instance.ActionNum += Random.Range(0, 2) + 2;
            }
            else if (InteractionNum == 2)
            {
                UpbringingGameManager.Instance.ActionNum += Random.Range(0, 2) + 5;
            }
            UpbringingGameManager.Instance.ActionNumText.text = UpbringingGameManager.Instance.ActionNum.ToString();
            PlayerPrefs.SetInt("ActionNum", UpbringingGameManager.Instance.ActionNum);
            BlockButton();
        }
        gameObject.SetActive(false);
    }
}
