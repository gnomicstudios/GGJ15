using UnityEngine;
using System.Collections;

public class NewPlayerSpawner : MonoBehaviour
{
    private bool hasSpawnedPlayer = false;
    private Players playerSpawner;

	// Use this for initialization
	void Start ()
    {
        playerSpawner = FindObjectOfType<Players> ();
        GetComponentInChildren<Healer> ().OnStartedHealingPlayer += OnStartedHealingPlayer;
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
        }
    }
}
