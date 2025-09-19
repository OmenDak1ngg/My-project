using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly KeyCode _jumpButton = KeyCode.Space;

    public event Action Jumped;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            Jumped?.Invoke();
        }
    }
}
