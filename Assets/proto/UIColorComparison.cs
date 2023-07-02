using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIColorComparison : MonoBehaviour
{
    public Image image1;  // 첫 번째 이미지
    public Image image2;  // 두 번째 이미지
    public Image image3;  // 세 번째 이미지
    public Image correctImage;  // 색상이 모두 다를 경우 활성화할 이미지
    public Image wrongImage;  // 색상이 같은 경우가 존재할 경우 활성화할 이미지

    private string filePath;  // JSON 파일 경로
    private int countValue; // 현재 값

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // JSON 파일 경로 설정
        string folderPath = Path.Combine(Application.dataPath, "proto");
        filePath = Path.Combine(folderPath, "count.json");

        // JSON 파일 로드
        LoadJSON();

        // 현재 값 설정
        countValue = LoadCountValue();
    }

    public void OnButtonClick()
    {
        if (image1.color != image2.color && image1.color != image3.color && image2.color != image3.color)
        {
            // 색상이 모두 다를 경우
            correctImage.gameObject.SetActive(true);
            wrongImage.gameObject.SetActive(false);

            // 현재 값 증가
            countValue++;

            // JSON 파일 업데이트
            SaveCountValue(countValue);
        }
        else
        {
            // 색상이 같은 경우가 존재할 경우
            correctImage.gameObject.SetActive(false);
            wrongImage.gameObject.SetActive(true);
        }
    }

    private void LoadJSON()
    {
        if (!File.Exists(filePath))
        {
            // JSON 파일이 없을 경우 초기값으로 생성
            SaveCountValue(0);
        }
    }

    private int LoadCountValue()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            ColorComparisonData data = JsonUtility.FromJson<ColorComparisonData>(jsonData);
            return data.times;
        }
        else
        {
            return 0;
        }
    }

    private void SaveCountValue(int count)
    {
        ColorComparisonData data = new ColorComparisonData();
        data.times = count;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jsonData);
    }
}

[System.Serializable]
public class ColorComparisonData
{
    public int times;
}
