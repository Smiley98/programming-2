using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int cols = 20;
    const int rows = 10;

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

    void Start()
    {
        float y = 9.5f;
        for (int row = 0; row < rows; row++)
        {
            float x = 0.5f;
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = Instantiate(tilePrefab);
                tile.transform.position = new Vector3(x, y);
                x += 1.0f;
        
                // Store our tile for later use!
                tiles[row, col] = tile;
            }
            y -= 1.0f;
        }
    }

    void Update()
    {
        // Uncomment this code to render the map
        //for (int y = 0; y < rows; y++)
        //{
        //    for (int x = 0; x < cols; x++)
        //    {
        //        ColorTile(y, x);
        //    }
        //}
        Gradient();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 10.0f - mousePosition.y;
        int row = (int)mousePosition.y;
        int col = (int)mousePosition.x;
        row = Mathf.Clamp(row, 0, rows - 1);
        col = Mathf.Clamp(col, 0, cols - 1);

        ColorTile(row, col);

        // Homework 4:
        // Look up tiles 1 left, 1 right, 1 up, and 1 down of the mouse tile.
        // Color them accordingly via the ColorTile() function.
        // Ensure left/right/up/down tiles do not produce out-of-range exceptions.
        // (1% lost for each direction that produces an exception).
    }

    void ColorTile(int row, int col)
    {
        Color[] colors = new Color[5];
        colors[0] = Color.white;
        colors[1] = Color.grey;
        colors[2] = Color.red;
        colors[3] = Color.green;
        colors[4] = Color.blue;

        int value = values[row, col];
        Color color = colors[value];
        GameObject tile = tiles[row, col];
        tile.GetComponent<SpriteRenderer>().color = color;
    }

    void Gradient()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                float u = col / (float)(cols - 1);
                float v = row / (float)(rows - 1);
                Color color = new Color(u, v, 0.0f);

                GameObject tile = tiles[row, col];
                tile.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}

// ? explanation within ColorTiles() function:
// ? is called the Ternary Operator. Its effectively a short-hand if-statement.
// It does the same as the following:
//Color color = new Color();
//if (value == 0)
//    color = Color.white;
//else
//    color = Color.grey;
//
