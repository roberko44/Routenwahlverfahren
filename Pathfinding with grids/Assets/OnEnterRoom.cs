using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterRoom : MonoBehaviour
{
    Grid g;
    Manager manager;

    private void Start()
    {
        g = GetComponent<Grid>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Seeker")
        {
            Debug.Log(transform.name + " on enter");
            manager.addRoom(transform.name, g);
        }
    }

  
}
