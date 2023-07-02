using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float gameDuration = 180f; // 게임 시간 (3분)
    public Text timerText; // 남은 시간을 표시할 UI Text
    public Button exitButton; // Exit 버튼
    public GameObject startButtonPrefab; // 시작 버튼이 포함된 프리팹
    public GameObject newPrefab; // 새로운 프리팹
    public Button activatePrefabButton; // 새로운 프리팹을 활성화할 버튼
    public Button[] interactiveButtons; // 상호작용 가능한 버튼들의 배열

    private float timeLeft; // 남은 시간
    private bool allowInteraction = false; // 상호작용 허용 여부

    private void Start()
    {
        Time.timeScale = 1f; // 시간의 흐름을 1로 설정

        // 게임 시작 시 exitButton 비활성화
        if (exitButton != null)
        {
            exitButton.interactable = false;
        }

        // 상호작용 가능한 버튼들 비활성화
        SetInteractiveButtonsInteractable(false);

        // 프리팹 내의 시작 버튼 찾기
        if (startButtonPrefab != null)
        {
            Button startButton = startButtonPrefab.GetComponentInChildren<Button>();
            if (startButton != null)
            {
                startButton.onClick.AddListener(StartGame);
            }
        }

        // activatePrefabButton 할당 및 이벤트 리스너 추가
        if (activatePrefabButton != null)
        {
            activatePrefabButton.onClick.AddListener(ActivateNewPrefab);
        }
    }

    private void Update()
    {
        if (allowInteraction)
        {
            timeLeft -= Time.deltaTime; // 시간 감소

            if (timeLeft <= 0f)
            {
                EndGame(); // 게임 종료
            }
        }

        UpdateTimerText();
        CheckInteractiveButtons();
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            if (allowInteraction)
            {
                timerText.text = "남은 시간: " + Mathf.CeilToInt(timeLeft).ToString();
            }
            else
            {
                timerText.text = ""; // 상호작용이 불가능할 때는 텍스트를 숨깁니다.
            }
        }
    }

    private void EndGame()
    {
        // 게임 종료 처리
        allowInteraction = false; // 상호작용 금지

        // exitButton 활성화
        if (exitButton != null)
        {
            exitButton.interactable = true;
        }

        // 상호작용 가능한 버튼들 비활성화
        SetInteractiveButtonsInteractable(false);
    }

    private void SetInteractiveButtonsInteractable(bool interactable)
    {
        foreach (Button button in interactiveButtons)
        {
            if (button != null)
            {
                button.interactable = interactable;
            }
        }
    }

    private void CheckInteractiveButtons()
    {
        bool shouldEnableButtons = allowInteraction && timeLeft > 0f;

        foreach (Button button in interactiveButtons)
        {
            if (button != null)
            {
                button.interactable = shouldEnableButtons;
            }
        }
    }

    public void StartGame()
    {
        allowInteraction = true; // 상호작용 허용
        timeLeft = gameDuration; // 게임 시간 설정

        // 시작 버튼 비활성화
        if (startButtonPrefab != null)
        {
            startButtonPrefab.SetActive(false);
        }

        // exitButton 비활성화
        if (exitButton != null)
        {
            exitButton.interactable = false;
        }

        // 상호작용 가능한 버튼들 활성화
        SetInteractiveButtonsInteractable(true);
    }

    public void ActivateNewPrefab()
    {
        if (newPrefab != null)
        {
            newPrefab.SetActive(true); // 프리팹 활성화
        }
    }
}
