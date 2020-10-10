using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRightCheck : MonoBehaviour
{
    Rigidbody rb;
    public bool rightcar=false,rightroad=false;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeftChecker")
        {
            rightcar = true;
        }
        else if (other.tag == "NotRoad")
        {
            rightroad = true;
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
            rightcar = false;
        }
        else if (other.tag == "NotRoad")
        {
            rightroad = false;
        }
    }
}
