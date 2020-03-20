using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTap : MonoBehaviour, IPointerClickHandler
{
    private bool doubleTap;

    float lastClick = 0f;
    float interval = 0.25f;

    private void Update()
    {
        doubleTap = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            //is a double click
            doubleTap = true;
            Debug.Log("DoubleTap");
        }
        else //is a single click
        {

            lastClick = Time.time;
        }
    }

    public bool m_DoubleTap { get { return doubleTap; } }
}
