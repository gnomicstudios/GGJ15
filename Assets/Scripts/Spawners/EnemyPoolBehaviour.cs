using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolBehaviour : MonoBehaviour
{

    public float enemySpawnRadius = 10.0f;
    public float minUnitEnemySpawnRadius = 0.2f;
    public int numberOfEnemiesInRadius;
    public EnemyController enemyTemplate;

    List<EnemyController> enemies;
    Players players;
    Random rand;
    
    // Use this for initialization
    void Start()
    {
        enemies = new List<EnemyController>();
        players = FindObjectOfType<Players>();
    }

    // Update is called once per frame
    void Update()
    {
        // for each player check there are enough enemies near by else spawn one
        foreach(var p in players.activePlayers)
        {
            var player = p.gameObject.GetComponent<PlayerController>();
            if(player == null || !player.isAlive)
            {
                continue;
            }

            var num = 0;
            foreach(var enemy in enemies)
            {
                var dist = Vector3.Distance(player.transform.position, enemy.transform.position);
                if(dist < enemySpawnRadius)
                {
                    num++;
                }
            }

            if(num < numberOfEnemiesInRadius)
            {
                var enemy = CreateEnemy(player.transform);
                enemies.Add(enemy);
            }
        }
    }

    public static Vector3 GetInsideUnitSphere(float minUnitRadius)
    {
        if(!(minUnitRadius < 1.0f && minUnitRadius > 0.0f))
        {
            throw new System.ArgumentException("must be between 0.0 - 1.0");
        }

        var value = Random.insideUnitSphere;
        if(Mathf.Abs(value.x) < minUnitRadius)
        {
            if(value.x < 0.0f)
            {
                value.x -= minUnitRadius;
            }
            else
            {
                value.x += minUnitRadius;
            }
        }
        if(Mathf.Abs(value.z) < minUnitRadius)
        {
            if(value.z < 0.0f)
            {
                value.z -= minUnitRadius;
            }
            else
            {
                value.z += minUnitRadius;
            }

        }
        return value;
    }

    EnemyController CreateEnemy(Transform centre)
    {
        var enemy = (EnemyController)GameObject.Instantiate(enemyTemplate);
        enemy.transform.parent = gameObject.transform;

        var pos = GetInsideUnitSphere(minUnitEnemySpawnRadius) * enemySpawnRadius;

        pos += centre.transform.position;
        pos.y = 0;

        enemy.transform.position = pos;

        return enemy;
    }
}
