using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    public float movSpeed = 3f;
    Rigidbody rb;
    bool isCrashed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isCrashed)
        {
            if (transform.position.x <= -2.78f)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, -1.5f);
                rb.velocity = transform.forward * -movSpeed;
            }
            else
            {
                rb.velocity = transform.forward * movSpeed;
            }
        }
        float PlayerPos = GameObject.Find("Player").transform.position.z;
        if (transform.position.z < PlayerPos - 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Crashed();
        }
    }
    public void Crashed()
    {
        rb.velocity = Vector3.zero;
        isCrashed = true;
    }
}
