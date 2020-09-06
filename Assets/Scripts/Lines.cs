using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    // Fill/drag these in from the editor

    // Choose the Unlit/Color shader in the Material Settings
    // You can change that color, to change the color of the connecting lines
    public float dotSize = 0.025f;
    public Material lineMat;
    public GameObject testDot;
    public GameObject[] testPoints;
    [HideInInspector]
    public List<GameObject> dotsPoints = new List<GameObject>();
    [HideInInspector]
    public List<GameObject[]> modelPoints = new List<GameObject[]>();
    [HideInInspector]
    public List<GameObject[]> modelPlayerPoints = new List<GameObject[]>();
    [HideInInspector]
    public static Lines instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void DrawLines()
    {
        GL.Begin(GL.LINE_STRIP);

        foreach (GameObject[] lines in modelPoints)
        {
            if (lines.Length > 1)
            {
                lineMat.SetPass(0);
                GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));

                // Loop through each point to connect to the mainPoint
                foreach (GameObject point in lines)
                {
                    if (point != null)
                    {
                        GL.Vertex3(point.transform.position.x, point.transform.position.y, 0);
                    }
                }

            }
        }

        GL.End();
    }

    void DrawDot()
    {
        if (lineMat == null)
            return;

        if (dotsPoints.Count > 0)
        {
            GL.Begin(GL.TRIANGLES);
            lineMat.SetPass(0);
            GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));

            foreach(GameObject dot in dotsPoints)
            {
                if (dot != null)
                {
                    float x = dot.transform.position.x;
                    float y = dot.transform.position.y;

                    GL.Vertex3(0 + x, dotSize + y + .01f, 0);
                    GL.Vertex3(dotSize + x, -dotSize + y, 0);
                    GL.Vertex3(-dotSize + x, -dotSize + y, 0);
                }
            }
        }

        GL.End();
    }

    // To show the lines in the game window when it is running
    void OnPostRender()
    {
        DrawLines();
        DrawDot();
    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        if (testPoints != null)
        {
            modelPoints.Add(testPoints);
        }

        dotsPoints.Add(testDot);
        DrawLines();
        modelPoints.Clear();
        DrawDot();
        dotsPoints.Clear();

        if (instance == null)
        {
            instance = this;
        }
    }
}
