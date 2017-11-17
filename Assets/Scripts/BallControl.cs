using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
    // These attributes are used to limit how quickly the audio sample can play
    // Without them, when the ball bounces, the sound is triggered very quickly and it sounds unnatural
    int woodHitSoundDelayTime;
    public int ballWorth;

    void Start()
    {
        ballWorth = Random.Range (1, 6);
        GetComponentInChildren<TextMesh>().text = ballWorth.ToString();
        woodHitSoundDelayTime = 0;
    }

	void Update() 
    {
        woodHitSoundDelayTime--;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy (gameObject);

        else if (collision.gameObject.tag == "Peg")
        {
            if (woodHitSoundDelayTime <= 0)
            {
                GetComponent<AudioSource>().Play();
                woodHitSoundDelayTime = 8;
            }
        }
    }
}