using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
    int playWoodenHitAudioDelay;
    bool canPlayAudio;

    void Start()
    {
        playWoodenHitAudioDelay = 0;
        canPlayAudio = true;
    }

	void Update() 
    {
        if (playWoodenHitAudioDelay-- <= 0)
        {
            canPlayAudio = true;
        }
            

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
            if (canPlayAudio)
            {
                GetComponent<AudioSource>().Play();
                canPlayAudio = false;
                playWoodenHitAudioDelay = 10;
            }
        }
    }
}