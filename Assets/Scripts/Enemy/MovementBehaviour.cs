using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour
{

    public Transform sourceTransform;
    public bool lookAtMove = true;

    PlayerController target;
    float walkSpeed = 2.5f;
    RepelState repelState;
    AudioSource[] attackAudioSources;

    public class RepelState
    {
        public const float RepelDuration = 2.0f;

        public bool isActive;
        public Vector3 repelDirection;
        public float timeRemaining;

        public RepelState(Vector3 direction)
        {
            isActive = true;
            repelDirection = direction;
            timeRemaining = RepelDuration;
        }

        public void Update(float dt)
        {
            timeRemaining -= dt;
            isActive = timeRemaining > 0.0f;
        }
    }

    public void Repell(Vector3 fromPos)
    {
        var diff = transform.position - fromPos;
        diff.Normalize();
        repelState = new RepelState(diff);
        target = null;
    }

    // Use this for initialization
    void Start()
    {
        attackAudioSources = GetComponents<AudioSource>();

    }
	
    void FixedUpdate()
    {
        if(repelState != null)
        {
            repelState.Update(Time.deltaTime);
            if(repelState.isActive)
            {
                sourceTransform.rigidbody.velocity = repelState.repelDirection * walkSpeed;
            }
            else
            {
                sourceTransform.rigidbody.velocity = Vector3.zero;
                repelState = null;
            }
            return;
        }

        if(target != null)
        {
            Vector3 diff = target.transform.position - this.transform.position;
            diff.Normalize();
            sourceTransform.rigidbody.rotation = Quaternion.LookRotation(-diff);
            sourceTransform.rigidbody.velocity = diff * walkSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if(playerController != null && target == null)
        {
            target = playerController;
            attackAudioSources[Random.Range(0, attackAudioSources.Length)].Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if(playerController != null && playerController.transform == transform)
        {
            sourceTransform.rigidbody.velocity = Vector3.zero;
            target = null;
        }
    }


}
