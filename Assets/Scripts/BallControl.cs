using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
	void Update () 
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Play swallow ball sound
            Destroy (gameObject);
        }

        else if (collision.gameObject.tag == "Peg")
        {
            // Play peg sound
        }
    }
}