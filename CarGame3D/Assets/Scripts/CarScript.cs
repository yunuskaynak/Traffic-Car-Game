using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float movSpeed = 20f;
    [SerializeField] private float _turnSpeed = 1f;
    public Controller Contoller;
    float near = 0;
    bool yesturnpls = false;
    Rigidbody rb;
    DOTweenPath dott;
    [SerializeField] CarRightCheck RightScript;
    [SerializeField] CarLeftCheck LeftScript;
    [SerializeField] FrontCheck FrontScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        dott = gameObject.GetComponent<DOTweenPath>();
        if (Random.Range(0, 3) == 0)
        {
            yesturnpls = true;
        }
    }

    private void Update()
    {
        float playerpos = GameObject.Find("Player").transform.position.z;
        near = gameObject.transform.position.z - playerpos;
        if (transform.position.x <= -1.87f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, -1.5f);
            rb.velocity = transform.forward * -movSpeed;
        }
        else
        {
            rb.velocity = transform.forward * movSpeed;
        }
        float PlayerPos = GameObject.Find("Player").transform.position.z;
        if (transform.position.z < PlayerPos - 5)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (transform.position.x <= -1.87f)
        {
            if (!RightScript.rightcar && !RightScript.rightroad && yesturnpls)
            {
                if (transform.localScale.z != -1.5f && near <= 48)
                {
                    Debug.Log("Ters Yönde Değil!");
                    if (transform.position.x != 1.61f)
                        rb.velocity = transform.right * _turnSpeed;
                }
            }
        }
        if (transform.position.x >= -1.88f)
        {
            if (!LeftScript.leftcar && !LeftScript.leftroad && yesturnpls)
            {
                if (transform.localScale.z != 1.5f && near <= 48)
                {
                    Debug.Log("Ters Yönde Değil!");
                    if (transform.position.x != -5.30f)
                        rb.velocity = transform.right * _turnSpeed;
                }
            }
        }
        if (FrontScript.frontcheck || FrontScript.frontcar)
        {
            GetComponent<Rigidbody>().Sleep();

        }
        else if (!LeftScript.leftcar && !LeftScript.leftroad)
        {
            if (transform.localScale.z != 1.5f && near <= 48)
            {
                GetComponent<Rigidbody>().WakeUp();
                Turn();
            }
        }
    }
    void Turn()
    {
        rb.velocity = transform.right * -_turnSpeed;
    }
}
