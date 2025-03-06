using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int cols = 20;
    const int rows = 10;

    [SerializeField]
    GameObject tilePrefab;

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
                float u = tile.transform.position.x / (float)cols;
                float v = tile.transform.position.y / (float)rows;
                Color color = new Color(u, v, 0.0f);
                tile.GetComponent<SpriteRenderer>().color = color;
                x += 1.0f;
            }
            y += 1.0f;
        }
    }

    void Update()
    {
        
    }
}
