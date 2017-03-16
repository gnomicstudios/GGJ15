using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[HideInInspector]
	public bool IsPanning;
    public bool CanPan = false;

	public float CameraPanSensitvity = 1.0f;

    bool lastIsMouseButtonDown;
    Vector3 lastMouseButtonDownPos;

    float height = 0;
    float lastRotX;

    public void SetTargetPosition(float x, float z)
    {
        float distFromPlayer = height * Mathf.Tan(Mathf.Deg2Rad * (90.0f - transform.localEulerAngles.x));
        var pos = transform.position;
        transform.position = new Vector3(x, pos.y, z - distFromPlayer);
    }

	void Awake () {
        height = transform.position.y;
    }

	void FixedUpdate ()
	{
        if (lastRotX != transform.eulerAngles.x)
        {
            var player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                SetTargetPosition(player.transform.position.x, player.transform.position.z);
            }

            lastRotX = transform.eulerAngles.x;
            var tilters = FindObjectsOfType<Tilt>();
            foreach (var tilt in tilters)
            {
                Vector3 rot = tilt.transform.eulerAngles;
                rot.x = lastRotX;
                tilt.transform.eulerAngles = rot;
            }
        }

        if (!CanPan)
            return;

		if (Input.GetMouseButton(0))
		{
			// Start panning if dragged a small distance
			if (!IsPanning && Vector3.Distance(lastMouseButtonDownPos, Input.mousePosition) > 4.0f)
			{
				IsPanning = true;
			}
        }
		else
		{
			IsPanning = false;
		}

		if (IsPanning && lastMouseButtonDownPos != Input.mousePosition)
		{
			OnDragged(lastMouseButtonDownPos, Input.mousePosition);
		}
		
		lastMouseButtonDownPos = Input.mousePosition;
	}

    void OnDragged(Vector2 from, Vector2 to) {

        var delta = (to - from) * CameraPanSensitvity * -1.0f;
        var pos = GetComponent<Camera>().transform.position;
        SetTargetPosition(pos.x + delta.x, pos.z + delta.y);
    }

}
