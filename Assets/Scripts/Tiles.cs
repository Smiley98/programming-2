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

    int py = rows / 2;
    int px = cols / 2;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            py--;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            py++;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            px--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            px++;
        }
        py = Mathf.Clamp(py, 0, rows - 1);
        px = Mathf.Clamp(px, 0, cols - 1);

        GridManager.ColorTile(py, px, tiles, Color.magenta);
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
