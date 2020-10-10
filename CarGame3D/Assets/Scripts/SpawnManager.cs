using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadManager roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadManager>();
    }
    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
    }
}
