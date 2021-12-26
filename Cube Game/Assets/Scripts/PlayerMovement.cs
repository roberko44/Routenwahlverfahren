using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float rightForce;
    public float leftForce;


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.position);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);    // Add a forward force

        if (Input.GetKey("d"))
        {
           // Debug.Log("rechts");
            rb.AddForce(rightForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }else if (Input.GetKey("a"))
        {
          //  Debug.Log("links");
            rb.AddForce(-leftForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
