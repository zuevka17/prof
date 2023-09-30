using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragBlockSchemeComponent : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
    }
    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);
        transform.position = canvas.transform.TransformPoint(position);
    }
}
