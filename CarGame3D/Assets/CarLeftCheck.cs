using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLeftCheck : MonoBehaviour
{
    public bool leftcar = false, leftroad = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeftChecker")
        {
            leftcar = true;
        }
        else if (other.tag == "NotRoad")
        {
            leftroad = true;
        }
        else
        {
            //There is Nothing on Right!
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LeftChecker")
        {
            leftcar = false;
        }
        else if (other.tag == "NotRoad")
        {
            leftroad = false;
        }
    }
}
