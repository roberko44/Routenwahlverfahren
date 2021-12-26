using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 rightForce;
    public Vector2 leftForce;
    public Vector2 upForce;
    public Vector2 downForce;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            rb.AddForce(upForce);
        }
        if (Input.GetKey("a"))
        {
           rb.AddForce(leftForce);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(downForce);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(rightForce);
        }
    }
}
