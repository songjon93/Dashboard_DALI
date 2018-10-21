using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Next : MonoBehaviour, IPointerDownHandler {
    public Initiate init;

    public void OnPointerDown(PointerEventData eventData)
    {
        init.reload = true;
        init.reload_num = 0;
        Debug.Log("Reloading Images");
    }
}
