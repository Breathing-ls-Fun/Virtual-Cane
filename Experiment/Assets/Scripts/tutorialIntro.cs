using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class tutorialIntro : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (!source.isPlaying && source != null)
        {
            source.PlayOneShot(source.clip);
        }
    }
}
