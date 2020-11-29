using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private float remainingTime;

    private const string highscoreKey = "highscore";

    public int HighScore { get; private set; }

    public static GameManager Instance { get; private set; }

    public delegate void GameStateChangedDelegate();

    public event GameStateChangedDelegate OnGameStarted;
    public event GameStateChangedDelegate OnGameFinished;
    public event GameStateChangedDelegate OnTimeSecondChanged;

    public int Score
    {
        get => score;
        set
        {
            if (score != value)
            {
                score = value;
            }
        }
    }

    public float RemainingTime
    {
        get => remainingTime;
        private set
        {
            bool raiseEvent = Mathf.FloorToInt(remainingTime) != Mathf.FloorToInt(value);
            remainingTime = Mathf.Max(value, 0);
            if (raiseEvent)
            {
                OnTimeSecondChanged?.Invoke();
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There can only be one GameManager but you have duplicates in the scene.", this);
            Destroy(this);
            return;
        }
        Instance = this;
        HighScore = PlayerPrefs.GetInt(highscoreKey, 0);
    }

    private void Start()
    {
        enabled = false;
    }

    // TODO: Task 2.3(g)
    // Implement the Update method that counts down the remaining time
    // Hint: assign the new value to the property RemainingTime instead of the variable remainingTime
    // since this will automatically raise according events to update the countdown UI
    // Each frame, you can deduct the time that the frame took to render using Time.deltaTime
    // If remainingTime is equal to or less than 0, the game should be finished by calling FinishGame()
    // ================================================



    // ================================================

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(highscoreKey, HighScore);
    }

    public void StartGame()
    {
        InitializeGame();
        enabled = true;
        OnGameStarted?.Invoke();
    }

    public void StopGame()
    {
        enabled = false;
    }

    private void InitializeGame()
    {
        RemainingTime = 60f;
        Score = 0;
    }

    private void FinishGame()
    {
        if (score > HighScore)
        {
            HighScore = score;
        }
        OnGameFinished?.Invoke();
        StopGame();
    }
}
