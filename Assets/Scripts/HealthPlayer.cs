public class HealthPlayer : IHealth
{
    public int HealthDropRate = 1;

    void FixedUpdate()
    {
        currentHealth -= HealthDropRate;
    }
}
