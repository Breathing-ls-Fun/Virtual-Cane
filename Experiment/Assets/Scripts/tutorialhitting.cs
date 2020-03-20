using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialhitting : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip clip;
    public static bool played;
    public static int hits;

    private void Start()
    {
        played = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hits++;
            if (played == false && !sound.isPlaying && hits >= 2)
            {
                sound.clip = clip;
                sound.PlayDelayed(3f);
                played = true;
            }
        }
    }
}
