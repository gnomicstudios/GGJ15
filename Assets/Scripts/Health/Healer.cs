using UnityEngine;
using System.Collections.Generic;
using System;

public class Healer : MonoBehaviour
{
    public Health health;
    private List<Health> healing = new List<Health>();

    public bool healPlayer = true;
    public bool healEnemy = false;
    public int maxHealRate = int.MaxValue;
    public Action<PlayerController> OnStartedHealingPlayer;

    void OnTriggerEnter(Collider col)
    {
        Health colHealth = col.gameObject.GetComponentInChildren<Health>();
        if(colHealth == null)
        {
            //don't even bother
            return;
        }

        if(healPlayer && col.gameObject.GetComponent<PlayerController>() != null)
        {
            healing.Add(colHealth);
            if (OnStartedHealingPlayer != null)
            {
                OnStartedHealingPlayer(col.gameObject.GetComponent<PlayerController>());
            }
        }
        
        if(healEnemy && col.gameObject.GetComponent<EnemyController>() != null)
        {
            healing.Add(colHealth);
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        Health colHealth = col.gameObject.GetComponentInChildren<Health>();
        healing.Remove(colHealth);
    }

    void FixedUpdate()
    {
        foreach(Health h in healing)
        {
            float changeAmount = Mathf.Min(health.currentHealth, h.maxHealth - h.currentHealth);
            changeAmount = Mathf.Min(changeAmount, maxHealRate);

            h.currentHealth += changeAmount;
            health.currentHealth -= changeAmount;
        }
    }
}
