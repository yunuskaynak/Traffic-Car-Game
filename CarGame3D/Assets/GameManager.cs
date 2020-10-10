using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Controller.RoadCount >= 15)
        {
            Time.timeScale = 1.1f;
        }
        if (Controller.RoadCount >= 20)
        {
            Time.timeScale = 1.2f;
        }
        if (Controller.RoadCount >= 30)
        {
            Time.timeScale = 1.3f;
        }
        if (Controller.RoadCount >= 40)
        {
            Time.timeScale = 1.4f;
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Score.ScoreValue = 0;
        Controller.RoadCount = 0;
        Time.timeScale = 1.0f;
    }
}
