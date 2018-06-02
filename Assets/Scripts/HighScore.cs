using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject paddleControlRef, highScoreLabelRef;
    public int highScore = 0;

    void Start()
    {
        // High score is split into two objects, the label object the object that has the script
        // This is so I can use DontDestroyOnLoad() to keep the script from being destroyed
        // and high score from being lost when the scene reloads
        DontDestroyOnLoad (this);

        // Retrieve saved score on disk
        if (PlayerPrefs.HasKey ("High Score"))
            highScore = PlayerPrefs.GetInt ("High Score");

        setHighScoreLabel();
    }

    public void setHighScoreLabel()
    {
        if (paddleControlRef.GetComponent<PaddleControl>().gameScore > highScore)
            highScore = paddleControlRef.GetComponent<PaddleControl>().gameScore;

        highScoreLabelRef.GetComponent<TextMesh>().text = "High: " + highScore;
    }
}
