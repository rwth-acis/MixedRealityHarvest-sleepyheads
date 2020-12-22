using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // TODO: Task 2.3(e)
    // Add a field that allows you to assign the highscore label in the inspector
    // ================================================
    [SerializeField]
    private TextMeshPro score;
    // ================================================

    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;

        UpdateHighscoreLabel();
    }

    private void OnGameStarted()
    {
        // TODO: Task 2.3(e)
        // Hide the menu by deactivating its gameobject
        // ================================================
        gameObject.SetActive(false);
        // ================================================
    }

    private void OnGameFinished()
    {
        // TODO: Task 2.3(e)
        // Show the menu by activating its gameobject
        // also update the highscore label to reflect any changes
        // ================================================
        gameObject.SetActive(true);
        UpdateHighscoreLabel();
        
        
        // ================================================
    }

    private void UpdateHighscoreLabel()
    {
        // TODO: Task 2.3(e)
        // Update the highscore label's text to show
        // "Highscore: " followed by the value of the HighScore property in the GameManager
        // ================================================
        if (score)
        {
            score.text = "Highscore: " + GameManager.Instance.HighScore;
        }
        // ================================================
    }
}
