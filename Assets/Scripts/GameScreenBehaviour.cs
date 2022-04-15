using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    private bool active = false;

    public void StartButtonPressed()
    {
        active = !active;
        minigame.SetActive(active);
    }
}
