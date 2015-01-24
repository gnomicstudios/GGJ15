using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

	public Transform sourceTransform;

	Transform target;
	float walkSpeed = 2.5f;


	// Use this for initialization
	void Start () {

	}
	
	void FixedUpdate () 
	{
		if (target != null)
		{
			Vector3 diff = target.position - this.transform.position;
			if (diff.sqrMagnitude < 0.1f)
			{
				// TODO Attack!
			}
			else
			{
				diff.Normalize();
				sourceTransform.position += diff * walkSpeed * Time.deltaTime;
			}
		}	
	}

	void OnTriggerEnter(Collider other)
	{
		var playerController = other.gameObject.GetComponent<PlayerController> ();
		if (playerController != null && target == null) 
		{
			target = playerController.transform;
		}
	}

	void OnTriggerExit(Collider other)
	{
		var playerController = other.gameObject.GetComponent<PlayerController> ();
		if (playerController != null && playerController.transform == transform) 
		{
			target = null;
		}
	}


}
