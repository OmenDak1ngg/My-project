using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]  
public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Canvas _canvas;

    private void OnEnable()
    {
        _button.ButtonPressed += HideEndGameScreen;
    }

    private void OnDisable()
    {
        _button.ButtonPressed -= HideEndGameScreen;
    }

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        HideEndGameScreen();
    }

    public void ShowEndGameScreen()
    {
        _canvas.gameObject.SetActive(true);
    }

    public void HideEndGameScreen()
    {
        _canvas.gameObject.SetActive(false);
    }
}
