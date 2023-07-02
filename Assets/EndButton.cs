using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EndButton : MonoBehaviour
{
    public Button exitButton; // Exit 버튼
    public string jsonFilePath; // JSON 파일의 상대 경로

    private void Start()
    {
        // exitButton에 Exit() 메서드를 버튼 클릭 이벤트로 할당
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(Exit);
        }
    }

    public void Exit()
    {
        // JSON 파일을 0으로 초기화합니다.
        JSONDATA data = new JSONDATA();
        data.value = 0;

        // JSON 데이터를 문자열로 변환합니다.
        string jsonString = JsonUtility.ToJson(data);

        // JSON 파일의 상대 경로를 생성합니다.
        string jsonFilePath = "Assets/proto/count.json";

        // JSON 파일을 쓰기 모드로 엽니다.
        FileStream fileStream = File.Open(jsonFilePath, FileMode.Create);

        // 파일에 JSON 데이터를 씁니다.
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(jsonString);
        }

        // 파일을 닫습니다.
        fileStream.Close();

        // 어플리케이션 종료 코드
        Application.Quit();
    }
}

[System.Serializable]
public class JSONDATA
{
    public int value; // 값을 저장할 변수
}
