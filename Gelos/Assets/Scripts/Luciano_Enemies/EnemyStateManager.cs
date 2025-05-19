using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public static EnemyStateManager Instance { get; private set; }
    private Dictionary<string, bool> enemyStates = new Dictionary<string, bool>();
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void SaveEnemyState(string enemyName, bool isAlive)
    {
        enemyStates[enemyName] = isAlive;
        PlayerPrefs.SetInt(enemyName, isAlive ? 1 : 0);
    }
    public bool GetEnemyState(string enemyName)
    {
        Debug.Log("Buscando estado de enemigo: " + enemyName);
        return PlayerPrefs.GetInt(enemyName, 1) == 1;
    }
}
