using UnityEngine;

public class Tiles : MonoBehaviour
{
    const int cols = 20;

    [SerializeField]
    GameObject tilePrefab;

    void Start()
    {
        float x = 0.5f;
        for (int col = 0; col < cols; col++)
        {
            GameObject tile = Instantiate(tilePrefab);
            tile.transform.position = new Vector3(x, 0.5f);
            x += 1.0f;
        }
    }

    void Update()
    {
        
    }
}
