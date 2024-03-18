using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(Level))]
public class LevelEditor:Editor
{
    Level level;
    Vector2 scrallPos;

    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        level = target as Level ;
        OnRulesGUI(level);
    }

    
    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules:");
        //GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();
        for (int i = 0;i<level.rules.Count;i++)
        {
            EditorGUILayout.ObjectField(level.rules[i], typeof(Unit),true);
            
        }
        GUILayout.EndVertical();

        //GUILayout.EndScrollView();
        if (GUILayout.Button("Add Rule"))
        {
            level.rules.Add(new SpawnRule());
        }
    }
}
