using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPrefab : MonoBehaviour
{

    public GameObject agentPrefab;
    public int agentQuantity;

    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < agentQuantity; i++)
        {
            Vector2 pos = new Vector2(i+3, 5f);
            GameObject agent = Instantiate(agentPrefab, pos, Quaternion.identity);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log("papiii");
    }
}
