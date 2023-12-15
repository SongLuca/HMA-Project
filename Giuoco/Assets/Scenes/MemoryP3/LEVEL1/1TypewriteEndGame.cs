using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterEndGame : MonoBehaviour
{
    public float delay = 0.05f;
<<<<<<< HEAD
    private string fullText = "Luis, congratulations on getting through the first level!\n\nYou have dispelled some of the shadows that were dimming your inner light.\n\nYour strength is palpable.\n\nContinue this path!";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "P3Cervello2";   // qui metti nome scena
=======
    private string fullText = "Extraordinary, <username>! \n\n You have enlightened your mind. The time has come to reveal the thought. \nAre you ready to face it?";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "Cervello 2";   // qui metti nome scena
>>>>>>> f7bdb52ee75ce186a7f1d8fc4e0a617793a05e6e

    void Start()
    {
        // Aggiungi lo username alla stringa fullText
        fullText = fullText.Replace("<username>", GlobalData.username);
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

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }
}
