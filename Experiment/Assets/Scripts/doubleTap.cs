using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class doubleTap : MonoBehaviour, IPointerClickHandler
{
    public AudioClip clip;
    public AudioSource AudioSource;
    public GameObject obj;
    public GameObject obj2;
    public bool openOtherScene;
    public string mapName;

    float lastClick = 0f;
    float interval = 0.4f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            //is a double click
            if (obj != null && obj2 != null)
            {
                obj.SetActive(false);
                obj2.SetActive(true);
            }
            if(openOtherScene == true)
            {
                SceneManager.LoadScene(mapName);
            }
        }
        else //is a single click
        {
            if (AudioSource != null)
            {
                if (AudioSource.isPlaying)
                {
                    AudioSource.Stop();
                }
                AudioSource.clip = clip;
            }

            lastClick = Time.time;
        }
    }
}