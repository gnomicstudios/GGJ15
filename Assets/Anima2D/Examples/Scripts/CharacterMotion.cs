using UnityEngine;
using System.Collections;

public class CharacterMotion : MonoBehaviour
{
	Animator animator;
    float direction;
    float patrolPeriod;

	void Start()
	{
		animator = GetComponent<Animator>();
        
        // walk in random direction
        direction = Random.Range(0, 2) == 0 ? -1.0f : 1.0f;
        // change directions between 5 and 20 secions.
        patrolPeriod = Random.Range(5.0f, 20.0f);

        Invoke("SwitchDirections", patrolPeriod);
    }

    void SwitchDirections()
    {
        direction = -1.0f * direction;
        Invoke("SwitchDirections", patrolPeriod);
    }

    void Update()
    {
        float xAxis = direction; // Input.GetAxis("Horizontal");

        Vector3 eulerAngles = transform.localEulerAngles;
        Vector3 localScale = transform.localScale;
        if (xAxis != 0.0f)
        {
            if ((localScale.x < 0.0f) != (xAxis < 0.0f))
            {
                localScale.x *= -1.0f;
            }
            transform.localScale = localScale;
        }
		animator.SetFloat("Forward", Mathf.Abs(xAxis));
	}
}
