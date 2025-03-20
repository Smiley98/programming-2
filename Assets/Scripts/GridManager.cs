using UnityEngine;

public struct Cell
{
    public int row;
    public int col;
}

public static class GridManager
{
    public static GameObject[,] Create(int rows, int cols, GameObject tilePrefab)
    {
        GameObject[,] tiles = new GameObject[rows, cols];

        float w = tilePrefab.transform.localScale.x;
        float h = tilePrefab.transform.localScale.y;

        float y = rows * h - (h * 0.5f);
        for (int row = 0; row < rows; row++)
        {
            float x = w * 0.5f;
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = GameObject.Instantiate(tilePrefab);
                tile.transform.position = new Vector3(x, y);
                x += w;

                // Store our tile for later use!
                tiles[row, col] = tile;
            }
            y -= h;
        }

        return tiles;
    }

    public static Cell WorldToGrid(Vector2 position, int rows, int cols, GameObject tilePrefab)
    {
        float w = tilePrefab.transform.localScale.x;
        float h = tilePrefab.transform.localScale.y;
        position.y = rows * h - position.y;
        int row = (int)(position.y / h);//(int)mousePosition.y;
        int col = (int)(position.x / w);//(int)mousePosition.x;
        row = Mathf.Clamp(row, 0, rows - 1);
        col = Mathf.Clamp(col, 0, cols - 1);
        return new Cell { row = row, col = col };
    }

    public static void Gradient(int rows, int cols, GameObject[,] tiles)
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

    public static void ColorTile(int row, int col, GameObject[,] tiles, Color color)
    {
        GameObject tile = tiles[row, col];
        tile.GetComponent<SpriteRenderer>().color = color;
    }

    public static void ColorTile(int row, int col, GameObject[,] tiles, int[,] values)
    {
        Color[] colors = new Color[5];
        colors[0] = Color.white;
        colors[1] = Color.grey;
        colors[2] = Color.red;
        colors[3] = Color.green;
        colors[4] = Color.blue;

        int value = values[row, col];
        Color color = colors[value];
        ColorTile(row, col, tiles, color);
    }
}
