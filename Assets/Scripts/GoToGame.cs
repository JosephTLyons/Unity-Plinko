using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Space))
            SceneManager.LoadScene ("Game");
    }
}
