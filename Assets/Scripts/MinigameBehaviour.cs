using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBehaviour : MonoBehaviour
{
    // Used for random functions & tile generation
    private System.Random rand = new System.Random();

    // Setup required variables and containers
    [SerializeField] private TileBehaviour tile;
    private int numRows = 32;
    private int numColumns = 40;
    private int numTiles = 0;
    private int numFullValTiles = 32;
    private TileBehaviour[] tileList;
    public TileBehaviour[,] tileGrid;


    // On startup, game should not be active until user presses start button
    void Start()
    {
        gameObject.SetActive(false);
        numTiles = numRows * numColumns;
        tileList = new TileBehaviour[numTiles];
        tileGrid = new TileBehaviour[numRows, numColumns];
    }

    void OnEnable()
    {
        GenerateGrid();
    }


    void GenerateGrid()
    {
        // Generate the grid itself
        for (int r = 0; r < numRows; r++)
        {
            for (int c = 0; c < numColumns; c++)
            {
                TileBehaviour newTile = Instantiate(tile, new Vector3((112 + (c * 17)), (106 + (r * 17))), Quaternion.identity, this.transform);
                tileGrid[r, c] = newTile;
                tileList[(r * numColumns) + c] = newTile;
            }
        }

        // Randomly distribute the full value tiles
        while (numFullValTiles > 0)
        {
            for (int n = 0; n < numTiles; n++)
            {
                if (numFullValTiles > 0)
                {
                    int randomVal = rand.Next(0, 40);
                    if (randomVal == 5)
                    {
                        tileList[n].tileValue = 3;
                        numFullValTiles--;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        
        // Distribute the half value tiles


        // Distribute the quarter value tiles
    }


}
