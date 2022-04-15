using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour
{

    public int tileValue = 0;

    private Image ImageComponent;
    [SerializeField] private Sprite HiddenResources;
    [SerializeField] private Sprite FullResources;
    [SerializeField] private Sprite HalfResources;
    [SerializeField] private Sprite QuarterResources;
    [SerializeField] private Sprite NoResources;

    void Start()
    {
        ImageComponent = GetComponent<Image>();
        ImageComponent.sprite = HiddenResources;
    }

    public void OnTileClicked()
    {
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
