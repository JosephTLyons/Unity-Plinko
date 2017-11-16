using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour 
{
    public KeyCode moveLeft, moveRight;

    public float speedX = 0;
    
	void Start()
    {
    }

	void Update() 
    {
        // move the player in the 4 directions based on the keys we set up for it
        if (Input.GetKey (moveLeft)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speedX, 0f);
            //rigidbody2D.AddForce(new Vector2( 0, -rigidbody2D.velocity.y));
            //rigidbody2D.AddForce(new Vector2(0, speed));
        } 

        else if (Input.GetKey (moveRight)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, 0f);
            //rigidbody2D.AddForce(new Vector2(0, -rigidbody2D.velocity.y));
            //rigidbody2D.AddForce(new Vector2(0, -speed));
        }

        else 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //rigidbody2D.AddForce(new Vector2(0, -rigidbody2D.velocity.y));
        }
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}