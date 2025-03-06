using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int cols = 20;

    [SerializeField]
    GameObject tilePrefab;

    void Start()
    {
        float x = 0.5f;
        for (int i = 0; i < cols; i++)
        {
            GameObject tile = Instantiate(tilePrefab);
            tile.transform.position = new Vector3(x, 0.5f);
            float u = tile.transform.position.x / (float)cols;
            Color color = new Color(u, 0.0f, 0.0f);
            tile.GetComponent<SpriteRenderer>().color = color;
            x += 1.0f;
        }
    }

    void Update()
    {
        
    }
}
