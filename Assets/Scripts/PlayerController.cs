using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject bombPrefab;
    public TextMeshProUGUI bombText;

    public bool gameOver = false;
    
    private bool canFire = true;
    private int bombAmount = 5;


    void Update()
    {
        if (Input.GetKeyDown("space")) {
            // If the game is running, fires a bomb when
            // space is pressed.
            if (!gameOver) {
                if (canFire) {
                    if (bombAmount > 0) {
                        SpawnBomb();
                    }
                    if (bombAmount == 0) {
                        StartCoroutine(ReloadBombs());
                    }
                }
            }
            // If the game is not running, starts the game when
            // space is pressed.
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    /// <summary>
    /// Reloads the amount of bombs back to 5 after 2 seconds 
    /// when all bombs have been fired. 
    /// </summary>
    /// <returns></returns>
    IEnumerator ReloadBombs() {
        yield return new WaitForSeconds(2f);
        bombAmount = 5;
        bombText.text = "Bombs: " + bombAmount;
    }

    /// <summary>
    /// Cooldown for firing bombs. Player must wait 0.2 seconds
    /// before firing a new bomb.
    /// </summary>
    /// <returns></returns>
    IEnumerator FiringCooldown() {
        yield return new WaitForSeconds(0.2f);
        canFire = true;
    }

    /// <summary>
    /// Spawns bombs and shows the current amount of bombs on screen.
    /// </summary>
    private void SpawnBomb() {
        GameObject bomb = Instantiate(bombPrefab);
        Vector3 pos = this.transform.position;
        pos.y -= 1;
        bomb.transform.position = pos;
        bombAmount--;
        bombText.text = "Bombs: " + bombAmount;
        canFire = false;
        StartCoroutine(FiringCooldown());
    }
}
