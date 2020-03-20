using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientation : MonoBehaviour
{
    Transform positions;
    GameObject x;


    // Start is called before the first frame update
    void Start()
    {
        positions = gameObject.transform;
        x = GameObject.FindGameObjectsWithTag("ok")[0];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 obj1ToObj2 = x.transform.position -  positions.position;

        //obj1toobj2 = obj1toobj2.normalized;

        float relativeAngle = Vector3.Angle(positions.forward, obj1ToObj2);

        Vector3 localRelativePosition = positions.InverseTransformDirection(obj1ToObj2);

        //Debug.Log("position orientation = " + positions.rotation.eulerAngles);
        Debug.Log("cube = " + x.transform.position.ToString());
        Debug.Log("position = " + positions.position.ToString());
        Debug.Log("Angle: " + localRelativePosition);



    }
}
