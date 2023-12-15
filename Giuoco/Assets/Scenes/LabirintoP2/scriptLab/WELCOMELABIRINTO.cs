using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager
using UnityEngine;
using UnityEngine.SceneManagement;

public class WELCOMELABIRINTO : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
<<<<<<< HEAD
    private string fullText = "Hi Andrew! We designed this level to stimulate your mind in a positive way. Find your way out of the maze. Imagine each step as the untangling of unnecessary thoughts, guiding you to ultimate serenity. Are you ready? Focus and have fun!"; // Testo completo da mostrare
=======
    private string fullText = "Hi <username>! We designed this level to stimulate your mind in a positive way. Find your way out of the maze. Imagine each step as the untangling of unnecessary thoughts, guiding you to ultimate serenity. Are you ready? Focus and have fun!"; // Testo completo da mostrare
>>>>>>> f7bdb52ee75ce186a7f1d8fc4e0a617793a05e6e
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

        SceneManager.LoadScene("LABIRINTO1"); //Carico il primo livello
    }
}


