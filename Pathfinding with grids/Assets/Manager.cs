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
        Vector3 t = new Vector3(0,0,0);
        foreach (var item in rooms)
        {
            t += item.Value.transform.position;
            newGridSizeX +=  30;
            //newGridSizeY += item.Value.gridSizeY;
            t = item.Value.transform.position;
        }

        
        currentGrid.CreateDynamicGrid(t, newGridSizeX, 30);
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
