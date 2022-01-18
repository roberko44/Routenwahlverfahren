using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public int width = 4;
    public int height = 2;
    public float cellSize = 10f;
    public Vector3 originPosition;
    private Grid grid;

    private void Start()
    {
        grid = new Grid(width, height, cellSize, originPosition);
       // new Grid(2, 2, 10f, new Vector3(20, -20));
       // new Grid(2, 2, 5f, new Vector3(-20, -20));
       // new Grid(2, 2, 5f, new Vector3(-20, 20));
    }

    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
        }
        if (Input.GetMouseButtonDown(1))
        {
           Debug.Log( grid.GetValue(GetMouseWorldPosition()));
        }
    }






    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
