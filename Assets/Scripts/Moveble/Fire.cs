using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool fire;

    public void OnPointerDown(PointerEventData eventData)
    {
        fire = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        fire = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        fire = true;
    }

}
