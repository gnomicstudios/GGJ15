using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
    private Transform target;

    public float walkSpeed = 3.0f;
    public bool facingRight = true;
    public bool isAlive = true;

    private Animator anim;                  // Reference to the player's animator component.

    public void Kill()
    {
        isAlive = false;
        target = null;
        rigidbody.velocity = Vector3.zero;
        transform.rigidbody.isKinematic = true;
    }

    // Use this for initialization
    void Start()
    {		
        anim = GetComponentInChildren<Animator>();
        SelectionManager.Instance.CurrentSelectable = this;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 diff = target.position - this.transform.position;
            if(diff.sqrMagnitude < 0.001f)
            {
                target.GetComponent<MeshRenderer>().enabled = false;
                target = null;
                transform.rigidbody.velocity = Vector3.zero;
            }
            else
            {
                diff.Normalize();
                transform.rigidbody.velocity = diff * walkSpeed;
            }
        }

        anim.SetFloat("VerticalVelocity", transform.rigidbody.velocity.z);
        
        float h = transform.rigidbody.velocity.x;
        anim.SetFloat("HorizontalVelocity", System.Math.Abs(h));
        // If the input is moving the player doesn't match direction facing
        if((Mathf.Abs(h) > 0.05 && (h < 0) == facingRight)
            || (Mathf.Abs(h) < 0.05 && !facingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
        if(isAlive)
        {
            target = targetTransform;
        }
    }

	#endregion
}

