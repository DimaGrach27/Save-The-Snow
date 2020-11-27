using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static float left;

    public void OnPointerDown(PointerEventData eventData)
    {
        left = -1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        left = 0f;
    }
}
