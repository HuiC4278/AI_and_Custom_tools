using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(S_LevelManager))]
public class LevelManagerEditor : Editor
{
    //Override the function that draws the inspector GUI
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();
        S_LevelManager myScript = (S_LevelManager)target;
        // Visual Divider
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Developer Tools", EditorStyles.boldLabel);
        // Create a Button when the runs button is clicked
        if (GUILayout.Button("Reset Level"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Enemy
        // Checks difficalty
        if (myScript.difficultyMultiplier <= 0)
        {
            EditorGUILayout.HelpBox("Difficulty cannot be zero or less! Enemies will not spawn.", MessageType.Warning);
        }
        // Checks max Enemies Count
        if (myScript.maxEnemies <= 0)
        {
            EditorGUILayout.HelpBox("Enemies will not spawn.", MessageType.Warning);
        }
        // Checks Enemies Health
        if (myScript.EnemyHealth <= 0)
        {
            EditorGUILayout.HelpBox("Enemys health cannot be zero or less! Enemies will not spawn.", MessageType.Warning);
        }
        // Checks Enemies Damage
        if (myScript.EnemyDamage <= 0)
        {
            EditorGUILayout.HelpBox("Enemys cant damage the player", MessageType.Warning);
        }

        // Player
        // Ckecks Players Health
        if (myScript.PlayerHealth <= 0)
        {
            EditorGUILayout.HelpBox("Player health cannot be zero or less! Player will not spawn.", MessageType.Error);
        }
        // Checks Players Level
        if (myScript.PlayerLevel < 0)
        {
            EditorGUILayout.HelpBox("Player Level cannot less then zero.", MessageType.Warning);
        }
        // Checks Players staminer
        if (myScript.Staminer <= 0)
        {
            EditorGUILayout.HelpBox("Player staminer cannot be zero or less! Player will not move.", MessageType.Warning);
        }
    }
}
