using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        
    }

    void Start()
    {
        MakeCube();
        UpdateMesh();
    }

    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }

    // MakeCube will call this multiple times to build the cube
    void MakeFace(int direction)
    {
        vertices.AddRange(CubeMeshData.FaceVertices(direction));
        int verticesCount = vertices.Count;

        triangles.Add(verticesCount - 4);
        triangles.Add(verticesCount - 4 + 1);
        triangles.Add(verticesCount - 4 + 2);
        triangles.Add(verticesCount - 4);
        triangles.Add(verticesCount - 4 + 2);
        triangles.Add(verticesCount - 4 + 3);
    }

    void UpdateMesh()
    {
        mesh.Clear();  // clear the mesh from any previous data

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
