using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    public GameController gc;

    void OnTriggerEnter2D(Collider2D other) {
        // If a player does not destroy a building they should have
        // destroyed, removes 5 points from the player.
        if (other.gameObject.GetComponent<BuildingController>().isBad) {
            gc.AddPoints(-5);
        }
    }
}
