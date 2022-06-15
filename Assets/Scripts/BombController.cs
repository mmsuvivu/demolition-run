using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameController gc;

    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);

        // When a bomb collides with a building, adds points to player
        // if the building was supposed to be destroyed, but removes HP
        // if the building that was not supposed to be destroyed.
        if (other.CompareTag("Building")) {
            if (other.gameObject.GetComponent<BuildingController>().isBad) {
                gc.AddPoints(10);
            }
            else {
                gc.RemoveHp(1);
            }
            Destroy(other.gameObject);
        }
    }
}
