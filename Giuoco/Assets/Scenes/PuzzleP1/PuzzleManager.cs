<<<<<<<< HEAD:Giuoco/Assets/Scenes/PuzzleP1/script/PuzzleManager.cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece {
    public GameObject piece;
    public bool placed;

    public PuzzlePiece(GameObject o) {
        piece = o;
        placed = false;
    }
}
public class PuzzleManager : MonoBehaviour
{
    public AudioManager audioManager;
    public List<GameObject> cells;
    public List<GameObject> pieces;

    private Dictionary<string, PuzzlePiece> correctPieces = new Dictionary<string, PuzzlePiece>();
    private int totalPlaced = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        for (int i = 0; i < cells.Count; i++)
        {
            Debug.Log("ID cell: " + cells[i].name + " ID puzzle: " + pieces[i].name);
            correctPieces.Add(cells[i].name, new PuzzlePiece(pieces[i]));
            
        }

        //Re-arrange puzzle pieces
        swapPositions();
    }

    void swapPositions() {
        System.Random rand = new System.Random();
        List<Vector2> uniquePositions = new List<Vector2>();

        foreach (GameObject piece in pieces)
        {
            uniquePositions.Add(piece.transform.position);
        }

        for (int i = 0; i < uniquePositions.Count; i++)
        {
            int r = rand.Next(i, uniquePositions.Count);
            Vector2 temp = uniquePositions[r];
            uniquePositions[r] = uniquePositions[i];
            uniquePositions[i] = temp;
        }

        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].transform.position = uniquePositions[i];
            Debug.Log(pieces[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0)) {
            
            //if selectedpiece's position is inside the cell's area 
            //move position to cell's position
            if (ray.collider != null) {
                if (ray.transform.CompareTag("puzzle_piece")) {
                    for (int i=0; i<cells.Count; i++) {
                        if (pieceOverlapped(ray.transform.gameObject, cells[i])) {
                            ray.transform.localPosition = cells[i].transform.localPosition;
                            if (correctPieces[cells[i].name].piece.name == ray.transform.gameObject.name) {
                                totalPlaced++;
                                ray.transform.gameObject.tag = "puzzle_piece_undraggable";
                            }
                            checkWin();
                        }
                    }
                
                }
            }
        }
    }

    private bool pieceOverlapped(GameObject piece, GameObject cell) {
        if ((Mathf.Abs(cell.transform.localPosition.x - piece.transform.localPosition.x) < (getSpriteX(cell)*0.3)) &&
            (Mathf.Abs(cell.transform.localPosition.y - piece.transform.localPosition.y) < (getSpriteY(cell)*0.3))) {
            return true;
        }
        else
            return false;
    }
        
    private void checkWin() {
        if (totalPlaced == cells.Count) {
            Debug.Log("Winner winner chicken dinner\n");
        }

    }
    private bool checkCorrectPlacement(GameObject piece, GameObject cell) {
        bool found = false;
        if (correctPieces[cell.name].piece.name == piece.name) {
            found = true;
            totalPlaced++;
        }
        return found;
    }
    private float getSpriteX(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private float getSpriteY(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
========
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece {
    public GameObject piece;
    public bool placed;

    public PuzzlePiece(GameObject o) {
        piece = o;
        placed = false;
    }
}
public class PuzzleManager : MonoBehaviour
{
    public GameObject[] cells;
    public GameObject[] pieces;

    private Dictionary<string, PuzzlePiece> correctPieces = new Dictionary<string, PuzzlePiece>();
    private int totalPlaced = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Debug.Log("ID cell: " + cells[i].name + " ID puzzle: " + pieces[i].name);
            correctPieces.Add(cells[i].name, new PuzzlePiece(pieces[i]));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0)) {
            
            //if selectedpiece's position is inside the cell's area 
            //move position to cell's position
            if (ray.collider != null) {
                if (ray.transform.CompareTag("puzzle_piece")) {
                    Debug.Log("Ray name" + ray.transform.gameObject.name);
                    for (int i=0; i<cells.Length; i++) {
                        if (pieceOverlapped(ray.transform.gameObject, cells[i])) {
                            ray.transform.localPosition = cells[i].transform.localPosition;
                            if (correctPieces[cells[i].name].piece.name == ray.transform.gameObject.name) {
                                totalPlaced++;
                                ray.transform.gameObject.tag = "puzzle_piece_undraggable";
                            }
                            checkWin();
                        }
                    }
                
                }
            }
        }
    }

    private bool pieceOverlapped(GameObject piece, GameObject cell) {
        if ((Mathf.Abs(cell.transform.localPosition.x - piece.transform.localPosition.x) < (getSpriteX(cell)*0.3)) &&
            (Mathf.Abs(cell.transform.localPosition.y - piece.transform.localPosition.y) < (getSpriteY(cell)*0.3))) {
            return true;
        }
        else
            return false;
    }
        
    private void checkWin() {
        if (totalPlaced == cells.Length) {
            Debug.Log("Winner winner chicken dinner\n");
        }

    }
    private bool checkCorrectPlacement(GameObject piece, GameObject cell) {
        bool found = false;
        if (correctPieces[cell.name].piece.name == piece.name) {
            found = true;
            totalPlaced++;
        }
        return found;
    }
    private float getSpriteX(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private float getSpriteY(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
>>>>>>>> f7bdb52ee75ce186a7f1d8fc4e0a617793a05e6e:Giuoco/Assets/Scenes/PuzzleP1/PuzzleManager.cs
