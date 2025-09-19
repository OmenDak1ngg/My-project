using System;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class Button : MonoBehaviour
{
    private Button _button;

    public event Action ButtonPressed;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void OnButtonPressed()
    {
        ButtonPressed?.Invoke();
    }
}
