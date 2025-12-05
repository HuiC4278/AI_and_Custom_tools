using UnityEngine;

public class S_LevelManager : MonoBehaviour
{
    [Header("player")]
    public int PlayerHealth = 10;
    public int PlayerLevel = 10;
    public int Staminer = 10;

    [Header("Enemy")]
    public int maxEnemies = 10;
    public int EnemyHealth = 5;
    public int EnemyDamage = 5;
    public float difficultyMultiplier = 1.0f;
    
    public bool isLevelActive = false;
    public void ResetLevel()
    {
        Debug.Log("Level Reset Logic Triggered! Enemies & Player Respawned.");
        transform.position = Vector3.zero;
    }
}
