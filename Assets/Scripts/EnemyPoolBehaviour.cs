using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagerBehaviour : MonoBehaviour {

    public int initalNumberOfEnemies;
    public EnemyController enemyTemplate;

    List<EnemyController> enemies;
    

	// Use this for initialization
	void Start () 
    {
        enemies = new List<EnemyController>();
        for (var i = 0; i < initalNumberOfEnemies; i++)
        {
            var enemy = CreateEnemy();
            enemies.Add(enemy);
        }
	}

    // Update is called once per frame
    void Update()
    {

	}

    EnemyController CreateEnemy()   
    {
        return (EnemyController)GameObject.Instantiate(enemyTemplate);
    }
}
