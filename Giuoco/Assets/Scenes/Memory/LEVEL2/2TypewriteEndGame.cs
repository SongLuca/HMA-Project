using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterEndGamee : MonoBehaviour
{
    public float delay = 0.1f;
    private string fullText = "";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "";   // qui metti nome scena

    void Start()
    {
        // Aggiungi lo username alla stringa fullText
        fullText = fullText.Replace("<username>", GlobalData.username);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        // Add an if block to handle different motivational messages
        if (PlayerPrefs.GetString("userType") == "profilo1")
        {
            currentText = "\nExtraordinary, <username>! You have enlightened your mind. The time has come to reveal the thought. Are you ready to face it? ";
         }
        else if (PlayerPrefs.GetString("userType") == "profilo2")
        {
            currentText = "\nExtraordinary, <username>! You have enlightened your mind. The time has come to reveal the thought. Are you ready to face it?";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo3")
        {
            currentText = "\nExtraordinary, <username>! You have enlightened your mind. The time has come to reveal the thought. Are you ready to face it?";
        }

        for (int i = 0; i <= currentText.Length; i++)
        {
            currentText = currentText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }
}