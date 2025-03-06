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
                float u = col / (float)(cols - 1);
                float v = row / (float)(rows - 1);
                Color color = new Color(u, v, 0.0f);

                GameObject tile = Instantiate(tilePrefab);
                tile.transform.position = new Vector3(x, y);
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
