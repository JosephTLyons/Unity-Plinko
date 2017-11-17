using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour 
{
    public GameObject livesLeftLabelRef;
    public int livesLeft;

    void Start()
    {
        livesLeft = 10;
        setLivesLeftLabel();
    }

    void Update()
    {
        if (livesLeft <= 0)
        {
            // Game Over
        }
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            livesLeft--;
            setLivesLeftLabel();
            Destroy (collision.gameObject);
        }
    }

    void setLivesLeftLabel()
    {
        livesLeftLabelRef.GetComponent<TextMesh>().text = "Lives Left: " + livesLeft.ToString();
    }
}
