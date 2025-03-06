using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int cols = 20;
    const int rows = 10;

    [SerializeField]
    GameObject tilePrefab;
    GameObject[,] tiles = new GameObject[rows, cols];

    void Start()
    {
        float y = 0.5f;
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
            y += 1.0f;
        }
    }

    void Update()
    {
        Gradient();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int row = (int)mousePosition.y;
        int col = (int)mousePosition.x;
        row = Mathf.Clamp(row, 0, rows - 1);
        col = Mathf.Clamp(col, 0, cols - 1);

        GameObject tile = tiles[row, col];
        tile.GetComponent<SpriteRenderer>().color = Color.cyan;
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
