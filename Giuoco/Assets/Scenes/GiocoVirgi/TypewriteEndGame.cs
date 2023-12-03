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
    public string nextSceneName = "Memory";

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