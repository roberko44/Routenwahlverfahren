using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement pm;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name != "Ground")
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                pm.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
