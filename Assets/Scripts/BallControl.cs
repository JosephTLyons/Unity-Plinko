using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
    // These attributes are used to limit how quickly the audio sample can play
    // Without them, when the ball bounces, the sound is triggered very quickly and it sounds unnatural
    int playWoodenHitSoundAfterDelay;
    public int ballValue;

    void Start()
    {
        ballValue = Random.Range (1, 6);
        GetComponentInChildren<TextMesh>().text = ballValue.ToString();
        playWoodenHitSoundAfterDelay = 0;
    }

	void Update() 
    {
        playWoodenHitSoundAfterDelay--;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy (gameObject);
        }

        else if (collision.gameObject.tag == "Peg")
        {
            if (playWoodenHitSoundAfterDelay <= 0)
            {
                GetComponent<AudioSource>().Play();
                playWoodenHitSoundAfterDelay = 8;
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy (gameObject);
    }
}