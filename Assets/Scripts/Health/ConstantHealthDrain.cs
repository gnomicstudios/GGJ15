using UnityEngine;

public class ConstantHealthDrain : MonoBehaviour
{
    public Health health;
    public float HealthDropRate = 10f;

    void FixedUpdate()
    {
        health.currentHealth -= Mathf.Min(health.currentHealth, HealthDropRate * Time.fixedDeltaTime);
    }
}
