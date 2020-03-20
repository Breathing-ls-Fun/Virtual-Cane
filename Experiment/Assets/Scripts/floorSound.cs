using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSound : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound = gameObject.AddComponent<AudioSource>();
            sound.clip = clip;
            sound.Play();
            Handheld.Vibrate();
            if(!sound.isPlaying)
                Destroy(sound);
        }
    }
}
