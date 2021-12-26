using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Time").SendMessage("Finish");
    }
}
