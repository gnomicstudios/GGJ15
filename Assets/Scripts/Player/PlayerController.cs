using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
    private Vector3 target;
    private bool targetReached = true;

    public float walkSpeed = 3.0f;
    public bool facingRight = true;
    public bool isAlive = true;

    private Animator anim;                  // Reference to the player's animator component.
    private AudioSource footstepsAudioSource;
    private AudioSource[] heatBeatAudioSources;

    public void Kill()
    {
        isAlive = false;
        StopWalking();
        transform.rigidbody.isKinematic = true;
    }

    // Use this for initialization
    void Start()
    {		
        anim = GetComponentInChildren<Animator>();
        SelectionManager.Instance.CurrentSelectable = this;
        var sounds = GetComponents<AudioSource>();
        footstepsAudioSource = sounds[0];
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!targetReached)
        {
            Vector3 diff = target - this.transform.position;
            if (diff.sqrMagnitude < 0.001f)
            {
                //target.GetComponent<MeshRenderer>().enabled = false;
                targetReached = true;
                transform.rigidbody.velocity = Vector3.zero;
            }
            else
            {
                diff.Normalize();
                Walk(diff * walkSpeed);

                // If camera is not manually being moved, follow player
                var cameraController = FindObjectOfType<CameraController>();
                if (!cameraController.IsPanning)
                {
                    cameraController.SetPosition(transform.position.x, transform.position.z + cameraController.DistanceFromPlayerX);
                }
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

    void Walk(Vector3 v)
    {
        transform.rigidbody.velocity = v;
        if (!footstepsAudioSource.isPlaying)
        {
            footstepsAudioSource.Play();
        }
    }

    void StopWalking()
    {
        footstepsAudioSource.Pause();
        target = Vector3.zero;
        transform.rigidbody.velocity = Vector3.zero;
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

    public void SetTarget(Vector3 pos)
    {
        if (isAlive)
        {
            target = pos;
            targetReached = false;
        }
    }

	#endregion
}

