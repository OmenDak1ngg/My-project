using System;
using UnityEngine;

public class Pipe : MonoBehaviour,Iinteractable
{
    public event Action<Pipe> OutOfBounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RemoveZone>(out _))
            OutOfBounds?.Invoke(this);
    }
}
