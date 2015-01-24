using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolBehaviour : MonoBehaviour {

    public float enemySpawnRadius;
    public float minEnemySpawnRadius;
    public int numberOfEnemiesInRadius;
    public EnemyController enemyTemplate;

    List<EnemyController> enemies;
    PlayerController[] players;
    Random rand;
    
	// Use this for initialization
	void Start () 
    {
        enemies = new List<EnemyController>();
        players = GameObject.FindObjectsOfType<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
        // for each player check there are enough enemies near by else spawn one
        foreach(var player in players)
        {
            if (!player.active)
                continue;

            var num = 0;
            foreach (var enemy in enemies)
            {
                var dist = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (dist < enemySpawnRadius)
                {
                    num++;
                }
            }

            if (num < numberOfEnemiesInRadius)
            {
                var enemy = CreateEnemy(player.transform);
                enemies.Add(enemy);
            }
        }
	}

    EnemyController CreateEnemy(Transform centre)   
    {
        var enemy = (EnemyController)GameObject.Instantiate(enemyTemplate);
        enemy.transform.parent = gameObject.transform;

        var delta = Random.insideUnitSphere * (enemySpawnRadius + minEnemySpawnRadius);
        
        delta.y = 0.0f;
        enemy.transform.position = centre.transform.position + delta;

        return enemy;
    }
}
