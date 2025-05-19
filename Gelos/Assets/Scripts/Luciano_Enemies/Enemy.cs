using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyStateManager enemyStateManager;
    void Start()
    {
        enemyStateManager = EnemyStateManager.Instance;
        Debug.Log("Nombre del enemigo: " + gameObject.name);
        Debug.Log("Estado del enemigo: " + enemyStateManager.GetEnemyState(gameObject.name));
        if (!enemyStateManager.GetEnemyState(gameObject.name))
        {
            Debug.Log("Destruyendo enemigo...");
            Destroy(gameObject);
        }
    }
}
