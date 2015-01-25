using UnityEngine;
using System.Collections;

public class AttackZoneBehaviour : MonoBehaviour {

    public int damageAmount = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            var health = playerController.GetComponentInChildren<Health>();
            health.currentHealth -= damageAmount;
        }
    }
}
