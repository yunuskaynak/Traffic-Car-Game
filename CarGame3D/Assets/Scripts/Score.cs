using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;
    int hscore = 0;
    Text scoretext;
    public Text hscoretext;
    void Start()
    {
        scoretext = GetComponent<Text>();
        hscore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        hscoretext.text = "Highscore: " + hscore;
        scoretext.text = "Score: " + ScoreValue;
    }
}
