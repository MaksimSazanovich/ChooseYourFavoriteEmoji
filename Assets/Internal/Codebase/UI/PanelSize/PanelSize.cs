using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class PanelSize : MonoBehaviour
{
    [SerializeField] private Location location;
    private void Awake()
    {
        CalculateSafeArea();
    }

    private void CalculateSafeArea()
    {
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;    
        anchorMax.y /= Screen.height;

        SetAnchors(anchorMin, anchorMax);
    }

    private void SetAnchors(Vector2 anchorMin, Vector2 anchorMax)
    {
        var rectTransform = GetComponent<RectTransform>();

        switch (location)
        {
            case Location.Top:
                rectTransform.anchorMin = new Vector2(anchorMin.x, anchorMax.y);
                if(rectTransform.anchorMin.y == rectTransform.anchorMax.y)
                    gameObject.SetActive(false);
                break;
            case Location.Centre:
                rectTransform.anchorMin = anchorMin;
                rectTransform.anchorMax = anchorMax;
                break;
            case Location.Bottom:
                rectTransform.anchorMax = new Vector2(anchorMax.x, anchorMin.y);
                if (rectTransform.anchorMax.y == rectTransform.anchorMin.y)
                    gameObject.SetActive(false);
                break;
        }
    }
}

public enum Location
{ 
    Top,
    Centre,
    Bottom
}
