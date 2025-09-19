using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RemoveZone : MonoBehaviour
{
    private void OnValidate()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
