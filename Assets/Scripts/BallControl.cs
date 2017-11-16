using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
    // These attributes are used to limit how quickly the audio sample can play
    // Without them, when the ball bounces, the sound is triggered very quickly and it sounds unnatural
    int playWoodenHitAfterDelay;

    public AudioSource woodSound;
    public AudioSource registerSound;

    int ballValue;

    void Start()
    {
        ballValue = Random.Range (1, 6);
        GetComponentInChildren<TextMesh>().text = ballValue.ToString();
        playWoodenHitAfterDelay = 0;
    }

	void Update() 
    {
        playWoodenHitAfterDelay--;
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
            if (playWoodenHitAfterDelay <= 0)
            {
                GetComponent<AudioSource>().Play();
                playWoodenHitAfterDelay = 8;
            }
        }
    }
}