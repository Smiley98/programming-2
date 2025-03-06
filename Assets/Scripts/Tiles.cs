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
            x += 1.0f;
        }
    }

    void Update()
    {
        
    }
}
