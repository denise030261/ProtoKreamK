using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Result : MonoBehaviour
{
    public string jsonFilePath;
    public Text textField; 

    private void Start()
    {
        
        string jsonString = File.ReadAllText(jsonFilePath);

        
        MyData data = JsonUtility.FromJson<MyData>(jsonString);

       
        textField.text = data.times.ToString();

        
        float dividedValue = data.times / 60f;
        textField.text += "\n" + dividedValue.ToString("F3");
    }
}

[System.Serializable]
public class MyData
{
    public int times; 
}
