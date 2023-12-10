using UnityEngine;
using System.Collections;
using TMPro;

public class Typewriter1 : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Hello, <username>! Welcome to MindCraft, where your emotions take shape. From your answers, a sociable and quiet person emerges. A negative thought has touched your mind and darkened your inner light. " +
        "Your mission is clear: go beyond the levels and discover the negative thought behind the shadow. Be brave, <username>, and remember that even in the shadows you will find the strength to shine. Ready to begin this extraordinary journey within yourself?";
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI textDisplay; // Componente TextMeshPro per visualizzare il testo

    void Start()
    {
        Debug.Log("TYpewriter started\n");
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}