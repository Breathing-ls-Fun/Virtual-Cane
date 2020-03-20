using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{
    private float y;

    private void Start()
    {
        y = transform.rotation.y;
    }

    void Update()
    {
        y = transform.rotation.eulerAngles.y;
        if (!(y < 20 || y > 340))
        {
            Debug.Log("Wrong Direction");
        }
    }
}
