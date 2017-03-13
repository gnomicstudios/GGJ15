using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
    public float walkSpeed = 3.0f;
    public bool facingRight = true;
    public bool isAlive = true;

    private Vector3 target;
    private bool targetReached = true;
    private Animator anim;                  // Reference to the player's animator component.
    private AudioSource footstepsAudioSource;
    private bool isAIControlled = false;

    public void Kill()
    {
        isAlive = false;
        anim.SetBool("IsAlive", false);
        StopWalking();
        transform.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Use this for initialization
    void Start()
    {		
        anim = GetComponentInChildren<Animator>();
        SelectionManager.Instance.CurrentSelectable = this;
        var sounds = GetComponents<AudioSource>();
        footstepsAudioSource = sounds[0];

        SnapCameraToPlayer();
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isAlive)
        {
            return;
        }

        if(!targetReached)
        {
            Vector3 diff = target - this.transform.position;
            if(diff.sqrMagnitude < 0.001f)
            {
                //target.GetComponent<MeshRenderer>().enabled = false;
                targetReached = true;
                if(isAIControlled)
                {
                    var dirn = RandomExtensions.GetOnUnitCircleXZ();
                    SetTarget(this.transform.position + dirn * 10.0f);
                    isAIControlled = true;
                }
                else
                {
                    StopWalking();
                }
            }
            else
            {
                diff.Normalize();
                Walk(diff * walkSpeed);

                if (SelectionManager.Instance.CurrentSelectable == this)
                {
                    SnapCameraToPlayer();
                }
            }
        }
        
        anim.SetBool("IsAlive", isAlive);
        anim.SetFloat("VerticalVelocity", transform.GetComponent<Rigidbody>().velocity.z);
        
        float h = transform.GetComponent<Rigidbody>().velocity.x;
        anim.SetFloat("HorizontalVelocity", System.Math.Abs(h));
        // If the input is moving the player doesn't match direction facing
        if((Mathf.Abs(h) > 0.05 && (h < 0) == facingRight)
            || (Mathf.Abs(h) < 0.05 && !facingRight))
        {
            Flip();
        }
    }

    private void SnapCameraToPlayer()
    {
        // If camera is not manually being moved, follow player
        var cameraController = FindObjectOfType<CameraController>();
        if (!cameraController.IsPanning)
        {
            cameraController.SetPosition(transform.position.x, transform.position.z + cameraController.DistanceFromPlayerX);
        }
    }

    void Walk(Vector3 v)
    {
        transform.GetComponent<Rigidbody>().velocity = v;
        if(!footstepsAudioSource.isPlaying)
        {
            footstepsAudioSource.Play();
        }
    }

    void StopWalking()
    {
        footstepsAudioSource.Stop();
        target = Vector3.zero;
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

    public void SetIsAIControlled(bool ai)
    {
        isAIControlled = ai;
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

    public void SetTarget(Vector3 pos)
    {
        if(isAlive)
        {
            target = pos;
            targetReached = false;
        }
        isAIControlled = false;
    }

	#endregion
}

