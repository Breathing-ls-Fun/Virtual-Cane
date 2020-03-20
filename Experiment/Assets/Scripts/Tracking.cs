using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// When relocalizing with ARCollaborationData or ARWorldMaps, the tracking state
/// should change to TrackingState.Limited until the device has successfully
/// relocalized to the new data. If it remains TrackingState.Tracking, then
/// it is not working.
/// </summary>
[RequireComponent(typeof(ARSession))]
public class Tracking : MonoBehaviour
{
    public Text text;
    public ARSession m_Session;

    void Start()
    {
        m_Session = GetComponent<ARSession>();
    }

    void Update()
    {
        if (m_Session.subsystem != null && m_Session.subsystem.running)
        {
            switch (m_Session.subsystem.trackingState)
            {
                case TrackingState.None:
                case TrackingState.Limited:
                    text.text = "Tracking Inaccurate";
                    break;
                case TrackingState.Tracking:
                    text.text = "Tracking Accurate";
                    break;
            }
        }
    }


}