using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject nextButton;
    bool hit = false;
    bool played = false;
    AudioSource sound;
    public AudioClip voice;
    float time;

    private void FixedUpdate()
    {
        if (hit == true)
        {
            time += Time.deltaTime;
            if(time >= 0.5f && played == false)
            {
                sound.Play();
                played = true;
            }
            if (time >= 0.6f && !sound.isPlaying)
            {
                nextButton.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hit == false)
        {
            if (other.tag == "Player")
            {
                time = 0f;
                sound = gameObject.AddComponent<AudioSource>();
                sound.clip = voice;
                hit = true;
            }
        }
    }
}
