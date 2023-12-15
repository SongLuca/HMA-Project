using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThoughtNeg : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Your Negative Thought: \n\n My daily life seems immersed in a monotonous routine, devoid of stimulation and new passions.\n The lack of a hobby or new challenges leaves me trapped in a feeling of stagnation.\n Perhaps I could do more to make my life more interesting, but doubt and inertia hold me back.";
    private string currentText = "";
    public TextMeshProUGUI textDisplay;

    // Aggiungi una variabile per il nome della scena da caricare
    public string sceneToLoad;

    void Start()
    {
        currentText = initialText;
        StartCoroutine(ShowInitialText());
    }

    IEnumerator ShowInitialText()
    {
        for (int i = 0; i <= initialText.Length; i++)
        {
            currentText = initialText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);

        // Aggiungi il cambio di scena alla fine dell'animazione del testo
        LoadScene();
    }

    // Aggiungi un metodo per il cambio di scena
    void LoadScene()
    {
        // Carica la scena specificata
        SceneManager.LoadScene(sceneToLoad);
    }
}
