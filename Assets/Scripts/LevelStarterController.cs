using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarterController : MonoBehaviour
{
    void Update()
    {
        // Starts the game at the beginning when space is pressed.
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
