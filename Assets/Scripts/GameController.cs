using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject goodBuilding;
    public GameObject badBuilding;
    public GameObject gameOverScreen;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI finalPoints;
    public PlayerController playerController;

    public float minimumSpawnTime;
    public float maxSpawnVariation;
    
    private int hp = 3;
    private int points;

    void Start() {
        Time.timeScale = 1;
        StartCoroutine(Spawner());
    }

    /// <summary>
    /// Spawns buildings with variation in the spawn time.
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawner() {
        while (true) {
            GameObject go = Instantiate(goodBuilding);
            go.transform.position = this.transform.position;
            yield return new WaitForSeconds(Random.Range(minimumSpawnTime, minimumSpawnTime + maxSpawnVariation));
        }
    }

    /// <summary>
    /// Adds points to player and shows the current amount of points on screen.
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points) {
        this.points += points;
        pointsText.text = "Points: " + this.points;
    }

    /// <summary>
    /// Removes HP. If HP goes to zero, shows the Game over -screen.
    /// </summary>
    /// <param name="hp"></param>
    public void RemoveHp(int hp) {
        this.hp -= hp;
        hpText.text = "HP: " + this.hp;
        // Stops the game, shows the Game over -screen with the
        // final points.
        if (this.hp == 0) {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            playerController.gameOver = true;
            finalPoints.text = "Points: " + points;
        }
    }
}