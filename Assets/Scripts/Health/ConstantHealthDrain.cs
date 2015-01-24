using UnityEngine;

public class ConstantHealthDrain : MonoBehaviour
{
    public Health health;
    public int HealthDropRate = 1;

    void FixedUpdate()
    {
        health.currentHealth -= System.Math.Min(health.currentHealth, HealthDropRate);
    }
}
