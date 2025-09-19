using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _startScore =0;
    private int _currentScore;

    private void Start()
    {
        _currentScore = 0;
    }

    public void IncreaseScore()
    {
        _currentScore++;
    }
}
