using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EndButton : MonoBehaviour
{
    public Button exitButton;
    public string jsonFilePath;

    private void Start()
    {

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(Exit);
        }
    }

    public void Exit()
    {

        JSONDATA data = new JSONDATA();
        data.value = 0;

        string jsonString = JsonUtility.ToJson(data);


        string jsonFilePath = "Assets/proto/count.json";


        FileStream fileStream = File.Open(jsonFilePath, FileMode.Create);


        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(jsonString);
        }


        fileStream.Close();


        Application.Quit();
    }
}

[System.Serializable]
public class JSONDATA
{
    public int value; 
}
