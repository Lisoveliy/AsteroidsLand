using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchWrapper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed;
    public bool down;
    public bool up;
    void Start()
    {
        
    }

    void Update()
    {
        down = false; up = false;
    }
    public void OnPointerDown(PointerEventData data)
    {
        pressed = true;
        down = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        pressed = false;
        up = true;
    }
}
