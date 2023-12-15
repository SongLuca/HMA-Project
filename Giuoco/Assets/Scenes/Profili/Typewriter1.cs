using UnityEngine;
using System.Collections;
using TMPro;

public class Typewriter1 : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string[] textParts = new string[]
    {
<<<<<<< HEAD
        "Welcome to MindCraft HENRY, where emotions take shape. You emerge as a sociable and quiet person, but a negative thought has dimmed your inner light.",
        "Your mission is clear: overcome the levels and uncover the negative thought behind the shadow.",
        "Be brave, HENRY, and remember that even in darkness, you will find the strength to shine. Ready?"
=======
        "Welcome to MindCraft <username>, where emotions take shape. You emerge as a sociable and quiet person, but a negative thought has dimmed your inner light.",
        "Your mission is clear: overcome the levels and uncover the negative thought behind the shadow.",
        "Be brave, <username>, and remember that even in darkness, you will find the strength to shine. Ready?"
>>>>>>> f7bdb52ee75ce186a7f1d8fc4e0a617793a05e6e
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
            yield return new WaitForSeconds(2f);

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

