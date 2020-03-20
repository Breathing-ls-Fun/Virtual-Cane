using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public swipe m_swipe;
    public AudioClip soonTM;
    public AudioSource source;
    public voiceGuide guide;

    private void Update()
    {
        if (guide.Finished)
        {
            if (m_swipe.SwipeDown)
            {
                source.PlayOneShot(soonTM);
            }
            if (m_swipe.SwipeUp)
            {
                guide.Reset();
            }
        }
    }


}
