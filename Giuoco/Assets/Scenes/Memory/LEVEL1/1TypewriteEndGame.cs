using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterEndGame : MonoBehaviour
{
    public float delay = 0.1f;
    private string fullText = "Congratulations on completing the game! Today you've made some steps ahead in your healing journey. Way to go <username>!";
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
            currentText = "\n <username>, congratulations on getting through the first level! You have dispelled some of the shadows that were dimming your inner light. Your strength is palpable.Continue on this path!";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo2")
        {
            currentText = "\n<username>, you have crossed the first level with strength and resilience. This is just the beginning of your journey, face the next level with the same determination. Way to go!";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo3")
        {
            currentText = "\nUnbelievable, <username>! You have successfully passed the first level. Your determination is a shining beacon chasing away the darkness. The journey continues, be brave!";
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
