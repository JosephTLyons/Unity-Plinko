using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour 
{
    public GameObject paddleControlRef, highScoreLabelRef;
    static int highScore = 0;

	void Start() 
    {
        // High score is split into two objects, the object of the label and the object that has the script
        // This is so I can use DontDestroyOnLoad() to keep the script from being destroyed and score from being lost
        DontDestroyOnLoad (this);
        highScoreLabelRef.GetComponent<TextMesh>().text = "High Score: " + highScore;
	}

    public void setHighScoreLabel()
    {
        if (paddleControlRef.GetComponent<PaddleControl>().gameScore > highScore)
            highScore = paddleControlRef.GetComponent<PaddleControl>().gameScore;
        
        highScoreLabelRef.GetComponent<TextMesh>().text = "High Score: " + highScore;
    }
}