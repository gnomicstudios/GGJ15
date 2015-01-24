using UnityEngine;
using System.Collections;

public class EnemyRepeller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        var enemyController = other.gameObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            other.GetComponentInChildren<MovementBehaviour>().Repell(transform.position);
        }
    }
}
