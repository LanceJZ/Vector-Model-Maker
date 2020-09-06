using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineModel : MonoBehaviour
{
    public string fileName;
    public Material mat;
    public GameObject[] linePoints;
    [HideInInspector]
    public int id;
    FileIO fileIO = new FileIO();

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveFile();
        }
    }

    void SaveFile()
    {
        if (fileName.Length < 1)
        {
            Debug.Log("No file name.");
            return;
        }

        if (linePoints.Length < 2)
        {
            Debug.Log("No lines.");
            return;
        }

        List<Vector3> verticies = new List<Vector3>();

        foreach (GameObject lines in linePoints)
        {
            verticies.Add(new Vector3(lines.transform.position.x, lines.transform.position.y, 0));
        }

        fileIO.WriteVectorModelFile(verticies.ToArray(), fileName);

        Debug.Log(fileName + "File Saved");
    }

    void OnDrawGizmos()
    {
        if (Lines.instance != null && linePoints != null)
        {
            Disable();
            Create();
        }
    }

    void OnDestroy()
    {
        Disable();
    }

    public void Disable()
    {
        if (linePoints != null)
        {
            Lines.instance.modelPoints.Remove(linePoints);
        }
    }

    public void Create()
    {
        Lines.instance.modelPoints.Add(linePoints);
        id = Lines.instance.modelPoints.Count;
    }
}
