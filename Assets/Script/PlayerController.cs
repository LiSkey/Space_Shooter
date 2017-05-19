using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float x_min, x_max, z_min, z_max;
}

public class PlayerController : MonoBehaviour
{


    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shotSpawn;
    public GameObject shot;

    private float myTime;
    private float nextFire;
    public float fireDelta;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal input is "+ horizontalInput + "\n");

        rb.velocity = new Vector3(horizontalInput * speed, 0.0f, verticalInput * speed);

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.x_min, boundary.x_max),
            rb.position.y,
            Mathf.Clamp(rb.position.z, boundary.z_min, boundary.z_max)
        );


        rb.rotation = Quaternion.Euler(0, 0, -(tilt * rb.velocity.x));
    }


    void Update()
    {

        myTime = myTime + Time.deltaTime;



        if (Input.GetKey(KeyCode.Space) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            Instantiate(shot, shotSpawn.transform.position, Quaternion.identity);

            // create code here that animates the newProjectile        
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

}