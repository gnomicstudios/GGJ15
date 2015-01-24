using UnityEngine;

public class HealthResource : IHealth
{
    void OnTriggerStay(Collider col)
    {
        HealthPlayer health = col.gameObject.GetComponent<HealthPlayer>();
        if(health != null)
        {
            int changeAmount = System.Math.Min(currentHealth, health.maxHealth - health.currentHealth);
            health.currentHealth += changeAmount;
            currentHealth -= changeAmount;
        }
    }
}
