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

       // computeBoundingBox();
    }

    // Update is called once per frame
    void Update()
    {
        if(rooms.Count != 0)
        {
      //     sumGrid();
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
        //bool stayOnce = false;
        //bool stayOnce2 = false;
        Vector3 t = new Vector3(0, 0, 0);
        foreach (var item in rooms)
        {
            /*
            if (stayOnce == false)
            {
                test = item.Value.transform.position.x;
                stayOnce = true;
            }
            */

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

        currentGrid.CreateDynamicGrid(t, newGridSizeX, 30);
    }

    public void addRoom(string name, Grid g)
    {
        if (!rooms.ContainsKey(name))
        {
            rooms.Add(name, g);
            Debug.Log("room added" + rooms.Count);
            //sumGrid();
            computeBoundingBox();
        }
        
    }


    public void computeBoundingBox()
    {
        //alle räume durchgehen
        // alle nodes durchgehen
        // min und max werte bestimmen

        int max_x = -2147483648;
        int max_y = -2147483648;
        int min_x = 2147483647;
        int min_y = 2147483647;

        foreach (var room in rooms)
        {
            //   Debug.Log("X: " + room.Value.transform.position.x);
            //   Debug.Log("Y: " + room.Value.transform.position.z);

            float x_pos = room.Value.transform.position.x -15;
            float y_pos = room.Value.transform.position.z + 15;
            //Debug.Log("X: " + x_pos + " - Y: " + y_pos);


            for (int x = 0; x <= 30; x++)
            {
                
                for (int y = 0; y <= 30; y++)
                {
                    if (x_pos < min_x)
                    {
                        min_x = Mathf.RoundToInt(x_pos);
                    }
                    if (y_pos < min_y)
                    {
                        min_y = Mathf.RoundToInt(y_pos);
                    }
                    if (x_pos > max_x)
                    {
                        max_x = Mathf.RoundToInt(x_pos);
                    }
                    if (y_pos > max_y)
                    {
                        max_y = Mathf.RoundToInt(y_pos);
                    }

                    Debug.Log("X: " + x_pos + " - Y: " + y_pos);
                    y_pos -= 1;
                }
                y_pos = room.Value.transform.position.z + 15;
                x_pos += 1;
            }

        }

        Debug.Log("WorldLeftCorner: x(" +min_x + ") ; y(" +min_y +")");
        Debug.Log("WorldUpperRightCorner: x(" + max_x + ") ; y(" + max_y + ")");

        Vector3 bottomLeftCorner = new Vector3(min_x, 1, min_y);
        Vector3 upperRightCorner = new Vector3(max_x, 1, max_y);
        Vector3 gridPos = new Vector3((max_x +min_x)/2, 0, (max_y +min_y)/2);
        int gridSizeX = max_x - min_x;
        int gridSizeY = max_y - min_y; ;

        Debug.Log("GridSizeX: " + gridSizeX + " ; GridSizeY: " + gridSizeY + " ; gridPos: " + gridPos);
        currentGrid.CreateDynamicGrid(gridPos, gridSizeX, gridSizeY);
    }

    /* just a test
   void OnDrawGizmos()
    {
        Vector3 pos = new Vector3(-30, 0, 0);
        Gizmos.DrawWireCube(pos, new Vector3(30, 1, 30)); //y is z in Unity
        float nodeDiameter = 0.5f * 2;
        Vector3 n = new Vector3(0, 0, 0);
        Gizmos.DrawCube(n, Vector3.one * (nodeDiameter - .1f));
        
    }
    */
}