using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterMemoryone : MonoBehaviour
{
    public float delay = 0.07f;
    private string currentText = "";
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "LEV1Memory";

    void Start()
    {
        currentText = currentText.Replace("<username>", PlayerPrefs.GetString("username"));
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        // Add an if block to handle different motivational messages
        if (PlayerPrefs.GetString("userType") == "profilo1")
        {
            currentText = "\nWe designed this level to stimulate your mind in a positive way. Your challenge is to find the matching pairs of happy emoji. Are you ready? Remember, Luis, this is a time to focus on positive emotions, be calm and have fun.";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo2")
        {
            currentText = "\nWe designed this level to stimulate your mind in a positive way. Find your way out of the maze. Imagine each step as the untangling of unnecessary thoughts, guiding you to ultimate serenity. Are you ready? Focus and have fun!";
        }
        else if (PlayerPrefs.GetString("userType") == "profilo3")
        {
            currentText = "\nWe designed this level to stimulate your mind in a positive way. Put the puzzle back together and imagine each piece as a precious memory to be rediscovered. Remember, this is a time designed for fun and relaxation. Ready?";
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
