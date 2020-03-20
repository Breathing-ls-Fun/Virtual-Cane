using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class FrameRate : MonoBehaviour
{
    public Text text;
    public ARSession session;

    void Update()
    {
        text.text = $"FPS: {session.frameRate}";
    }
}
