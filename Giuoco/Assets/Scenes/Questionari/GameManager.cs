using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text domandaText;
    public Button[] rispostaButtons;
    public Text testoRisultato;

    private List<int> risposte = new List<int>();
    private int indiceRisposta = 0;
    private int sommaRisposte = 0;

    // Singleton pattern
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        MostraProssimaDomanda();
    }

    public void RispostaSelezionataGameManager(int valoreRisposta)
    {
        risposte.Add(valoreRisposta);
        sommaRisposte += valoreRisposta;
        testoRisultato.text = $"Questionnaire results: {sommaRisposte}";
        MostraProssimaDomanda();
        Debug.Log("Risposta selezionata. Prossima domanda.");
    }


    private void MostraProssimaDomanda()
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
            SceneManager.LoadScene("Cervello3");

            // Resettare le variabili per consentire un nuovo gioco
            risposte.Clear();
            sommaRisposte = 0;
            indiceRisposta = 0;
            testoRisultato.text = "";
        }
    }

    private string[] domande = new string[]
    {
        "During the last two weeks, how many days have you had little interest or pleasure in doing things?",
        "During the last two weeks, how many days have you had trouble concentrating on things like reading the newspaper or watching TV?",
        "During the last two weeks, how many days have you had movements or spoken so slowly that other people could have noticed? Or, on the contrary, have you been so fidgety or restless that you've been moving much more than usual?",
        "During the last two weeks, how many days have you been afraid that something terrible might happen?",
        "During the last two weeks, how many days have you had trouble relaxing?",
        "During the last two weeks, how many days have you felt nervous, anxious, or tense?"
    };
}