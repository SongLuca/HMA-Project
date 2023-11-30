using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int cointCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;
    private void Awake()
    {
        puzzles = Resources. LoadAll<Sprite>("fruit");
    }

    // Start is called before the first frame update
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
    }

    // Update is called once per frame
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("puzzleBtn");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; 1 < looper; i++)
        {
            if(index == looper/2)
            {
                index = 0;
            }
                gamePuzzles. Add (puzzles[index]);
                index++;
        }
    }
    private void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickPuzzle()); // Fix: Corretto il nome della funzione
        }
    }

    private void PickPuzzle() // Fix: Aggiunto il corpo della funzione
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print("Hey " + name);
    }
}
