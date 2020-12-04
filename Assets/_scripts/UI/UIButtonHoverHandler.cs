using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonHoverHandler : MonoBehaviour, IPointerEnterHandler
{
    public event Action HandleMenueButtonHoverSound = delegate { };
    
    public void OnPointerEnter(PointerEventData eventData) {
        if(gameObject.GetComponent<Button>().enabled) {
            HandleMenueButtonHoverSound();
        }
    }
}
