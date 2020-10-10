using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roads;
    public GameObject FinishLine;
    private float offset = 16f;
    public static bool lastroadsuceed = false;
    public int FinishLineValue;
    // Start is called before the first frame update
    void Start()
    {

        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
        if (Controller.RoadCount > FinishLineValue && lastroadsuceed == false)
        {
            float lastroad = roads[11].transform.position.z;
            Instantiate(FinishLine, new Vector3(0, 0, lastroad + offset), Quaternion.identity);
            lastroadsuceed = true;
        }
    }
}
