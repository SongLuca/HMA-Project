using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterMemoryy : MonoBehaviour
{
    public float delay = 0.1f;
    private string fullText = "Hello again <username>, complete the tasks in your journey to enhance your mental well-being in your daily life.";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "LEV2Memory";

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
            currentText = "\nWelcome to the second level! Now the difficulty increases. Your challenge is to find matching pairs, expanding your ability to handle a wider range of feelings. Be calm, take the challenge calmly, and try to find the connections between the different emotional expressions. Ready?";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo2")
        {
            currentText = "\nWelcome to the second level! Now the challenge is more complex. Step out of the maze, imagine the intricate corridors as inner challenges, and let yourself be guided through unexpected turns and new discoveries.Breathe deeply and get ready to explore the depths of your inner world. Ready?";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo3")
        {
            currentText = "\nWelcome to the second level! Now the challenge gets a little more articulate. Solve the puzzle and take each piece as a piece of adventure ahead. Have fun, relax and immerse yourself in the beauty of this puzzle. Ready";
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
