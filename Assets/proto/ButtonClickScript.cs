using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtonClickScript : MonoBehaviour
{
    public Image image1;  // 첫 번째 이미지
    public Image image2;  // 두 번째 이미지
    public Image correctImage;  // 색상이 같을 경우 활성화할 이미지
    public Image wrongImage;  // 색상이 다를 경우 활성화할 이미지

    private string filePath;  // JSON 파일 경로

    private class JsonData
    {
        public int times;
    }

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // JSON 파일 경로 설정
        filePath = Path.Combine(Application.dataPath, "proto", "count.json");
    }

    public void OnButtonClick()
    {
        if (image1.color.Equals(image2.color))
        {
            // 색상이 같을 경우
            correctImage.gameObject.SetActive(true);
            wrongImage.gameObject.SetActive(false);
            IncrementTimes();
        }
        else
        {
            // 색상이 다를 경우
            correctImage.gameObject.SetActive(false);
            wrongImage.gameObject.SetActive(true);
        }
    }

    private void IncrementTimes()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            JsonData data = JsonUtility.FromJson<JsonData>(jsonData);
            if (data != null)
            {
                data.times++;
                string updatedJsonData = JsonUtility.ToJson(data);
                File.WriteAllText(filePath, updatedJsonData);
            }
            else
            {
                Debug.LogError("Failed to parse JSON data.");
            }
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + filePath);
        }
    }
}
