using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour 
{
    public GameObject paddleControlRef;
    int highScore;

	void Start() 
    {
        highScore = 0;
        DontDestroyOnLoad (this);
	}

    public void setHighScoreLabel()
    {
        if (paddleControlRef.GetComponent<PaddleControl>().gameScore > highScore)
            highScore = paddleControlRef.GetComponent<PaddleControl>().gameScore;
        
        GetComponent<TextMesh>().text = "High Score: " + highScore;
    }
}