public class HealthPlayer : IHealth
{
    public int HealthDropRate = 1;

    void FixedUpdate()
    {
        currentHealth -= HealthDropRate;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            //DIE DIE DIE
        }
    }
}
