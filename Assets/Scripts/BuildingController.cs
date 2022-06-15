using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public SpriteRenderer sr;
    public float moveSpeed;
    public bool isBad = false;

    public Sprite[] goodSprites;
    public Sprite[] badSprites;

    void Start() {
        // Spawns good and bad buildings at a random
        // range. Chooses a random bad or good building
        // from arrays.
        float goodOrBad = Random.Range(0f, 200f);
        int randomSprite = Random.Range(0, 2);
        if (goodOrBad < 100f) {
            sr.sprite = badSprites[randomSprite];
            isBad = true;
        }
        else {
            sr.sprite = goodSprites[randomSprite];
        }
        // Destroyes a building after it cannot be seen
        // on screen anymore (after 8 seconds).
        StartCoroutine(Die());
    }

    void FixedUpdate() {
        // Makes the buildings move from right to left on screen.
        Vector3 pos = this.transform.position;
        pos.x -= moveSpeed;
        this.transform.position = pos;
    }

    /// <summary>
    /// Destroyes objects after 8 seconds.
    /// </summary>
    /// <returns></returns>
    IEnumerator Die() {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }
}
