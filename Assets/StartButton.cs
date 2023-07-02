using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject prefabToDisable;

    private void Start()
    {
        Button startButton = GetComponent<Button>();
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    public void OnStartButtonClicked()
    {
       
        if (prefabToDisable != null)
        {
            prefabToDisable.SetActive(false);
        }
    }
}
