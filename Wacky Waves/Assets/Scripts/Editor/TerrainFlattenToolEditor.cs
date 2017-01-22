using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainFlattenTool))]
public class TerrainFlattenToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        TerrainFlattenTool tool = (TerrainFlattenTool)target;
        if(GUILayout.Button("Flatten Map"))
        {
            tool.Flatten();
        }
    }
}
