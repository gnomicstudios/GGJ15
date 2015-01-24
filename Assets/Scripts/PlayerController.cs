using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
    private Transform target;

    public float walkSpeed = 3.0f;
    public bool isAlive = true;

    public void OnHealthDepleted()
    {
        isAlive = false;
        rigidbody.velocity = Vector3.zero;
    }

    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 diff = target.position - this.transform.position;
            if (diff.sqrMagnitude < 0.1f)
            {
                target = null;
                transform.rigidbody.velocity = Vector3.zero;
            }
            else
            {
                diff.Normalize();
                transform.rigidbody.velocity = diff * walkSpeed;
            }
        }
    }

    void OnMouseDown()
    {
        if(isAlive)
        {
            SelectionManager.Instance.CurrentSelectable = this;
        }
    }

	#region ISelectableEntity implementation

    public void OnSelect()
    {
        Debug.Log("Player Selected");
    }

    public void OnDeselect()
    {
        Debug.Log("Player DeSelected");
    }

    public void SetTarget(Transform targetTransform)
    {
        if (isAlive)
        {
            target = targetTransform;
        }
    }

	#endregion
}

