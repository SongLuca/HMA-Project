using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PuzzlePiece {
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
            correctPieces.Add(cells[i].transform.tag, new PuzzlePiece(pieces[i]));
            Debug.Log("ID cell: " + cells[i].tag + " ID puzzle: " + pieces[i].tag);
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
                    for (int i=0; i<cells.Length; i++) {
                        if (pieceOverlapped(ray.transform.gameObject, cells[i])) {
                            ray.transform.localPosition = cells[i].transform.localPosition;
                            checkCorrectPlacement(ray.transform.gameObject, cells[i]);
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
        
    private bool checkCorrectPlacement(GameObject piece, GameObject cell) {
        bool found = false;
        if (correctPieces[cell.transform.tag].piece.transform.tag == piece.transform.tag)
            found = true;
        return found;
    }
    private float getSpriteX(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private float getSpriteY(GameObject obj) {
        return obj.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
