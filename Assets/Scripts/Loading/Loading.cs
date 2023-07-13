using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Text textComponent; // �ε� �ؽ�Ʈ
    public List<Image> imageComponents; // �ε� �׸�
    public float fadeInSpeed = 0.1f; // ���̵� �� �ӵ�
    public float fadeOutSpeed = 0.1f; // ���̵� �ƿ� �ӵ�
    public int repeatCount = 1; // �ݺ� Ƚ��

    private string originalText;
    private List<string> characters;
    private int Day;

    private void Awake()
    {
        Day = PlayerPrefs.GetInt("Day", 0);
        PlayerPrefs.SetInt("Day", Day);

        float BGMVolume = PlayerPrefs.GetFloat("BGM", 0.6f); // �� ó���� BGM�� 0.6���� �����.
        PlayerPrefs.SetFloat("BGM", BGMVolume);
        float SFXVolume = PlayerPrefs.GetFloat("SFX", 0.6f); // �� ó���� BGM�� 0.6���� �����.
        PlayerPrefs.SetFloat("SFX", SFXVolume);
    }

    private void Start()
    {
        originalText = textComponent.text; // �ε� �ؽ�Ʈ ����
        characters = SplitTextIntoCharacters(originalText); // �ؽ�Ʈ ������

        if (imageComponents.Count < characters.Count)
        {
            int countToAdd = characters.Count - imageComponents.Count;
            for (int i = 0; i < countToAdd; i++)
            {
                Image newImage = Instantiate(imageComponents[0]);
                newImage.transform.SetParent(transform);
                newImage.gameObject.SetActive(false);
                imageComponents.Add(newImage);
            }
        }

        StartCoroutine(ShowLoading());

        Invoke("LoadNextScene", 13f);
    }

    private IEnumerator ShowLoading()
    {
        for (int r = 0; r < repeatCount; r++)
        {
            ResetLoading();

            foreach (string character in characters)
            {
                textComponent.text += character;
                yield return new WaitForSeconds(fadeInSpeed);
            } // �ؽ�Ʈ ��Ÿ���� �ð�

            yield return new WaitForSeconds(1f);

            foreach (Image image in imageComponents)
            {
                image.gameObject.SetActive(true);
                image.canvasRenderer.SetAlpha(0f);
                image.CrossFadeAlpha(1f, fadeInSpeed, true);
                yield return new WaitForSeconds(fadeInSpeed);
            } // �̹��� ��Ÿ���� �ð�

            float maxFadeOutTime = characters.Count * fadeOutSpeed;
            float currentFadeOutTime = 0f;

            while (currentFadeOutTime < maxFadeOutTime)
            {
                float deltaTime = Time.deltaTime;
                currentFadeOutTime += deltaTime;

                foreach (Image image in imageComponents)
                {
                    float fadeAmount = Mathf.Lerp(1f, 0f, currentFadeOutTime / maxFadeOutTime);
                    image.canvasRenderer.SetAlpha(fadeAmount);
                }

                textComponent.canvasRenderer.SetAlpha(Mathf.Lerp(1f, 0f, currentFadeOutTime / maxFadeOutTime));

                yield return null;
            }

            foreach (Image image in imageComponents)
            {
                image.gameObject.SetActive(false);
            }

            textComponent.text = "";
        }
    }

    private List<string> SplitTextIntoCharacters(string text)
    {
        List<string> characters = new List<string>();
        foreach (char c in text)
        {
            characters.Add(c.ToString());
        }
        return characters;
    }

    private void ResetLoading()
    {
        foreach (Image image in imageComponents)
        {
            image.canvasRenderer.SetAlpha(0f);
        }

        textComponent.canvasRenderer.SetAlpha(1f);
        textComponent.text = "";
    }

    private void LoadNextScene()
    {
        if (Day == 0)
            SceneManager.LoadScene("Tutorial");
        else
            SceneManager.LoadScene("Heaven");
    } // ���� ������ �Ѿ��
}
