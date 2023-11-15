using UnityEngine;
using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    public string fullText; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI textDisplay; // Componente TextMeshPro per visualizzare il testo

    void Start()
    {
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
