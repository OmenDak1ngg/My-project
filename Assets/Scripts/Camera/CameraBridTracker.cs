using UnityEngine;
using UnityEngine.UIElements;

public class CameraBridTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector2 position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;

        transform.position = position;
    }
}
