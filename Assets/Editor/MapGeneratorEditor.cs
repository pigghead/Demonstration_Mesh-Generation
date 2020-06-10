using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGenerator = (MapGenerator)target;

        // if something changes in the inspector, automatically reflect the change
        if (DrawDefaultInspector())
            if (mapGenerator.autoUpdate)
                mapGenerator.GenerateMap();

        if (GUILayout.Button("Regenerate"))
        {
            mapGenerator.GenerateMap();
        }
    }
}
