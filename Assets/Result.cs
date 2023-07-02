using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Result : MonoBehaviour
{
    public string jsonFilePath; // JSON 파일의 상대 경로
    public Text textField; // 텍스트를 표시할 UI 텍스트

    private void Start()
    {
        // JSON 파일을 읽어옵니다.
        string jsonString = File.ReadAllText(jsonFilePath);

        // JSON 데이터를 MyData 클래스로 변환합니다.
        MyData data = JsonUtility.FromJson<MyData>(jsonString);

        // times 값을 텍스트 필드에 할당합니다.
        textField.text = data.times.ToString();

        // times 값을 60으로 나눈 값을 다음 줄에 띄워줍니다.
        float dividedValue = data.times / 60f;
        textField.text += "\n" + dividedValue.ToString("F3");
    }
}

[System.Serializable]
public class MyData
{
    public int times; // 값을 읽어올 변수
}
