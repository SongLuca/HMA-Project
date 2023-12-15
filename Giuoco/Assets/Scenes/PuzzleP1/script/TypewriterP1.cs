using UnityEngine;
using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager

public class Typewriterpone : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Enter a world of colour and transformation, where the power to regenerate the mind becomes your tool to overcome challenges. Welcome to the journey to a brighter well-being with our thought-remodelling video game."; // Testo completo da mostrare
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
