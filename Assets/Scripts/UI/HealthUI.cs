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
        if (players.activePlayers.Count > 0)
        {
            Health health = players.activePlayers[0].GetComponentInChildren<Health>();
            rectTransform.sizeDelta = new Vector2(health.currentHealth * size / health.maxHealth, rectTransform.sizeDelta.y);
        }
        else
        {
            rectTransform.sizeDelta = new Vector2(0.0f, rectTransform.sizeDelta.y);
        }
    }
}
