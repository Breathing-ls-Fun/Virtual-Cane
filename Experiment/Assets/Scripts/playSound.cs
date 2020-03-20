using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioClip[] clip;
    AudioSource sound;
    private AudioSource sound2;
    static private bool isInTigger;
    public float speed;
    Vector3 lastPosition = Vector3.zero;
    int x = 0;
    static int toodeep = 0;
    static int extremelydeep = 0;


    private void Start()
    {
        isInTigger = false;
        sound2 = gameObject.AddComponent<AudioSource>();
        sound2.enabled = false;
        if (clip[1] != null)
        {
            sound2.clip = clip[1];
        }
        sound2.volume = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        sound2.enabled = true;
        if (other.gameObject.tag == "Player" && isInTigger == false)
        {
            sound = gameObject.AddComponent<AudioSource>();
            if (!sound.isPlaying && clip[0] != null)
            {
                sound.PlayOneShot(clip[0]);
            }
            if (clip[3] != null)
            {
                sound.clip = clip[3];
                sound.PlayDelayed(0.5f);
            }
            Handheld.Vibrate();
        }
        if(other.gameObject.tag == "toodeep")
        {
            Debug.Log("Too Deep");
            x++;
            toodeep++;
        }
        if (other.gameObject.tag == "WAYTOODEEP")
        {
            Debug.Log("WAYTOODEEP");
            x++;
            extremelydeep++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")  //当条件触发
        {
            isInTigger = true;
            speed = (other.transform.position - lastPosition).magnitude / Time.deltaTime;
            lastPosition = other.transform.position;
            if (clip[1] != null)
            {
                if (speed >= 0.375f && !sound2.isPlaying && sound2.enabled == true)
                {
                    sound2.Play();
                }
                if (!(speed >= 0.45f))
                {
                    sound2.Stop();
                }
            }
        }
        if (x == 1)
        {
            Debug.Log("Too Deep");
            if (sound != null && clip[2] != null)
            {
                sound.clip = clip[2];
                if (!sound.isPlaying)
                {
                    sound.Play();
                }
            }
        }
        if (x == 2)
        {
            Debug.Log(" WAAAY TOO DEEP");
            if (sound != null && clip[4] != null)
            {
                sound.clip = clip[4];
                if (!sound.isPlaying)
                {
                    sound.Play();
                }
            }
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "toodeep" || other.gameObject.tag == "WAYTOODEEP")
        {
            x--;
            if (sound != null && sound.isPlaying)
            {
                sound.Stop();
            }
        }
        if (other.gameObject.tag == "Player")
        {
            if (clip[1] != null)
            {
                sound2.Stop();
            }
            sound2.enabled = false;
            isInTigger = false;
            if (sound != null && !sound.isPlaying)
                Destroy(sound);
        }
    }

    public int TooDeep { get { return toodeep; } }
    public int ExtremelyDeep { get { return extremelydeep; } }
}