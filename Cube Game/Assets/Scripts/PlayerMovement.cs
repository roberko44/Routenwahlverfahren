using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int trigger = 0;
    public float forwardForce;
    public float rightForce;
    public float leftForce;

    // Start is called before the first frame update
    void Start()
    {
    }

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

        if(rb.position.y < 0 && trigger == 0)
        {
            Debug.Log("We fall. You lose.");
            trigger = 1;
        }
    }
}
