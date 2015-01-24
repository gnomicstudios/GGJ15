using UnityEngine;

public class HealthPlayer : IHealth
{
    public int HealthDropRate = 1;
    public GameObject DeathUI;

    void FixedUpdate()
    {
        currentHealth -= HealthDropRate;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            //DIE DIE DIE
            gameObject.GetComponent<PlayerController>().active = false;
            FindObjectOfType<Timer>().running = false;
            DeathUI.SetActive(true);
        }
    }
}
