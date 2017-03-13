using UnityEngine;

public class HealthUI : MonoBehaviour
{
    RectTransform rectTransform;
    float size;
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        size = rectTransform.sizeDelta.x;
    }

    void FixedUpdate()
    {
        Players players = FindObjectOfType<Players>();
        float currentHealth = 1.0f;
        float maxHealth = 1.0f;
        foreach (var p in players.activePlayers)
        {
            Health health = p.GetComponentInChildren<Health>();
            currentHealth += health.currentHealth;
            maxHealth += health.maxHealth;
        }

        float healthLevel = maxHealth == 0 ? 0.0f : (float)currentHealth / (float)maxHealth;
        rectTransform.sizeDelta = new Vector2(healthLevel * size, rectTransform.sizeDelta.y);
    }
}
