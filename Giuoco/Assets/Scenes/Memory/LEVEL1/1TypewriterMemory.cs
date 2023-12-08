using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterMemoryone : MonoBehaviour
{
    public float delay = 0.1f;
    private string fullText = "Hello again <username>, complete the tasks in your journey to enhance your mental well-being in your daily life.";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "LEV1Memory";

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