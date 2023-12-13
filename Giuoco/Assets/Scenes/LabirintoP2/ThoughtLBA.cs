using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Thoughtlab : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Negative Thinking:\n\n My mind is a whirlwind of anxious thoughts, unable to focus on anything concrete.\n Every moment is a struggle, with the constant tension of not being able to relax. Worries multiply, feeding the fear of a dark future looming over me.";

    private string motivationalText = "Motivational Phrase: In the turmoil of my mind, I will find calm. Each breath is a step toward calmness, and each effort to focus is a step toward control. I can face present and future challenges with clarity and determination. My mind is stronger than any storm, and serenity is my goal.";

    private string currentText = "";
    public TextMeshProUGUI textDisplay;
    public Button nextButton;

    void Start()
    {
        StartCoroutine(ShowInitialText());
        nextButton.interactable = true; // Assicurati che il pulsante sia cliccabile
        nextButton.onClick.AddListener(NextButtonClick);
    }


    IEnumerator ShowInitialText()
    {
        for (int i = 0; i <= initialText.Length; i++)
        {
            currentText = initialText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);
        nextButton.interactable = true;
    }

    public void NextButtonClick()
    {
        StartCoroutine(ShowMotivationalText());
    }

    IEnumerator ShowMotivationalText()
    {
        textDisplay.text = "";
        nextButton.interactable = false;

        for (int i = 0; i <= motivationalText.Length; i++)
        {
            currentText = motivationalText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(3f); // Aggiunto un ritardo di 3 secondi dopo il testo motivazionale
        // SceneManager.LoadScene(nextSceneName);
    }
}
