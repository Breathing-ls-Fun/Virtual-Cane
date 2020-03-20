using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWarnings : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip clip;
    public MeshRenderer next_button;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "toodeep" && !sound.isPlaying && tutorialhitting.played == false)
        {
            sound.clip = clip;
            sound.PlayDelayed(1f);
            tutorialhitting.played = true;
            next_button.enabled = true;
        } 
    }
}
