using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolBehaviour : MonoBehaviour {

    public float enemySpawnRadius;
    public int numberOfEnemiesInRadius;
    public EnemyController enemyTemplate;

    List<EnemyController> enemies;
    PlayerController[] players;
    
	// Use this for initialization
	void Start () 
    {
        enemies = new List<EnemyController>();
        players = GameObject.FindObjectsOfType<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
        // for each player check there are so many enemies near by
        foreach(var player in players)
        {
            var num = 0;
            foreach (var enemy in enemies)
            {
                var dist = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (dist < enemySpawnRadius)
                {
 
                }
            }
        }
	}

    EnemyController CreateEnemy(Transform centre, float radius)   
    {
        var enemy = (EnemyController)GameObject.Instantiate(enemyTemplate);

        return enemy;
    }
}
