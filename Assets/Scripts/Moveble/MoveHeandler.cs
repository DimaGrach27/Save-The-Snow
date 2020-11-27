using UnityEngine;
using UnityEngine.EventSystems;

public class MoveHeandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool move;

    public void OnPointerDown(PointerEventData eventData)
    {
        move = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
    }
}
