using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour 
{
    public GameObject paddleControlRef, highScoreLabelRef;
    static int highScore = 0;

	void Start() 
    {
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