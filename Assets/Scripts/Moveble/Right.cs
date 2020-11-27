using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static float right;

    public void OnPointerDown(PointerEventData eventData)
    {
        right = 1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        right = 0f;
    }
}
