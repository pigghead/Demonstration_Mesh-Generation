using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    //Vector3[] vertices;
    //int[] triangles;

    List<Vector3> vertices;
    List<int> triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //CreateShape();
        UpdateMesh();
    }

    //void CreateShape()
    //{
    //    // Specify elements wanted within the array
    //    vertices = new Vector3[]
    //    {
    //        new Vector3 (0, 0, 0),
    //        new Vector3 (0, 0, 1),
    //        new Vector3 (1, 0, 0),
    //        new Vector3 (1, 0, 1)
    //    };

    //    triangles = new int[]
    //    {
    //        0, 1, 2,
    //        1, 3, 2
    //    };
    //}

    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }

    void MakeFace(int direction)
    {
        //vertices.AddRange()
    }

    void UpdateMesh()
    {
        mesh.Clear();  // clear the mesh from any previous data

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
    }
}
