using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class INTRODUCTION2LEVEL : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Get ready for greater challenges!\n\n This stage demands wisdom and intuition. Every choice you make will either bring you closer or farther away from triumph and from the power to shape your destiny!\n So, buckle up, time is ticking!\n\nREADY, SET, GO!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI introsecondLevelText; // Componente TextMeshPro per visualizzare il testo

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
            introsecondLevelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        SceneManager.LoadScene("Scenes/LABIRINTO2"); //Carico secondo livello
    }
}
