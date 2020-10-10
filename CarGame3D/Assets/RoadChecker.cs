using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoadOne")
        {
            Debug.Log("OneRoad");
        }
        if (other.tag == "DoubleRoad")
        {
            Debug.Log("DoubleRoad");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
