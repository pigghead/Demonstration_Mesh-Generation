using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeMeshData
{
    public static Vector3[] vertices = 
    {
        new Vector3(1,1,1),
        new Vector3(-1,1,1),
        new Vector3(-1,-1,1),
        new Vector3(1,-1,1),

        new Vector3(-1,1,-1),
        new Vector3(1,1,-1),
        new Vector3(1,-1,-1),
        new Vector3(-1,-1,-1)
    };

    public static int[][] faceTriangles =
    {
        new int[] { 0, 1, 2, 3 },  // North face
        new int[] { 5, 0, 3, 6 },  // East face
        new int[] { 4, 5, 6, 7 },  // South face
        new int[] { 1, 4, 7, 2 },  // West face
        new int[] { 1, 0, 5, 4 },  // Top face
        new int[] { 3, 2, 7, 6 }   // Bottom face
    };

    public static Vector3[] FaceVertices(int direction)
    {
        Vector3[] fV = new Vector3[4];

        for (int i = 0; i < fV.Length; i++)
        {
            fV[i] = vertices[faceTriangles[direction][i]];
        }
        return fV;
    }
}
