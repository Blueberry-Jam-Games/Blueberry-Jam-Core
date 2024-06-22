using System.Collections;
using System.Collections.Generic;
using BJ;
using UnityEngine;

public class Array2DTest : MonoBehaviour
{
    public Array2D<int> array;

    // Start is called before the first frame update
    private void Start()
    {
        ShowcaseDenseArray();
    }

    private void ShowcaseDenseArray()
    {
        array = new Array2D<int>(5, 5, 0);

        // Single index can work for when you know you need to hit every element.
        // Doesn't give you access to X, Y position by default but you can calculate it if you have to.
        for (int x = 0; x < array.Count; x++)
        {
            array[x] = x;
        }

        foreach (KeyValuePair<Vector2Int, int> x in array)
        {
            Debug.Log($"Expensive array loop ({x.Key.x}, {x.Key.y}) = {x.Value}");
        }

        array.FlatForeach((x, y, v) =>
        {
            Debug.Log($"Efficient array loop ({x}, {y}) = {v}");
        });

        // Expand array
        array[7, 7] = 7 * 7;

        Debug.Log(array.ToString());
    }
}
