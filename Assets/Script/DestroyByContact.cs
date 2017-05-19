using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject asteroidExp;
    public GameObject playerExp;

    private GameObject gameControllerObject;
    private GameController gc;


    void Start()
    {

        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        gc = gameControllerObject.GetComponent<GameController>();
    }


    void OnTriggerEnter(Collider other)
    {




        if (other.gameObject.CompareTag("Boundary"))
            return;

        Destroy(this.gameObject);
        gc.addScore(10);
        Instantiate(asteroidExp, this.transform.position, Quaternion.identity);

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(playerExp, other.transform.position, Quaternion.identity);
            gc.gameOver();
        }


        Destroy(other.gameObject);
    }
}
