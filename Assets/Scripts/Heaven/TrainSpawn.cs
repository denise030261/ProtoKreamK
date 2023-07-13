using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawn : MonoBehaviour
{
    public GameObject[] spawnableObject;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        int randomIndex = Random.Range(0, spawnableObject.Length); // ������ �ε��� ����
        GameObject randomObject = spawnableObject[randomIndex]; // ���õ� GameObject

        randomObject.SetActive(true); // GameObject Ȱ��ȭ
    }

}
