using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Text domandaText;
    public Button[] rispostaButtons;
    public InputField inputUsername; // Cambiato da Text a InputField

    private List<int> risposte = new List<int>();
    private int indiceRisposta = 0;
    private int sommaRisposte = 0;

    // Singleton pattern
    private static QuestionManager _instance;
    public static QuestionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<QuestionManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("QuestionManager");
                    _instance = go.AddComponent<QuestionManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        MostraProssimaDomandaQuestionManager();

        // Aggiungi un listener per l'evento "EndEdit" dell'InputField
        inputUsername.onEndEdit.AddListener(OnInputUsernameEndEdit);
    }

    private void OnInputUsernameEndEdit(string value)
    {
        // Gestisci l'evento di fine modifica dell'InputField (quando l'utente preme "Invio")
        // Esegui qui le azioni desiderate, come ad esempio salvare il valore dell'username
        Debug.Log($"Username inserito: {value}");

        // Passa alla prossima domanda
        MostraProssimaDomandaQuestionManager();
    }

    public void RispostaSelezionataQuestionManager(int valoreRisposta)    
    {
        risposte.Add(valoreRisposta);
        sommaRisposte += valoreRisposta;

        // Aggiorna il testo dell'InputField con la somma delle risposte
        inputUsername.text = $"Somma delle risposte: {sommaRisposte}";

        MostraProssimaDomandaQuestionManager();
    }

    private void MostraProssimaDomandaQuestionManager()
    {
        if (indiceRisposta < domande.Length)
        {
            domandaText.text = domande[indiceRisposta];
            indiceRisposta++;
        }
        else
        {
            // Fine del gioco
            Debug.Log("Fine del gioco. Risposte: " + string.Join(", ", risposte));

            // Puoi aggiungere qui ulteriori azioni o passare a una nuova scena
            // In questo esempio, passeremo a una scena chiamata "Risultati"
            SceneManager.LoadScene("Quest_new");

            // Resettare le variabili per consentire un nuovo gioco
            risposte.Clear();
            sommaRisposte = 0;
            indiceRisposta = 0;

            // Pulisci anche il testo dell'InputField
            inputUsername.text = "";
        }
    }

    private string[] domande = new string[]
    {
        "Hello, tell us something about you. How would you prefer to be addressed in the game??",
        "What age group do you fall into?",
        "What is your preferred gender identity?",
        "How would you describe your current relationship status?", 
        "What is your highest level of education completed?",
        "Are you currently receiving professional mental health support or counseling?"
    };
}
