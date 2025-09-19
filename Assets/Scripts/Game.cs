using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeSpawner _pipeSpawner;

    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Transform _startPoint;

    private void OnEnable()
    {
        _startGameButton.ButtonPressed += StartGame;
        _bird.GameOver += EndGame;
    }

    private void OnDisable()
    {
        _startGameButton.ButtonPressed -= StartGame;
        _bird.GameOver -= EndGame;
    }

    private void EndGame()
    {
        _endGameScreen.ShowEndGameScreen();
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        _pipeSpawner.RemoveAllPipes();
        Time.timeScale = 1f;
    }
}
