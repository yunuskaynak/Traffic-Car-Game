using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour
{
    [SerializeField] float _movSpeed = 20;
    public SpawnManager spawnManager;
    private Rigidbody rb;
    public bool isStopped = false;
    int highscore;
    Animator anim;
    public GameObject RestartButton;
    public static int RoadCount = 0;
    private Vector3 touchPosition, direction;
    private Vector3 mOffset;
    private float mZCoord;

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        highscore = PlayerPrefs.GetInt("highscore");
    }
    private void OnMouseDown()
    {
        if (!isStopped) 
        { 
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        }
    }
    private Vector3 GetMouseWorldPos()
    {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;
            return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        if (!isStopped)
        {
            transform.position = new Vector3(GetMouseWorldPos().x + mOffset.x, transform.position.y, transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            rb.velocity = transform.forward * _movSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Police") {
            Debug.Log("Police Triggered");
            GameOver();

        }
        if (other.tag == "NotRoad")
        {
            Debug.Log("NotRoad Triggered");
            GameOver();

        }
        if (other.tag == "Enemy")
        {
            Score.ScoreValue++;
        }
        if (other.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
            RoadCount++;
        }
        if (other.tag == "FinishLine")
        {
            GameOver();
            Debug.Log("FinishLine Touched!");
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Score", Score.ScoreValue);
        if (Score.ScoreValue > highscore)
        {
            PlayerPrefs.SetInt("highscore", Score.ScoreValue);
        }
        isStopped = true;
        rb.velocity = Vector3.zero;
        RestartButton.SetActive(true);
    }
}
