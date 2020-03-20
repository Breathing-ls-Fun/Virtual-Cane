using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sphereButton : MonoBehaviour
{
    public Transform obj;
    public AudioClip[] clips;
    public GameObject[] tutorials;
    public AudioSource voiceGuide;

    AudioSource AudioSource;
    Vector3 offset;
    float timeSelected;
    int tutorialIndex;
    bool selected = false;

    void Start()
    {
        tutorials[0].SetActive(true);
        tutorials[1].SetActive(false);
        tutorials[2].SetActive(false);
        tutorials[3].SetActive(false);
        tutorialIndex = 0;
        offset = transform.position - obj.position;
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.enabled = false;
        voiceGuide.PlayOneShot(clips[0]);
    }

    void Update()
    {
        Vector3 targetPosition = obj.position + offset;
        transform.position += (targetPosition - transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && tutorialhitting.played == true)
        {
            AudioSource.enabled = true;
            if (AudioSource.isPlaying)
            {
                AudioSource.Stop();
            }
            AudioSource.PlayOneShot(clips[4]);
            timeSelected = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && tutorialhitting.played == true)
        {
            timeSelected += Time.deltaTime;
            if (timeSelected >= 2f && selected == false)
            {
                selected = true;
                if (tutorialIndex < 3)
                {
                    tutorialIndex++;
                    tutorials[tutorialIndex - 1].SetActive(false);
                    tutorials[tutorialIndex].SetActive(true);
                    if(voiceGuide.isPlaying)
                    {
                        voiceGuide.Stop();
                    }
                    voiceGuide.clip = clips[tutorialIndex];
                    voiceGuide.Play();
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    tutorialhitting.played = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeSelected = 0f;
            selected = false;
            if (tutorialhitting.played == true)
            {
                if (AudioSource.isPlaying)
                {
                    AudioSource.Stop();
                }
                AudioSource.PlayOneShot(clips[5]);
            }
        }
    }
}
