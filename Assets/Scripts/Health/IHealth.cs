using UnityEngine;

public class IHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
     
    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }
}
