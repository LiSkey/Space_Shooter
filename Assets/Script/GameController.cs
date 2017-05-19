using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;

    public Vector3 spawnValues;

    public Text countText;
    public Text gameoverText;
    public Text restartText;

    bool gameOverFlag;
    bool restartFlag;

    public int num;

    public float asteroidRate;
    public float startTime;
    public float waveInterval;

    private int score;

    // Use this for initialization
    void Start()
    {

        gameoverText.text = "";
        restartText.text = "";
        updateCountText();
        StartCoroutine(spawnWaves());

    }

    void Update()
    {
        if (restartFlag)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator spawnWaves()
    {

        yield return new WaitForSeconds(startTime);
        while (true)
        {

            for (int i = 0; i < num; i++)
            {
                Vector3 position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(asteroid, position, Quaternion.identity);

                yield return new WaitForSeconds(asteroidRate);
            }

            yield return new WaitForSeconds(waveInterval);

            if (gameOverFlag)
            {
                restartFlag = true;
                gameoverText.text = "Game Over!";
                restartText.text = "Press 'R' to restart!";
                break;
            }

        }

    }



    public void gameOver()
    {
        gameOverFlag = true;
    }

    public void addScore(int num)
    {
        score += num;
        updateCountText();
    }


    void updateCountText()
    {
        countText.text = "Score: " + score;
    }

}
