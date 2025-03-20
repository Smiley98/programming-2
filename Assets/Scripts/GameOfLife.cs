using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    const int rows = 10;
    const int cols = 20;

    [SerializeField]
    GameObject tilePrefab;
    GameObject[,] tiles = new GameObject[rows, cols];

    // Only change the initial values once you're certain your simulation works.
    // If done correctly, this should initiate an animation that moves down and right!
    // It should match this: https://playgameoflife.com/
    int[,] prev =
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    // Note that you must populate the current frame based on the previous frame of the simulation
    int[,] curr = new int[rows, cols];

    void Start()
    {
        tiles = GridManager.Create(rows, cols, tilePrefab);

        // Note that this is just to visualize the intial configuration.
        // Once the first frame runs, all values of curr should be overwritten (if done correctly)!
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                curr[i, j] = prev[i, j];
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // **Apply Conway's rules here**
                // ***Be sure to read from prev, and write to curr***
                int aliveCount = AliveCount(i, j, prev);
                // Example: kill curr at i, j if alive count is less than 2 or greater than 3

            }
        }

        // DON'T CHANGE THIS LOOP
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Color color = curr[i, j] == 1 ? Color.grey : Color.white;
                GridManager.ColorTile(i, j, tiles, color);

                // Copy current to previous to set up next frame
                prev[i, j] = curr[i, j];
            }
        }
    }

    // Complete this function:
    // Sample adjacent & diagonal tiles.
    // Increment aliveCount for every adjacent & diagonal tile who's value is 1 (alive).
    int AliveCount(int row, int col, int[,] values)
    {
        // (Max of 8 [all neighbours are alive], min of zero [all neighbours are dead])
        int aliveCount = 0;
        return aliveCount;
    }
}
