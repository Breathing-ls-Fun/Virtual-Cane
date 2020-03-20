using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public AudioClip[] clips;
    public AudioSource AudioSource;

    public bool buttonPressed;

    private void Update()
    {
        if(buttonPressed == true)
        {
            AudioSource.clip = clips[1];
            if(!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (AudioSource.isPlaying)
        {
            AudioSource.Stop();
        }
        AudioSource.clip = clips[0];
        AudioSource.Play();
    }
}
