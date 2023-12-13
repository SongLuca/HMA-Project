using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Thoughtt : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Your Negative Thought: \n\n My daily life seems immersed in a monotonous routine, devoid of stimulation and new passions.\n The lack of a hobby or new challenges leaves me trapped in a feeling of stagnation.\n Perhaps I could do more to make my life more interesting, but doubt and inertia hold me back.";

    private string motivationalText = "Motivational Phrase: \n Every day is an opportunity to discover something new.\n I will find my hobby, a passion that adds color to my routine.\n Life is full of adventures big and small, and I am ready to explore them.\n Every step out of my comfort zone is a step toward a more fulfilling and exciting life.";

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
