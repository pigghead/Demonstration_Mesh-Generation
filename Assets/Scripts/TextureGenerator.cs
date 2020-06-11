using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Draw a texture from a color map array (1d)
public static class TextureGenerator
{
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);  // the width values
        int height = heightMap.GetLength(1);  // the height values

        // array of colors of length width * height
        Color[] colorMap = new Color[width * height];

        // Loop through all values of our 2D array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // To get the column: y * width, add x to find the current item in fetched row
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColorMap(colorMap, width, height);
    }
}
