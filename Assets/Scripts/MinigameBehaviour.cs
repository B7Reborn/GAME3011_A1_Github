using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBehaviour : MonoBehaviour
{
    // Used for random functions & tile generation
    private System.Random rand = new System.Random();

    // Setup required variables and containers
    [SerializeField] private TileBehaviour tile;
    public int numRows = 32;
    public int numColumns = 40;
    private int numTiles = 0;
    private int numFullValTiles = 40;
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
                newTile.tileRow = r;
                newTile.tileColumn = c;
                tileGrid[r, c] = tileList[(r * numColumns) + c] = newTile;
            }
        }

        // Randomly distribute the full value tiles, looping until all are distributed
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
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numColumns; column++)
            {
                if (tileGrid[row, column].tileValue == 3)
                {
                    for (int r = row - 1; r < row + 2; r++)
                    {
                        for (int c = column - 1; c < column + 2; c++)
                        {
                            if (r > -1 && r < numRows && c > -1 && c < numColumns && tileGrid[r, c].tileValue != 3)
                            {
                                tileGrid[r, c].tileValue = 2;
                            }
                        }
                    }
                }
            }
        }


        // Distribute the quarter value tiles
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numColumns; column++)
            {
                if (tileGrid[row, column].tileValue == 2)
                {
                    for (int r = row - 1; r < row + 2; r++)
                    {
                        for (int c = column - 1; c < column + 2; c++)
                        {
                            if (r > -1 && r < numRows && c > -1 && c < numColumns && tileGrid[r, c].tileValue != 3 && tileGrid[r, c].tileValue != 2)
                            {
                                tileGrid[r, c].tileValue = 1;
                            }
                        }
                    }
                }
            }
        }
    }


}
