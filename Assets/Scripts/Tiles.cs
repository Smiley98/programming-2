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
                tiles[row, col] = tile;
                x += 1.0f;
            }
            y += 1.0f;
        }

        Gradient();
    }

    void Update()
    {
        
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
