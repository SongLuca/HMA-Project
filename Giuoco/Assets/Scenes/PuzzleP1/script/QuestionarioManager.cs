using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionarioManager : MonoBehaviour
{
    public Text domandaText;
    public Button rispostaButtonPrefab;
    public Transform rispostePanel;

    private List<string> domande = new List<string>();
    private List<string> risposte = new List<string>();

    private int indiceDomandaCorrente = 0;

    void Start()
    {
        // Popola la lista delle domande e delle risposte (da sostituire con i tuoi dati reali)
        InizializzaDomandeERisposte();

        // Mostra la prima domanda
        MostraDomanda();
    }

    void InizializzaDomandeERisposte()
    {
        // Sostituisci con le tue domande e risposte effettive
        domande.Add("During the last two weeks, how many days have you had little interest or pleasure in doing things?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");

        domande.Add("During the last two weeks, how many days have you had trouble concentrating on things like reading the newspaper or watching TV?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");

        domande.Add("During the last two weeks, how many days have you had movements or spoken so slowly that other people could have noticed? Or, on the contrary, have you been so fidgety or restless that you've been moving much more than usual?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");

        domande.Add("During the last two weeks, how many days have you been afraid that something terrible might happen?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");

        domande.Add("During the last two weeks, how many days have you had trouble relaxing?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");

        domande.Add("During the last two weeks, how many days have you felt nervous, anxious, or tense?");
        risposte.Add("Never");
        risposte.Add("Some days");
        risposte.Add("More than half");
        risposte.Add("Almost every day");
    }

    void MostraDomanda()
    {
        // Assicurati che ci siano domande da mostrare
        if (indiceDomandaCorrente < domande.Count)
        {
            // Visualizza la domanda corrente
            domandaText.text = domande[indiceDomandaCorrente];

            // Mostra le risposte possibili
            MostraRisposte();
        }
        else
        {
            // Se non ci sono più domande, il questionario è completo
            Debug.Log("Questionario completato!");
        }
    }

    void MostraRisposte()
    {
        // Rimuovi eventuali vecchie risposte
        foreach (Transform child in rispostePanel)
        {
            Destroy(child.gameObject);
        }

        // Crea bottoni per ogni risposta
        foreach (string risposta in risposte)
        {
            Button button = Instantiate(rispostaButtonPrefab);
            button.GetComponentInChildren<Text>().text = risposta;
            button.transform.SetParent(rispostePanel, false);
            button.onClick.AddListener(() => RispostaSelezionata(risposta));
        }
    }

    void RispostaSelezionata(string risposta)
    {
        // Gestisci la risposta selezionata (puoi aggiungere la logica desiderata)
        Debug.Log($"Hai selezionato: {risposta}");

        // Passa alla domanda successiva
        indiceDomandaCorrente++;
        MostraDomanda();
    }
}

