using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour 
{
    public GameObject paddleControlRef;
    int highScore;

	void Start() 
    {
        DontDestroyOnLoad (this);
        gameObject.SetActive (false);
        highScore = 0;
	}

    public void setHighScoreLabel()
    {
        if (paddleControlRef.GetComponent<PaddleControl>().gameScore > highScore)
            highScore = paddleControlRef.GetComponent<PaddleControl>().gameScore;
        
        GetComponent<TextMesh>().text = "High Score: " + highScore;
    }
}
