using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int rows = 10;
    const int cols = 20;

    [SerializeField]
    GameObject tilePrefab;
    GameObject[,] tiles = new GameObject[rows, cols];

    int[,] values =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 2, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    Cell player = new Cell { row = rows / 2, col = cols / 2 };

    void Start()
    {
        tiles = GridManager.Create(rows, cols, tilePrefab);
    }

    void Update()
    {
        GridManager.Gradient(rows, cols, tiles);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cell mouseCell = GridManager.WorldToGrid(mousePosition, rows, cols, tilePrefab);

        GridManager.ColorTile(mouseCell.row, mouseCell.col, tiles, values);

        int dy = 0;
        int dx = 0;
        if (Input.GetKeyDown(KeyCode.W))
        {
            dy--;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dy++;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dx--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dx++;
        }
        player.row += dy;
        player.col += dx;
        player.row = Mathf.Clamp(player.row, 0, rows - 1);
        player.col = Mathf.Clamp(player.col, 0, cols - 1);

        // We've moved if there's change in y or change in x!
        if (dy != 0 || dx != 0)
        {
            Debug.Log("Moved " + dy + " vertically and " + dx + " horizontally");
        }

        GridManager.ColorTile(player.row, player.col, tiles, Color.magenta);
    }
}

// ? is called the Ternary Operator. Its effectively a short-hand if-statement.
// The following snippets of code are the same:
//
// 1)
// bool colorWhite = true;
// Color color = colorWhite ? Color.white : Color.grey;
//
// vs
//
// 2)
// bool colorWhite = true;
// Color color = new Color();
// if (colorWhite)
//    color = Color.white;
// else
//    color = Color.grey;
//
