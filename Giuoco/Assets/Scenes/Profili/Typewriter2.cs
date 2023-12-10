using UnityEngine;
using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager

public class Typewriter2 : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Hello, <username>! Welcome to MindCraft, where your emotions take shape. From your answers, you emerge a thoughtful and aware person facing some daily challenges.  A negative thought has touched your mind and darkened your inner light. " +
        "Your mission is delicate: go over the levels and discover the negative thought behind the shadow. We know there are challenges, but this journey is an opportunity to discover the strength that lies within you. Be brave, Andrew, and remember that even in the shadows you will find the strength to shine.Ready to begin this extraordinary journey within yourself?"; // Testo completo da mostrare
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
