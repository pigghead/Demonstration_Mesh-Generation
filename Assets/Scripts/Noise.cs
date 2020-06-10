﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    // Octaves - layering of noises to produce terrain
    // Lacunarity - controls frequency of octaves (higher lacunarity = less influence)
    // Persistance - controls the decrease in amplitudes (makes for smoother declines/inclines)
    public static float[,] GenerateNoiseMap(int width, int height, float scale, int octaves, float persistanceVal, float lacunarityVal)
    {
        // Prevent a division by zero error 
        if (scale <= 0)
        {
            scale = 0.0025f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float[,] noiseMap = new float[width, height];

        // Looping through 2d float
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Amplitude, frequency, and noise height
                float amplitude = 1;  // maximum height
                float frequency = 1;  // how quickly the height will change
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float tempX = x / scale * frequency;
                    float tempY = y / scale * frequency;

                    // Perlin noise is gradual noise change (smoother in a sense)
                    float perlinVal = Mathf.PerlinNoise(tempX, tempY) * 2 - 1;
                    noiseHeight += perlinVal * amplitude;

                    amplitude *= persistanceVal;
                    frequency *= lacunarityVal;
                }

                // Control the range of values between 0 and 1
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
            }
        }

        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                // STUBBED 4:26 PM
            }
        }

        return noiseMap;
    }
}