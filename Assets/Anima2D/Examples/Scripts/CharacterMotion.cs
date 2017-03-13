using UnityEngine;
using System.Collections;

public class CharacterMotion : MonoBehaviour
{
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");

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
