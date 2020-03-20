using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfMap : MonoBehaviour
{
    AudioSource sound;
    bool withinMap;
    static int m_outOfMap = 0;

    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        sound.enabled = false;
    }

    void Update()
    {
        if (sound != null && !sound.isPlaying && withinMap == false)
        {
            sound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "PlayerPos")
        {
            withinMap = true;
            if (sound != null && sound.isPlaying)
            {
                sound.Stop();
            }
            sound.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerPos")
        {
            m_outOfMap++;
            withinMap = false;
            sound.enabled = true;
        }
    }

    public int OutOfMap { get { return m_outOfMap; } }
}
