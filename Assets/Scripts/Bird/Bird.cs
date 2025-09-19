using System;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdCollisionHandler _collisionHandler;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    private void HandleCollision(Iinteractable collision)
    {
        if(collision is Pipe || collision is Ground)
        {
            GameOver?.Invoke();
        }

        if(collision is ScoreZone)
        {
            _scoreCounter.IncreaseScore();
        }
    }
}
