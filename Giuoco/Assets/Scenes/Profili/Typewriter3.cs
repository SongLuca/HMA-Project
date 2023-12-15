using UnityEngine;
using System.Collections;
using TMPro;

public class Typewriter3 : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string[] textParts = new string[]
    {
        "Welcome to MindCraft LUIS, where your emotions take shape. You surface as a person with depth and complexity, wrestling with some shadows. \nA negative thought has touched your mind.",
        "Your mission is a profound journey: go beyond the levels and uncover the negative thought behind the shadows.",
        "Be brave, LUIS, and remember that even in the thickest shadows, your inner light can shine. Ready?"
    };

    private TextMeshProUGUI textDisplay; // Componente TextMeshPro per visualizzare il testo
    private int currentPartIndex = 0;
    private string currentText = ""; // Testo attualmente visualizzato

    void Start()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while (currentPartIndex < textParts.Length)
        {
            for (int i = 0; i <= textParts[currentPartIndex].Length; i++)
            {
                currentText = textParts[currentPartIndex].Substring(0, i);
                textDisplay.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            // Aspetta un po' prima di passare alla prossima parte
            yield return new WaitForSeconds(3f);

            // Cancella il testo attuale
            for (int i = currentText.Length; i >= 0; i--)
            {
                currentText = textParts[currentPartIndex].Substring(0, i);
                textDisplay.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            // Passa alla prossima parte di testo
            currentPartIndex++;

            // Aspetta prima di iniziare la prossima parte
            yield return new WaitForSeconds(1f);
        }
    }
}
