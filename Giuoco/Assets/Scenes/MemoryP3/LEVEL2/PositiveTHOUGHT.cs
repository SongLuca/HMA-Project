using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ThoughtPositive : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Motivational Phrase: \n Every day is an opportunity to discover something new.\n I will find my hobby, a passion that adds color to my routine.\n Life is full of adventures big and small, and I am ready to explore them.\n Every step out of my comfort zone is a step toward a more fulfilling and exciting life.";

    private string currentText = "";
    public TextMeshProUGUI textDisplay;

    void Start()
    {
        currentText = initialText;
        StartCoroutine(ShowInitialText());
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
    }
}
