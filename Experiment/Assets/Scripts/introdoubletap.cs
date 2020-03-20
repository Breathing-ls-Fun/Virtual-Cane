using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class introdoubletap : MonoBehaviour, IPointerClickHandler
{
    public AudioClip[] clips;
    public AudioSource AudioSource;
    public bool vibrate;

    float lastClick = 0f;
    float interval = 0.4f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            //is a double click
            if (AudioSource.isPlaying)
            {
                AudioSource.Stop();
            }
            AudioSource.clip = clips[1];
            AudioSource.Play();
            if (vibrate == true)
            { Handheld.Vibrate(); }
        }
        else //is a single click
        {
            if (AudioSource.isPlaying)
            {
                AudioSource.Stop();
            }
            AudioSource.clip = clips[0];
            AudioSource.Play();
            lastClick = Time.time;
        }
    }
}
