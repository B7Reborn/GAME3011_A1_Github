using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ModeText;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HiScoreText;

    void Start()
    {
        ModeText.text = "Test";
        ScoreText.text = "Current Resources: ";
        HiScoreText.text = "Best Resources: ";
    }

}
