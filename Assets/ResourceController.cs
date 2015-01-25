using UnityEngine;
using System.Collections;

public class ResourceController : MonoBehaviour
{
    internal bool hasSpawnedPlayer = false;
    private Players playerSpawner;
    Health health;
    Healer healer;
    Flame flame;
    SafeZone safeZone;

	// Use this for initialization
	void Start ()
    {
        playerSpawner = FindObjectOfType<Players> ();
        healer = GetComponentInChildren<Healer> ();
        healer.OnStartedHealingPlayer += OnStartedHealingPlayer;

        health = GetComponentInChildren<Health> ();
        flame = GetComponentInChildren<Flame> ();
        safeZone = GetComponentInChildren<SafeZone> ();
	}

    void OnStartedHealingPlayer (PlayerController obj)
    {
        if (!hasSpawnedPlayer)
        {
            var dirn = RandomExtensions.GetOnUnitCircleXZ();
            var newPlayer = playerSpawner.InstantiateNewPlayer(this.transform.position + dirn * 3.0f);
            newPlayer.SetTarget(this.transform.position + dirn * 10.0f);
            newPlayer.SetIsAIControlled(true);
            hasSpawnedPlayer = true;
            Debug.Log("Spawned new player!");
        }
    }

    void Update()
    {
        if (health.currentHealth <= 0.0f)
        {
            flame.gameObject.SetActive(false);
            healer.enabled = false;
            safeZone.renderer.enabled = false;
            this.enabled = false;
        }

    }
}
