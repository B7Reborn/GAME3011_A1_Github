using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour
{
    public bool isRevealed = false;
    public int tileValue = 0;
    public int tileRow = -1;
    public int tileColumn = -1;

    private Image ImageComponent;
    private MinigameBehaviour Minigame;
    [SerializeField] private Sprite HiddenResources;
    [SerializeField] private Sprite FullResources;
    [SerializeField] private Sprite HalfResources;
    [SerializeField] private Sprite QuarterResources;
    [SerializeField] private Sprite NoResources;

    void Start()
    {
        Minigame = this.transform.parent.GetComponent<MinigameBehaviour>();
        ImageComponent = GetComponent<Image>();
        ImageComponent.sprite = HiddenResources;
    }

    public void OnTileClicked()
    {
        if (!isRevealed)
        {
            RevealTile();

            // If in scan mode, also reveal all adjacent tiles
            for (int r = tileRow - 1; r < tileRow + 2; r++)
            {
                for (int c = tileColumn - 1; c < tileColumn + 2; c++)
                {
                    if (r > -1 && r < Minigame.numRows && c > -1 && c < Minigame.numColumns)
                    {
                        Minigame.tileGrid[r, c].RevealTile();
                    }
                }
            }
        }
    }

    public void RevealTile()
    {
        isRevealed = true;
        // Reveal the tile when clicked
        switch (tileValue)
        {
            case 3:
                ImageComponent.sprite = FullResources;
                break;
            case 2:
                ImageComponent.sprite = HalfResources;
                break;
            case 1:
                ImageComponent.sprite = QuarterResources;
                break;
            default:
                ImageComponent.sprite = NoResources;
                break;
        }
    }
}
