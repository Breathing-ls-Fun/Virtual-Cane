using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibleMenu : MonoBehaviour
{
    public swipe swipeControls;
    public DoubleTap doubleTapControls;

    public AudioClip[] clips;
    public AudioClip[] clips2;
    public AudioSource source;

    private int index = 1;

    private void Update()
    {
        if (doubleTapControls.m_DoubleTap)
        {
            source.PlayOneShot(clips[0]);
            source.PlayOneShot(clips2[index]);
        }
        if (swipeControls.SwipeLeft)
        {
            index++;
            source.PlayOneShot(clips[0]);
            source.PlayOneShot(clips[index]);
        }
        if (swipeControls.SwipeRight)
        {
            
            index--;
            source.PlayOneShot(clips[0]);
            source.PlayOneShot(clips[index]);
        }
    }
}
