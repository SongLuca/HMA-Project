using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FINALWINPOPUP : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Congratulations, intrepid traveler!\n \n The echos of your choices reverberate and the path ahead you is now illuminated by your indomitable spirit. \n\n Well done!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI finalwinText; // Componente TextMeshPro per visualizzare il testo

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
            finalwinText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        // SceneManager.LoadScene("nome prossima scena");
    }
}
