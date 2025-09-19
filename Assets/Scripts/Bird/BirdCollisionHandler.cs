using System;
using UnityEngine;

[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(Collider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    public event Action<Iinteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Iinteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }
}
