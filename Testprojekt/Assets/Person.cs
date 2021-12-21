using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public struct DynamicValue
    {
        public DynamicValue( float x, float y, float z, float a, int c)
        {
            xPos = x;
            yPos = y;
            zPos = z;
            angle = a;
            color = c;

        }
        public float xPos { get; }
        public float yPos { get; }
        public float zPos { get; }
        public float angle { get; }
        public int color { get; }

    }


    public int id;
    public int currentFrame;
    public float xpos, ypos, zpos;
    public Dictionary<int, DynamicValue> steps = new Dictionary<int, DynamicValue>();
    public float ellipseA, ellipseB;
    public float angle;
    public float color;
    public int index = 1;
    public int oldIndex = -1;


    public Person(int i, float ea, float eb)
    {
        id = i;
        ellipseA = ea;
        ellipseB = eb;
        
    }

   

    



}
