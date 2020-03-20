using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedGoalSound : MonoBehaviour
{
    private AudioSource clip;
    bool reached = false;

    private void Start()
    {
        clip = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (reached == false && other.tag == "PlayerPos")
        {
            Debug.Log("Reached!");
            clip.Play();
            reached = true;
        }
    }
}
