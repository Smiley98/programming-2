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
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    void Start()
    {
        // Since array[0,0] is always top-left, we position our game objects in the top-left and move down!
        float y = 9.5f;
        for (int row = 0; row < rows; row++)
        {
            float x = 0.5f;
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = Instantiate(tilePrefab);
                tile.transform.position = new Vector3(x, y);
                tiles[row, col] = tile;
                x += 1.0f;
            }
            y -= 1.0f;
        }

        //Gradient();
        //ColorGrid();
    }

    void Update()
    {
        // Must re-apply the gradient each frame only our current mouse tile is magenta
        Gradient();

        // Convert to grid-space (invert y because world-y = 0 is bottom but grid-y = 0 is top)
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 10.0f - mousePosition.y;
        int row = (int)mousePosition.y;
        int col = (int)mousePosition.x;
        row = Mathf.Clamp(row, 0, rows - 1);
        col = Mathf.Clamp(col, 0, cols - 1);

        // Look up corresponding game object and apply colour to it!
        GameObject tile = tiles[row, col];
        tile.GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    void ColorGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = tiles[row, col];
                int value = values[row, col];
                Color color = value == 0 ? Color.white : Color.gray;
                tile.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    void Gradient()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Calculate our gradient colour by forming a uv via grid coordinates
                float u = col / (float)cols;
                float v = row / (float)rows;
                Color color = new Color(u, v, 0.0f);

                // Fetch our tile and change its colour to the gradient colour!
                GameObject tile = tiles[row, col];
                tile.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
