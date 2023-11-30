using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    public int rows;
    public int columns;
    public float cellSize = 1f;

    private Vector3[,] cellPositions;
    private GameObject[,] cells;

    void Start()
    {
        InitializeGrid();
        cells = new GameObject[rows, columns];
    }

    void InitializeGrid()
    {
        cellPositions = new Vector3[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float xPos = j * cellSize;
                float yPos = i * cellSize;
                Vector3 offset = transform.position;
                Vector3 cellPosition = new Vector3(xPos, yPos, 0f) + offset;
                cellPositions[i, j] = cellPosition;
            }
        }
    }

    public Vector3 GetCellPosition(int row, int column)
    {
        if (IsValidCellPosition(row, column))
        {
            return cellPositions[row, column];
        }
        else
        {
            Debug.LogError("Tentativo di accedere a una posizione di cella non valida.");
            return Vector3.zero;
        }
    }

    public void SetCell(int row, int column, GameObject cellObject)
    {
        if (IsValidCellPosition(row, column))
        {
            cells[row, column] = cellObject;
        }
        else
        {
            Debug.LogError("Tentativo di impostare una cella in una posizione non valida.");
        }
    }

    bool IsValidCellPosition(int row, int column)
    {
        return row >= 0 && row < rows && column >= 0 && column < columns;
    }
}