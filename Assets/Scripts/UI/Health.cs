using UnityEngine;

public class Health : MonoBehaviour
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
        HealthPlayer health = FindObjectOfType<HealthPlayer>();

        rectTransform.sizeDelta = new Vector2(health.currentHealth * size / health.maxHealth, rectTransform.sizeDelta.y);
    }
}
