using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreLabel;
    [SerializeField] private TextMeshPro timeLabel;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnTimeSecondChanged += OnTimeSecondChanged;
    }

    private void OnGameStarted()
    {
        scoreLabel.text = GameManager.Instance.Score.ToString();
    }

    private void OnTimeSecondChanged()
    {
        float remainingTime = GameManager.Instance.RemainingTime;
        float minuteFracton = remainingTime / 60;
        float seconds = remainingTime % 60;
        timeLabel.text = $"{Mathf.FloorToInt(minuteFracton).ToString("00")}:{Mathf.FloorToInt(seconds).ToString("00")}";
    }

    // TODO: Task 2.3(b)
    // Implement the magic method OnTriggerEnter
    // which reacts to colliders entering the set up box volume of the basket
    // In this method, do the following:
    // 1. Destroy the GameObject of the collider which entered the trigger volume
    // 2. Increment the GameManager's score (the GameManager singleton can be accessed using GameManager.Instance)
    // 3. Update the scoreLabel's text to the score that is kept by the GameManager
    // ================================================


    // ================================================
}
