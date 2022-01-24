using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unwalkableMask; //Unwalkable Area
    public Vector2 gridWorldSize; //Area of the Grid
    public float nodeRadius; //Space of Node
    Node[,] grid;

    float nodeDiameter; //Diameter of a Node
    public int gridSizeX, gridSizeY;

    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        //CreateGrid();
    }

    public void CreateDynamicGrid(Vector3 t, int gsx, int gsy)
    {
        nodeDiameter = 0.5f * 2;
        gridSizeX = Mathf.RoundToInt(gsx / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gsy / nodeDiameter);

        Debug.Log("gridsize x : " + gsx);
        Debug.Log("gridsize y : " + gsy);


        grid = new Node[gridSizeX, gridSizeY];
        // Bottom Left Corner of the World
        Vector3 worldBottomLeft = t - Vector3.right * gsx / 2 - Vector3.forward * gsy / 2;  //NEED SOME ADJUSTMENT

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);  //NEED SOME ADJUSTMENT
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)); //If there is a collision trigger
                grid[x, y] = new Node(walkable, worldPoint, x, y);

            }
        }

        Debug.Log("Node: " + this.grid.Length);
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        // Bottom Left Corner of the World
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for(int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)); //If there is a collision trigger
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            
            }
        }
    }
    
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY){
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }
    
    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    public List<Node> path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y)); //y is z in Unity
   
        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable)?Color.white:Color.red; //If its not walkable change the color to red. Otherwise to white.
               if (path != null)
                {
                    if (path.Contains(n))
                    {
                        Gizmos.color = Color.black;
                    }
                }
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    
    }

}