using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
	private Transform target;

	public float walkSpeed = 3.0f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (target != null)
		{
			Vector3 diff = target.position - this.transform.position;
			if (diff.sqrMagnitude < 0.1f)
				target = null;
			else
			{
				diff.Normalize();
				transform.position += diff * walkSpeed * Time.deltaTime;
			}
		}
	}

	void OnMouseDown()
	{
		SelectionManager.Instance.CurrentSelectable = this;
	}

	#region ISelectableEntity implementation

	public void OnSelect ()
	{
		Debug.Log ("Player Selected");
	}

	public void OnDeselect ()
	{
		Debug.Log ("Player DeSelected");
	}

	public void SetTarget(Transform targetTransform)
	{
		target = targetTransform;
	}

	#endregion
}

