<<<<<<<< HEAD:Giuoco/Assets/Scenes/PuzzleP1/script/DragNDrop.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour 
{
    public GameObject selectedObject;
    public AudioManager audioManager;
    void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
       
        if (Input.GetMouseButtonDown(0)) 
        {
            bool isHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (isHit) 
            {
                if (hit.transform.CompareTag("puzzle_piece")) 
                {
                    selectedObject = hit.transform.gameObject;
                    audioManager.pieceMovedSound();
                }
            }
        }
        if (Input.GetMouseButton(0)) 
        {
            if (selectedObject != null) 
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;
                selectedObject.transform.position = mousePos;
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            selectedObject = null;
            audioManager.pieceMovedSound();
        }
        
    }
}
========
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour {

    public GameObject selectedObject;
    void Start() {}

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0)) {
            bool isHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (isHit) {
                if (hit.transform.CompareTag("puzzle_piece")) {
                    selectedObject = hit.transform.gameObject;
                }
            }
        }
        if (Input.GetMouseButton(0)) {
            
            if (selectedObject != null) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;
                selectedObject.transform.position = mousePos;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            selectedObject = null;
        }
        
    }
}
>>>>>>>> f7bdb52ee75ce186a7f1d8fc4e0a617793a05e6e:Giuoco/Assets/Scenes/PuzzleP1/DragNDrop.cs
