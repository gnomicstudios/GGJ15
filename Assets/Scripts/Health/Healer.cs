using UnityEngine;
using System.Collections.Generic;

public class Healer : MonoBehaviour
{
    public Health health;
    private List<Health> healing = new List<Health>();

    public bool healPlayer = true;
    public bool healEnemy = false;
    public int maxHealRate = int.MaxValue;

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
            int changeAmount = System.Math.Min(health.currentHealth, h.maxHealth - h.currentHealth);
            changeAmount = System.Math.Min(changeAmount, maxHealRate);

            h.currentHealth += changeAmount;
            health.currentHealth -= changeAmount;
        }
    }
}
