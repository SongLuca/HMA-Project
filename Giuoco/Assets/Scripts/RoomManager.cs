using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public GameObject selectedPiece;
    private int keys = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    

    public void loadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void activatePanel(GameObject panelName) {
        panelName.SetActive(true);
    }
    
    public void deactivatePanel(GameObject panelName) {
        panelName.SetActive(false);
    }

    public void debug() {
        Debug.Log("Debuggging\n");
    }

    
}
