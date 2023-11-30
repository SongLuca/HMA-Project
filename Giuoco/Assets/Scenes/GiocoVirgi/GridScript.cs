using UnityEngine;
using System.Collections.Generic;

public class GridScript : MonoBehaviour
{
    public CustomGrid grid;
    public GameObject[] carte;

    void Start()
    {
        if (grid == null)
        {
            Debug.LogError("L'oggetto grid non è stato assegnato.");
            return;
        }
        

        grid.rows = 2;
        grid.columns = 4;

        List<GameObject> carteMescolate = Shuffle(new List<GameObject>(carte));

        int index = 0;
        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                grid.SetCell(i, j, carteMescolate[index]);
                index++;
            }
        }
    }

    List<T> Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}


