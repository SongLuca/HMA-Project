using UnityEngine;
using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager

public class Typewriter3 : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Hello, <username>! Welcome to MindCraft, where your emotions take shape. From your answers, a person with depth and complexity emerges, struggling with some shadows. Some negative thoughts have grazed your mind and darkened your inner light. Your mission is a meaningful journey: go beyond the levels and reveal the negative thought behind the shadows. " +
        "We know there are challenges, but this journey is an opportunity to discover the strength that resides within you. Be brave, <username>, and remember that even in the thickest shadows, your inner light can shine.Ready to begin this extraordinary journey within yourself?"; // Testo completo da mostrare
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
