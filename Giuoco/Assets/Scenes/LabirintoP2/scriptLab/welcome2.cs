using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager
using UnityEngine;
using UnityEngine.SceneManagement;

public class WELCOMELABIRINTOOO : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string fullText = "Hi <username>! \n\n Welcome to the second level. \n Now the challenge is more complex. \n Step out of the maze, imagine the intricate corridors as inner challenges, and let yourself be guided through unexpected turns and new discoveries. \n\n Ready? "; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI welcomeText; // Componente TextMeshPro per visualizzare il testo
    
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
            welcomeText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        SceneManager.LoadScene("LABIRINTO2"); //Carico il primo livello
    }
}

