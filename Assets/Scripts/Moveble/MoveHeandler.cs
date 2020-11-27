using UnityEngine;
using UnityEngine.EventSystems;

public class MoveHeandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static float leftRotation;

    public void OnPointerDown(PointerEventData eventData)
    {
        leftRotation = 1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leftRotation = 0f;
    }
}
