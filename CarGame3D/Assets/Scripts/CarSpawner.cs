using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnZ, xx;
    public GameObject car,bus,police;
    public Controller Contoller;
    

    // Start is called before the first frame update
    void Start()
    {
        if(Controller.RoadCount < 20)
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnCars()
    {
        while (!Contoller.isStopped) {
            if (Random.Range(0, 2) == 0)
            {
                xx = 1.61f;
            }
            else { xx = -0.88f; }

            float playerpos = GameObject.Find("Player").transform.position.z;

            if (Random.Range(0, 3) == 0)
            {
                Instantiate(car, new Vector3(-3.06f, 0.14f, playerpos + spawnZ), Quaternion.identity);
                Instantiate(car, new Vector3(-5.41f, 0.14f, playerpos + spawnZ), Quaternion.identity);
            }
            else if (Random.Range(0, 4) == 0)
            {
                Instantiate(police, new Vector3(-3.06f, 0.14f, playerpos + spawnZ), Quaternion.identity);
            }
            else
            {
                Instantiate(car, new Vector3(-3.06f, 0.14f, playerpos + spawnZ), Quaternion.identity);
            }
            if (Random.Range(0, 3) == 0)
                {
                Instantiate(car, new Vector3(1.61f, 0.15f, playerpos + spawnZ), Quaternion.identity);
                Instantiate(car, new Vector3(-0.88f, 0.14f, playerpos + spawnZ), Quaternion.identity);
                }
                else if (Random.Range(0,4) == 0) {
                    Instantiate(police, new Vector3(1.61f, 0.14f, playerpos + spawnZ), Quaternion.identity);
                }
                else {

                    Instantiate(car, new Vector3(xx, 0.14f, playerpos + spawnZ), Quaternion.identity);
                }

            yield return new WaitForSeconds(0.7f);
        }
    }

}
