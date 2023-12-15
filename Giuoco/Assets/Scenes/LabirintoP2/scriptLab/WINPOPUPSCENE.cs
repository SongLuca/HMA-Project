using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WINPOPUPSCENE : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Congratulations! \n Your navigation skills are truly exceptional. \n \n A-maze-ing job, adventurer!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI winpopupText; // Componente TextMeshPro per visualizzare il testo
    

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
            winpopupText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        SceneManager.LoadScene("LABIRINTO(TRA2LIVELLI)");
    }

}
