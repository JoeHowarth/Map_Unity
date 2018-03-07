using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileMap))]
public class TileMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TileMap tileMap = (TileMap)target;

        if (GUILayout.Button("Regeneration")) {
            tileMap.BuildMesh();
        }
    }
}
