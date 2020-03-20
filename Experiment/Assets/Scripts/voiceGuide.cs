using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class voiceGuide : MonoBehaviour
{
    public AudioClip clip;
    public playSound playsound;
    public outOfMap oom;
    public GameObject[] tutorials;
    public AudioSource voice_Guide;
    public Text timer_text1;
    public Text timer_text2;
    public Text timer_text3;
    public Text toodeepCounter;
    public Text extremelyDeepCounter;
    public Text outOfMapCounter;


    float m_time;
    public float[] timers = { 0f, 0f, 0f};
    bool finished = false;
    int tutorialIndex, c_toodeep, c_exdeep, c_outofmap;

    void Start()
    {
        tutorials[1].SetActive(false);

        Reset();
    }

    private void Update()
    {
        if(tutorialIndex < 3 && !finished)
            timers[tutorialIndex] += Time.deltaTime;
        c_toodeep = playsound.TooDeep;
        c_exdeep = playsound.ExtremelyDeep;
        c_outofmap = oom.OutOfMap;

        timer_text1.text = "Time A: " + Mathf.Round(timers[0]) + "s";
        timer_text2.text = "Time B: " + Mathf.Round(timers[1]) + "s";
        timer_text3.text = "Time C: " + Mathf.Round(timers[2]) + "s";

        toodeepCounter.text = "TooDeep: " + c_toodeep;
        extremelyDeepCounter.text = "EX-Deep: " + c_exdeep;
        outOfMapCounter.text = "OutOfMap: " + c_outofmap;

        if (tutorialhitting.played == true && !finished)
        {

            m_time += Time.deltaTime;

            if (m_time >= 5f && tutorialhitting.hits >= 2)
            {
                if (tutorialIndex < 3)
                {
                    if (tutorialIndex < 2)
                    {
                        tutorials[tutorialIndex].SetActive(false);
                        tutorials[tutorialIndex + 1].SetActive(true);
                    }
                    if (tutorialIndex == 2)
                        finished = true;
                    tutorialIndex++;
                    tutorialhitting.played = false;
                    tutorialhitting.hits = 0;
                    m_time = 0f;
                }

            }
        }


    }

    public void Reset()
    {
        m_time = timers[0] = timers[1] = timers[2] = 0f;
        finished = false;
        tutorials[2].SetActive(false);
        tutorials[0].SetActive(true);
        tutorialIndex = c_toodeep = c_exdeep = c_outofmap = 0;
        if (voice_Guide.isPlaying)
            voice_Guide.Stop();
        voice_Guide.PlayOneShot(clip);
    }

    public bool Finished {  get { return finished; } }
}