using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_pt2 : MonoBehaviour
{

    public GameObject pt1;
    public GameObject pt2;

    private void Start()
    {
        pt1.SetActive(true);
        pt2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerPos")
        {
            pt1.SetActive(false);
            pt2.SetActive(true);
            Debug.Log("Deactivated");
        }
    }
}
