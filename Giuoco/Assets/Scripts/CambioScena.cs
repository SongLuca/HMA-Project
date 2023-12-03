using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{

    // Metod chiamato quando il pulsante viene cliccato
    public void PassaAScena(string scena)
    {
        // Carica la scena "Quest_new"
        SceneManager.LoadScene(scena);

        
    }
}
