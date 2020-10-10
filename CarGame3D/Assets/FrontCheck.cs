using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheck : MonoBehaviour
{
    public bool frontcheck = false, frontcar = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OneRoadEntry")
        {
            frontcheck = true;
        }
        if (other.tag == "Enemy")
        {
            frontcar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OneRoadEntry")
        {
            frontcheck = false;
        }
        if (other.tag == "Enemy")
        {
            frontcar = false;
        }
    }
}
