using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private bool down = false;
    private float interval = 0f;
    private Vector2 startTouch, swipeDelta;

    private void Update()
	{
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        // standaline inputs
        if (Input.GetMouseButtonDown(0))
		{
            down = true;
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
		}
        else if(Input.GetMouseButtonUp(0))
        {
            down = false;
            isDragging = false;
            Reset();
        }

        // mobile inputs
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                down = true;
                isDragging = true;
                tap = true;
                startTouch = Input.GetTouch(0).position;
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                down = false;
                isDragging = false;
                Reset();
            }
        }

        if (down)
        {
            interval += Time.deltaTime;
        }
        else
            interval = 0f;

        // calculate distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touchCount > 0)
                swipeDelta = Input.GetTouch(0).position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // pass deadzone?
        if(swipeDelta.magnitude > 125 && interval < 0.24f)
        {
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right
                if(x < 0)
                {
                    swipeLeft = true;
                    Debug.Log("Left swipe");
                }
                else
                {
                    swipeRight = true;
                    Debug.Log("Right swipe");
                }
            }
            else
            {
                // up or down
                if(y < 0)
                {
                    swipeDown = true;
                    Debug.Log("Down swipe");
                }
                else
                {
                    swipeUp = true;
                    Debug.Log("Up swipe");

                }
            }

            Reset();
        }
	}

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

}
