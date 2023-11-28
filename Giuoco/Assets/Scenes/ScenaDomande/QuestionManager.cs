using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Text domandaText;
    public Button[] rispostaButtons;
    public InputField inputUsername;
    public Button invioButton; // Nuovo pulsante "Invio"

    private List<int> risposte = new List<int>();
    private int indiceRisposta = 0;
    private int sommaRisposte = 0;
    private string username = "";

    private List<List<string>> risposteAssociate = new List<List<string>>()
    {
        new List<string> {"18-24", "25-34", "35-44", "45-54"},
        new List<string> {"18-24", "25-34", "35-44", "45-54"},
        new List<string> {"Female", "Male", "Non-binary", "Prefer not to say"},
        new List<string> {"Single", "In a relationship", "Married", "Prefer not to say"},
        new List<string> {"High school Graduate", "Bachelor's Degree", "Master's Degree", "Other"},
        new List<string> {"YES, I am currently receiving counseling or therapy", "NO, but I have received counseling or therapy in the past", "NO, I have not received counseling or therapy, and I am considering it", "NO, I have not received counseling or therapy, and I do not plan to."}
    };

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

        inputUsername.onEndEdit.AddListener(OnInputUsernameEndEdit);

        // Aggiungi un listener per il click del pulsante "Invio"
        invioButton.onClick.AddListener(OnInvioButtonClick);
    }

    private void OnInputUsernameEndEdit(string value)
    {
        Debug.Log($"Username inserito: {value}");
        // Attiva il pulsante "Invio" quando l'utente inserisce lo username
        username = value;
        invioButton.interactable = true;
    }

    private void OnInvioButtonClick()
    {
        // Gestisci il click del pulsante "Invio"
        MostraProssimaDomandaQuestionManager();
        // Disabilita il pulsante "Invio" dopo il click
        invioButton.interactable = false;
    }

    public void RispostaSelezionataQuestionManager(int valoreRisposta)
    {
        risposte.Add(valoreRisposta);
        sommaRisposte += valoreRisposta;
        inputUsername.text = $"{username}";
        MostraProssimaDomandaQuestionManager();
    }

    private void MostraProssimaDomandaQuestionManager()
    {
        if (indiceRisposta < domande.Length)
        {
            domandaText.text = domande[indiceRisposta];

            for (int i = 0; i < rispostaButtons.Length; i++)
            {
                rispostaButtons[i].GetComponentInChildren<Text>().text = risposteAssociate[indiceRisposta][i];
            }

            indiceRisposta++;
        }
        else
        {
            Debug.Log("Fine del gioco. Risposte: " + string.Join(", ", risposte));
            SceneManager.LoadScene("Quest_new");
            risposte.Clear();
            sommaRisposte = 0;
            indiceRisposta = 0;
            inputUsername.text = "";
            // Resetta lo username
            username = "";
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
