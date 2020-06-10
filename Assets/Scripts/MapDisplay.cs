using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);  // the width values
        int height = noiseMap.GetLength(1);  // the height values

        // Create a new texture with the width and height 
        Texture2D texture = new Texture2D(width, height);

        // array of colors of length width * height
        Color[] colorMap = new Color[width * height];

        // Loop through all values of our 2D array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // To get the column: y * width, add x to find the current item in fetched row
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        texture.SetPixels(colorMap);
        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;

        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
