using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, Grid> rooms;
    public Grid currentGrid;


    void Start()
    {
        rooms = new Dictionary<string, Grid>();

        currentGrid = GameObject.Find("A*").GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rooms.Count != 0)
        {
            sumGrid();
        }
    }

    /*
     * Example For Grid Merging
     * 
     * private static int[][] Concat(int[][] array1, int[][] array2)
    {
        int[][] result = new int[array1.Length + array2.Length][];

        array1.CopyTo(result, 0);
        array2.CopyTo(result, array1.Length);

        return result;
    }
     */

    private void sumGrid()
    {
        int newGridSizeX = 0, newGridSizeY = 0;
        float test = 1337;
        float test2 = 44;
        Vector3 t = new Vector3(0, 0, 0);
        Vector3 p = new Vector3(0, 0, 0);
        foreach (var item in rooms)
        {
            //Detect movement to the right
            if (test == 1337)
            {
                test = item.Value.transform.position.x;
            }
            if (item.Value.transform.position.x > test) //new grid is on the right side
            {
                test = item.Value.transform.position.x;
                Debug.Log("Test: " + test);
            }
            else 
            {

                t += item.Value.transform.position;
                Debug.Log("t: " + t + "transform.position: " + item.Value.transform.position);
                t = item.Value.transform.position;
                Debug.Log("t:" + t);
                
            }
            newGridSizeX += 30;

            /*
            if (true)
            {
                newGridSizeX += 30;

            } else if (true)
            {
                newGridSizeY += 30;
            }*/
            //newGridSizeY += item.Value.gridSizeY;

            //Detect vertical movement
            if (test2 == 44)
            {
                test2 = item.Value.transform.position.z;
            }
            if (item.Value.transform.position.z > test2) //new grid is on the upper side
            {
                test2 = item.Value.transform.position.z;
                Debug.Log("We are going up.");           //value of worldBottomLeftCorner stays the same
                Debug.Log("Test: " + test2);

            }
            else
            {
                Debug.Log("We are going down.");
                Debug.Log("Test: " + test2);
            }
            newGridSizeY += 30;

        }
        

        //Wír geben nur t wenn wir uns nach unten begeben
        currentGrid.CreateDynamicGrid(t, newGridSizeX, 30);
     //   p = rooms.Value.transform.position;
    }

    public void addRoom(string name, Grid g)
    {
        if (!rooms.ContainsKey(name))
        {
            rooms.Add(name, g);
            Debug.Log("room added" + rooms.Count);
        }
        
    }
}
