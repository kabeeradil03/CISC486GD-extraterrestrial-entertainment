using UnityEngine;
using UnityEngine.EventSystems;
public class Droppable : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDrop dragDrop = dropped.GetComponent<DragDrop>();
        dragDrop.parentAfterDrag = transform;
    }
}
