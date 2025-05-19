using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapLoader : MonoBehaviour
{
    private EnemyStateManager enemyStateManager;
    void Start()
    {
        enemyStateManager = EnemyStateManager.Instance;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Invoke("DestroyDeadEnemies", 0.1f);
    }
    void DestroyDeadEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (!enemyStateManager.GetEnemyState(enemy.gameObject.name))
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}

